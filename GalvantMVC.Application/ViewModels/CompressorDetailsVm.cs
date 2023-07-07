using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application.ViewModels
{
    public class CompressorDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Power { get; set; }
        public decimal Capacity { get; set; }
        public decimal Pressure { get; set; }

    }
}
