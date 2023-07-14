using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application.ViewModels
{
    public class AdditionalFieldsVm
    {
        public string SelectedType { get; set; }
        public decimal Speed { get; set; }
        public decimal Weight { get; set; }
        public decimal LiftingCapacity { get; set; }
        public string Field2 { get; set; }
    }
}
