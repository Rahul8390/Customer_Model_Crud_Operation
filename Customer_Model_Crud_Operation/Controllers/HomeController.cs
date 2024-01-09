using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Customer_Model_Crud_Operation.Models;

namespace Customer_Model_Crud_Operation.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerContext _context;

        public HomeController(CustomerContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustDetails.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custDetail = await _context.CustDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (custDetail == null)
            {
                return NotFound();
            }

            return View(custDetail);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,EmailId,PhoneNo,City")] CustDetail custDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(custDetail);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custDetail = await _context.CustDetails.FindAsync(id);
            if (custDetail == null)
            {
                return NotFound();
            }
            return View(custDetail);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailId,PhoneNo,City")] CustDetail custDetail)
        {
            if (id != custDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustDetailExists(custDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(custDetail);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custDetail = await _context.CustDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (custDetail == null)
            {
                return NotFound();
            }

            return View(custDetail);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custDetail = await _context.CustDetails.FindAsync(id);
            if (custDetail != null)
            {
                _context.CustDetails.Remove(custDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustDetailExists(int id)
        {
            return _context.CustDetails.Any(e => e.Id == id);
        }
    }
}
