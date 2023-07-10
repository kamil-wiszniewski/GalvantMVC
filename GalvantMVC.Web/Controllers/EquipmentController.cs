using GalvantMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalvantMVC.Web.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public IActionResult Index()
        {
            var model = _equipmentService.GetAllEquipmentForList();

            return View(model);
        }

        //zwraca widok z pustym formularzem do dodania nowego urządzenia
      /*  [HttpGet]
        public IActionResult AddEquipment() 
        {
            return View();
        }*/

        //zapsisuje nowe urządzenie w bazie
       /* [HttpPost]
        public IActionResult AddEquipment(EquipmentModel model)
        {
            var id = equipmentService.AddEquipment(model);
            return View();
        }*/

       /* public IActionResult ViewEquipment(int equipmentId) 
        {
            var equipmentModel = equipmentService.GetEquipmentDetails(equipmentId);
            return View(equipmentModel);
        }*/
    }
}
