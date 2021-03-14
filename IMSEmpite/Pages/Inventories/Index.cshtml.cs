using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSEmpite.Data;
using IMSEmpite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IMSEmpite.Pages.Inventories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<Inventory> Inventory { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Inventory = await _db.Inventory.ToListAsync();
            return Page();
        }
    }
}
