using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Domain.Model
{
    public class Forklift
    {
        public int Id { get; set; }
        public decimal Speed { get; set; }
        public decimal Weight { get; set; }
        public decimal LiftingCapacity { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

    }
}
