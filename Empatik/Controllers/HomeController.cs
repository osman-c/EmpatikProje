//ÖNEMLİ: kodun çalışması için  appsettings.json'da data source kısmının servera göre değiştirilmesi ve entity framework core ile database oluşturulması lazım
//entity framework için package manager console'a update-database yazın, olmazsa migrations dosyasını silin, add-migration initialcreate yazın, sonrasında update-database yazın

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Empatik.Models;
using System.Globalization;
using Empatik.Data;

namespace Empatik.Controllers
{
    public class HomeController : Controller
    {
        //iki adet liste oluşturmam lazım. bunun için iki adet model oluşturdum. datemodel'de date'i düzgün göndermek için türünü string yaptım.
        public class PageModel
        {
            public string Page { get; set; }
            public int Count { get; set; }
        }

        public class DateModel
        {
            public string Date { get; set; }
            public int Count { get; set; }
        }

        //listeleri model olarak gönderdiğim için model listleri oluşturdum
        public List<DateModel> dates = new List<DateModel>();
        public List<PageModel> pages = new List<PageModel>();

        //databasele çalışmak için entity framework kullandım, data klasörü bunun için
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //database'te entry yoksa database kur, bu if farklı databaselerde çalışmayabilir. kodun önemli bir parçası değil, eğer çalışmazsa iften çıkarıp sonradan silebilirsiniz
            if (!CheckIfTableExists()) 
            {
                CreateDatabase();
            }

            //ilk input "toplam ziyaretçi sayısı"
            ViewBag.TotalViewers = _context.HomeModels.Count().ToString();

            //ikinci input "en çok ziyaretçinin geldiği ülke"
            ViewBag.CountryWithMostViews = _context.HomeModels.GroupBy(p => p.Country).Select(x => new { country = x.Key, count = x.Count() }).OrderByDescending(x => x.count).First().country;

            //sayfa listsi
            var pageList = _context.HomeModels.GroupBy(p => p.Page).Select(x => new { page = x.Key, count = x.Count() }).OrderByDescending(x => x.count).ToList();

            //modele çevirip at
            foreach(var element in pageList) 
            {
                var entry = new PageModel
                {
                    Page = element.page,
                    Count = element.count
               };
                pages.Add(entry);
            }
            return View(pages);
        }

        //database'i kontrol etmek için bunu kullandım, iyi bir kod değil ama error almak dışında başka bir alternatif bulamadım, garanti olsun diye ikinci yazdığım query'i kullandın
        public bool CheckIfTableExists()
        {
            try
            {
                var CountryWithMostViews = _context.HomeModels.GroupBy(p => p.Country).Select(x => new { country = x.Key, count = x.Count() }).OrderByDescending(x => x.count).First().country;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void CreateDatabase()
        {
            //her satırı oku, ayır, modelle, database'e yaz
            string[] lines = System.IO.File.ReadAllLines("data.txt");
            foreach (string line in lines)
            {
                var elements = line.Split("\t");
                Console.WriteLine(elements.Length);
                HomeModel model = new HomeModel
                {
                    Page = elements[0],
                    Browser = elements[1],
                    Country = elements[2],
                    DateTime = DateTime.Parse(elements[3], new CultureInfo("tr-TR"))
                };
                _context.Add(model);
            }
            _context.SaveChanges();
        }

        //tarih listesi
        [HttpPost]
        public IActionResult DateQuery(DateTime date1, DateTime date2)
        {
            if (date1 > date2)
            {
                //burada error verebilirim, ama bence gerek yok. kullanıcı yanlış yazarsa tarihleri değiştirip devam edebiliiriz.
                var temp = date2;
                date2 = date1;
                date1 = temp;
            }

            //tarih boş gelince DateTime.MinValue olarak dönüyor, o yüzden ilk tarih için boş mu değil mi diye kontrol etmeye gerek yok. 
            //ikinci tarih boş gelirse (yani == DateTime.MinValue) maximum tarihe çevir
            if (date2 == DateTime.MinValue)
            {
                date2 = DateTime.MaxValue;
            }

            //aralığı bul
            var list = _context.HomeModels.Where(x => x.DateTime >= date1 && x.DateTime <= date2);

            //format datetime olduğu için gruplarsam düzgün bir sonuç dönmeyeceği için böyle bir kod kullandım,kısaca datetime'ı tuple int tarzı bir yapıya çevirip grupluyor
            var dateList =
                from t in list
                let dt = t.DateTime
                group t by new { y = dt.Year, m = dt.Month, d = dt.Day } into dtd
                select new
                {
                    date = dtd.Key,
                    count = dtd.Count()
                };

            //sırala
            dateList = dateList.OrderBy(x => x.date.y).ThenBy(y => y.date.m).ThenBy(z => z.date.d);

            //modele çevir ve gönder
            foreach (var element in dateList)
            {
                var entry = new DateModel
                {
                    //tarihi düzgün göstermek için string'e çevirdim
                    Date = element.date.d.ToString() + "/" + element.date.m.ToString() + "/" + element.date.y.ToString(), 
                    Count = element.count
                };
                dates.Add(entry);
            }

            return View(dates);
        }
    }
}
