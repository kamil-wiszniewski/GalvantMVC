using GalvantMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = GalvantMVC.Domain.Model.Type;

namespace GalvantMVC.Domain.Interface
{
    public interface IEquipmentRepository
    {
        void DeleteEquipment(int equipmentId);      

        int AddEquipment(Equipment equipment);      

        IQueryable<Equipment> GetEquipmentByTypeId(int typeId);       

        Equipment GetEquipmentById(int equipmentId);      

        IQueryable<Type> GetAllTypes();

        IQueryable<Equipment> GetAllActiveEquipment();

        string GetTypeNameById(int typeId);

        string GetLocationNameById(int locationId);

        string GetPlaceNameById(int placeId);

    }
}
