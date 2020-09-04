using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_60.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int IDNumber { get; set; }
        public long Jmbg { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string PhoneNumber { get; set; }
        public string SectorName { get; set; }
        public string LocationName { get; set; }
        public int SectorId { get; set; }
        public int LocationId { get; set; }
        public int MenagerId { get; set; }
        public string MenagerName { get; set; }
    }
}
