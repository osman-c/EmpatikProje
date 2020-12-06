using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empatik.Models
{
    public class HomeModel
    {
        public int Id { get; set; }
        public string Page { get; set; }
        public string Browser { get; set; }
        public string Country { get; set; }
        public DateTime DateTime { get; set; }
    }
}
