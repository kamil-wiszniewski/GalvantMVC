using GalvantMVC.Application.Interfaces;
using GalvantMVC.Application.ViewModels;
using GalvantMVC.Domain.Interface;
using GalvantMVC.Domain.Model;
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

        public int AddEquipment(NewEquipmentVm model, AdditionalFieldsVm addmodel)
        {
            var typeId = _equipmentRepo.GetTypeIdByName(model.Type);

            if (model.Type == "forklift")
            {
                model.AdditionalFields["Speed"] = addmodel.Speed;
                model.AdditionalFields["Weight"] = addmodel.Weight;
                model.AdditionalFields["LiftingCapacity"] = addmodel.LiftingCapacity;
            }

            var equipment = new Equipment
            {
                TypeId = typeId,
                LocationId = 1,
                PlaceId = 1,
                Notes = model.Notes,                
            };

            _equipmentRepo.AddEquipment(equipment);

            if (model.Type == "forklift")
            {
                var forklift = new Forklift
                {
                    EquipmentId = equipment.Id,
                    Speed = addmodel.Speed,
                    Weight = addmodel.Weight,
                    LiftingCapacity = addmodel.LiftingCapacity
                };

                _equipmentRepo.AddForklift(forklift);
            }

            return equipment.Id;
        }

        public void UpdateEquipment(EditEquipmentVm model) 
        {           
            var typeId = _equipmentRepo.GetTypeIdByName(model.NewEquipmentVm.Type);

            var equipment = _equipmentRepo.GetEquipmentById(model.NewEquipmentVm.Id);

            equipment.TypeId = typeId;
            equipment.LocationId = 1;
            equipment.PlaceId = 1;
            equipment.Notes = model.NewEquipmentVm.Notes;
            
            _equipmentRepo.UpdateEquipment(equipment);

            if (model.NewEquipmentVm.Type == "forklift")
            {
                var forklift = _equipmentRepo.GetForkliftByEquipmentId(model.NewEquipmentVm.Id);

                forklift.Speed = model.AdditionalFieldsVm.Speed;
                forklift.Weight = model.AdditionalFieldsVm.Weight;
                forklift.LiftingCapacity = model.AdditionalFieldsVm.LiftingCapacity;                

                _equipmentRepo.UpdateForklift(forklift);
            }            
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

        public NewEquipmentVm GetEquipmentSharedFieldsForEdit(int id) 
        {   
            var equipment = _equipmentRepo.GetEquipmentById(id);

            var typeName = _equipmentRepo.GetTypeNameById(equipment.TypeId);

            var newequipmentVm = new NewEquipmentVm
            {
                Id = equipment.Id,
                Type = typeName,
                Notes = equipment.Notes,
            };
            return newequipmentVm;
        }

        public AdditionalFieldsVm GetEquipmenmtAdditionalFieldsForEdit(int id) 
        {
            var equipment = _equipmentRepo.GetEquipmentById(id);

            if (equipment.TypeId == 1) 
            {
                var forklift = _equipmentRepo.GetForkliftByEquipmentId(id);
                var additionalFieldsVm = new AdditionalFieldsVm()
                {
                    Speed = forklift.Speed,
                    Weight = forklift.Weight,
                    LiftingCapacity = forklift.LiftingCapacity
                };
                return additionalFieldsVm;
            }
            else
            {                
                throw new NotSupportedException("Typ wyposażenia nie jest obsługiwany.");
            }
        }



        public List<string> GetAllTypeNames()
        {
            var types = _equipmentRepo.GetAllTypes();
            var typeNames = types.Select(type => type.Name).ToList();
            return typeNames;            
        }

        public List<string> GetAllLocations()
        {
            var locations = _equipmentRepo.GetAllLocations();
            var locationNames = locations.Select(location => location.Name).ToList();   
            return locationNames;
        }

        public List<string> GetAllPlaces()
        {
            var places = _equipmentRepo.GetAllPlaces();
            var placeNames = places.Select(place => place.Name).ToList();
            return placeNames;
        }

       public SearchResultsListVm Search(SearchVm searchVm)
        {
            var typeId = _equipmentRepo.GetTypeIdByName(searchVm.Type);
            var locationId = _equipmentRepo.GetLocationIdByName(searchVm.Location);
            var placeId = _equipmentRepo.GetPlaceIdByName(searchVm.Place);

            var searchedEquipment = _equipmentRepo.GetAllActiveEquipment().Where(e => e.TypeId == typeId &&
                                                                                 e.LocationId == locationId &&
                                                                                 e.PlaceId == placeId);
            SearchResultsListVm results = new SearchResultsListVm();
            results.List = new List<SearchResultVm>();

            foreach (var item in searchedEquipment)
            {
                var typeName = _equipmentRepo.GetTypeNameById(item.TypeId);
                var locationName = _equipmentRepo.GetLocationNameById(item.LocationId);
                var placeName = _equipmentRepo.GetPlaceNameById(item.PlaceId);

                var searchResultVm = new SearchResultVm()
                {
                    Id = item.Id,
                    TypeName = typeName,
                    LocationName = locationName,
                    PlaceName = placeName
                };
                results.List.Add(searchResultVm);
            }
            results.Count = results.List.Count;
            return results;
        }        
    }
}
