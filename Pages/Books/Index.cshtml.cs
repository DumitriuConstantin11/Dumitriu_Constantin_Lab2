using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dumitriu_Constantin_Lab2.Data;
using Dumitriu_Constantin_Lab2.Models;

namespace Dumitriu_Constantin_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Dumitriu_Constantin_Lab2.Data.Dumitriu_Constantin_Lab2Context _context;

        public IndexModel(Dumitriu_Constantin_Lab2.Data.Dumitriu_Constantin_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            /*Book = await _context.Book
                .Include(b=>b.Author)
                .ToListAsync();*/
            //Book = await _context.Book.Include(c=>c.Publisher).ToListAsync();
            BookD.Books = await _context.Book
            .Include(b => b.Author)
             .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();

            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}
