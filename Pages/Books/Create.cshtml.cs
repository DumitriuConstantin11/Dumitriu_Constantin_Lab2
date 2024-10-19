using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dumitriu_Constantin_Lab2.Data;
using Dumitriu_Constantin_Lab2.Models;

namespace Dumitriu_Constantin_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Dumitriu_Constantin_Lab2.Data.Dumitriu_Constantin_Lab2Context _context;

        public CreateModel(Dumitriu_Constantin_Lab2.Data.Dumitriu_Constantin_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID","PublisherName");
            //ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID","FirstName","LastName");
            var authors=_context.Set<Author>()
                .Select(a=>new
                {
                    a.ID,
                    FullName=a.FirstName+" "+a.LastName
                }).ToList();
            ViewData["AuthorID"] = new SelectList(authors, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
