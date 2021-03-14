using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSEmpite.Data;
using IMSEmpite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMSEmpite.Pages.Inventories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Inventory Inventory { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
       
        //Get Handler
        public IActionResult OnGet()
        {
            return Page();
        }

        //Post Handler
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _db.Inventory.Add(Inventory);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
