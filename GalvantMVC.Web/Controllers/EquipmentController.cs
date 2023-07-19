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
        public IActionResult AddEquipment(NewEquipmentVm model, AdditionalFieldsVm addmodel)
        {
            var id = _equipmentService.AddEquipment(model, addmodel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEquipment(int id)
        {
            var equipment = _equipmentService.GetEquipmentSharedFieldsForEdit(id);
            var additionalFields = _equipmentService.GetEquipmenmtAdditionalFieldsForEdit(id);

            var editEquipmentVm = new EditEquipmentVm
            {
                NewEquipmentVm = equipment,
                AdditionalFieldsVm = additionalFields
            };

            return View(editEquipmentVm);
        }

        [HttpPost]
        public IActionResult EditEquipment(EditEquipmentVm model)
        {
            _equipmentService.UpdateEquipment(model);
            return RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult Search()
        {
            var types = _equipmentService.GetAllTypeNames();
            var locations = _equipmentService.GetAllLocations();
            var places = _equipmentService.GetAllPlaces();
                        
            ViewBag.Types = types;
            ViewBag.Locations = locations;
            ViewBag.Places = places;

            var searchModel = new SearchVm();
           
            return View(searchModel);
        }

        [HttpPost]
        public IActionResult Search(SearchVm searchVm)
        {
            var results = _equipmentService.Search(searchVm);            

            return PartialView("_SearchResults", results);            
        }
    }
}
