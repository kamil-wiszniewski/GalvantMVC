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

        public EquipmentService(IEquipmentRepository equipmentRepo)
        {
            _equipmentRepo = equipmentRepo;
        }

        public int AddEquipment(NewEquipmentVm equipment)
        {
            throw new NotImplementedException();
        }

        public ListEquipmentForListVm GetAllEquipmentForList()
        {
            var equipment = _equipmentRepo.GetAllActiveEquipment();
            ListEquipmentForListVm result = new ListEquipmentForListVm();
            result.List = new List<EquipmentForListVm>();
            
            foreach (var item in equipment) 
            {
                var typeName = _equipmentRepo.GetTypeNameById(item.TypeId);
                var locationName = _equipmentRepo.GetLocationNameById(item.LocationId);
                var placeName = _equipmentRepo.GetPlaceNameById(item.PlaceId);

                var equipVm = new EquipmentForListVm()
                {
                    Id = item.Id,
                    TypeName = typeName,
                    LocationName = locationName,
                    PlaceName = placeName
                };
                result.List.Add(equipVm);
            }
            result.Count = result.List.Count;
            return result;
        }

        public CompressorDetailsVm GetEquipmentDetails(int equipmentId)
        {
            var equipment = _equipmentRepo.GetEquipmentById(equipmentId);
            var equipmentVm = new CompressorDetailsVm();
            equipmentVm.Id = equipment.Id;
            equipmentVm.Power = equipment.Compressor.Power;
            equipmentVm.Pressure = equipment.Compressor.Pressure;
            equipmentVm.Capacity = equipment.Compressor.Capacity;

            return equipmentVm;
        }
    }
}
