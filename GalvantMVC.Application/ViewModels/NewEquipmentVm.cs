using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application.ViewModels
{
    public class NewEquipmentVm
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public IFormFile PhotoFile { get; set; } // Pole do przesłania zdjęcia
        public string PhotoPath { get; set; } // Ścieżka do miniatury zdjęcia        
    }
}
