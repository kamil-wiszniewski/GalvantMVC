using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Domain.Model
{
    public class Compressor
    {
        public int Id { get; set; }
        public decimal Power { get; set; }
        public decimal Capacity { get; set; }
        public decimal Pressure { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
