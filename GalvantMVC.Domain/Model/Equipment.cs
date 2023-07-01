using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Domain.Model
{
    public class Equipment
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string LocationId { get; set; }
        public string PlaceId { get; set; }
        public string Notes { get; set; }
        public virtual Type Type { get; set; }
        public virtual Location Location { get; set; }
        public virtual Place Place { get; set; }
        public Forklift Forklift { get; set; }
        public Compressor Compressor { get; set; }
    }
}
