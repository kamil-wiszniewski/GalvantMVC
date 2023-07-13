using GalvantMVC.Application.Interfaces;
using GalvantMVC.Application.ViewModels;
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
        [HttpGet]
        public IActionResult AddEquipment() 
        {
            var types = _equipmentService.GetAllTypeNames();
            ViewBag.Types = types; // Ustaw listę typów w ViewBag
            return View(new NewEquipmentVm());
        }

        //zapsisuje nowe urządzenie w bazie
       [HttpPost]
        public IActionResult AddEquipment(NewEquipmentVm model)
        {
            var id = _equipmentService.AddEquipment(model);
            return View();
        }

        [HttpGet]
        public IActionResult AdditionalFieldsPartial(string selectedType)
        {
            var model = new AdditionalFieldsVm
            {
                SelectedType = selectedType
            };

            return PartialView("_AdditionalFields", model);
        }

        /* public IActionResult ViewEquipment(int equipmentId) 
         {
             var equipmentModel = equipmentService.GetEquipmentDetails(equipmentId);
             return View(equipmentModel);
         }*/
    }
}
