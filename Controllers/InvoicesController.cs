using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiletUygulamasi.Data;
using Microsoft.AspNetCore.Authorization;

namespace BiletUygulamasi.Controllers
{
    [Authorize]
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public IActionResult Index()
        {
            return View();
        }

        // POST: Invoices
        [HttpPost]
        public async Task<IActionResult> Index(DateTime startDate, DateTime endDate)
        {
            var invoices = await _context.Tickets
                .Where(t => t.IsInvoiced
                            && t.InvoicedAt >= startDate
                            && t.InvoicedAt <= endDate)
                .ToListAsync();

            return View("List", invoices);
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id && t.IsInvoiced);
            if (ticket == null) return NotFound();

            return View(ticket);
        }
    }
}
