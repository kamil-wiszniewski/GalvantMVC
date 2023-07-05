using GalvantMVC.Domain.Interface;
using GalvantMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = GalvantMVC.Domain.Model.Type;

namespace GalvantMVC.Infrastructure.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly Context _context;
        public EquipmentRepository(Context context)
        {
            _context = context;
        }

        public void DeleteEquipment(int equipmentId)
        {
            var equipment = _context.Equipment.Find(equipmentId);
            if (equipment != null) 
            {
                _context.Equipment.Remove(equipment);
                _context.SaveChanges();
            }
        }

        public int AddItem(Equipment equipment) 
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
            return equipment.Id;
        }

        public IQueryable<Equipment> GetEquipmentByTypeId(int typeId) 
        {
            var equipment = _context.Equipment.Where(x => x.TypeId == typeId);
            return equipment;   
        }

        public Equipment GetEquipmentById(int equipmentId) 
        {
            var equipment = _context.Equipment.FirstOrDefault(i => i.Id == equipmentId);
            return equipment;
        }

        public IQueryable<Type> GetAllTypes() 
        {
            var types = _context.Types;
            return types;
        }
    }
}
