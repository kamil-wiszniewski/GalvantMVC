using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Domain.Model
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; } 
        public string FilePath { get; set; }
        public int EquipmentId { get; set; } 
        public virtual Equipment Equipment { get; set; }     
    }
}
