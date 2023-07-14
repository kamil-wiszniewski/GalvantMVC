using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application.ViewModels
{
    public class NewEquipmentVm
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public Dictionary<string, object> AdditionalFields { get; set; } = new Dictionary<string, object>();
    }
}
