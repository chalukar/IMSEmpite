using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMSEmpite.Data;
using IMSEmpite.Models;

namespace IMSEmpite.Pages.Inventories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Inventory Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inventory = await _db.Inventory.FirstOrDefaultAsync(m => m.Id == id);

            if (Inventory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var serviceFromDb = await _db.Inventory.FirstOrDefaultAsync(s => s.Id == Inventory.Id);
            serviceFromDb.ItemName = Inventory.ItemName;
            serviceFromDb.Qty = Inventory.Qty;
            await _db.SaveChangesAsync();
           

            return RedirectToPage("./Index");
        }

    }
}
