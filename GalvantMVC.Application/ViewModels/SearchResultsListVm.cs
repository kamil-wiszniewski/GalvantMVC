using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalvantMVC.Application.ViewModels
{
    public class SearchResultsListVm    
    {
        
            public List<SearchResultVm> List { get; set; }
            public int Count { get; set; }        
    }
}
