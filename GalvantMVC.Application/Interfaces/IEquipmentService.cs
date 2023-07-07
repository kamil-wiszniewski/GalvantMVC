using GalvantMVC.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application.Interfaces
{
    public interface IEquipmentService
    {
        ListEquipmentForListVm GetAllEquipmentForList();
        int AddEquipment(NewEquipmentVm equipment);

        CompressorDetailsVm GetEquipmentDetails(int equipmentId);

    }
}
