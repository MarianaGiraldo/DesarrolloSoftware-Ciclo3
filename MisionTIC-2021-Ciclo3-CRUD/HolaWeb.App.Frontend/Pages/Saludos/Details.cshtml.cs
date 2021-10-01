using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
new DateTime(2042, 12, 24)using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolaWeb.App.Frontend.Pages
{

    public class DetailsModel : PageModel
    {
        private readonly IRepositorioSaludos repositorioSaludos;
        public Saludo Saludo { get; set; }

        public DetailsModel(IRepositorioSaludos repositorioSaludos)
        {
            this.repositorioSaludos = repositorioSaludos;
        }
        public IActionResult OnGet(int saludoId)
        {
            Saludo = repositorioSaludos.GetSaludoPorId(saludoId);
            if(Saludo==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
    }
}
