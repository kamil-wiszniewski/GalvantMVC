using GalvantMVC.Application.Interfaces;
using GalvantMVC.Application.ViewModels;
using GalvantMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepo;
        public int AddEquipment(NewEquipmentVm equipment)
        {
            throw new NotImplementedException();
        }

        public ListEquipmentForListVm GetAllEquipmentForList()
        {
            var equipment = _equipmentRepo.GetAllActiveEquipment();
            ListEquipmentForListVm result = new ListEquipmentForListVm();
            result.List = new List<EquipmentForListVm>; 
        }

        public CompressorDetailsVm GetEquipmentDetails(int equipmentId)
        {
            throw new NotImplementedException();
        }
    }
}
