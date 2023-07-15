using GalvantMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application.ViewModels
{
    public class EditEquipmentVm
    {
        public NewEquipmentVm NewEquipmentVm { get; set; }
        public AdditionalFieldsVm AdditionalFieldsVm { get; set; }
    }
}
