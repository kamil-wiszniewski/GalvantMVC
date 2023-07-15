using GalvantMVC.Application.ViewModels;
using GalvantMVC.Domain.Model;
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
        int AddEquipment(NewEquipmentVm model, AdditionalFieldsVm addmodel);

        CompressorDetailsVm GetEquipmentDetails(int equipmentId);

        NewEquipmentVm GetEquipmentSharedFieldsForEdit(int id);

        AdditionalFieldsVm GetEquipmenmtAdditionalFieldsForEdit(int id);

        List<string> GetAllTypeNames();

    }
}
