using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myproj.Models;

namespace myproj.Views
{
    public class CentralTblsController : Controller
    {
        private readonly MyprojContext _context;

        public CentralTblsController(MyprojContext context)
        {
            _context = context;
        }

        // GET: CentralTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.CentralTbl.ToListAsync());
        }

        // GET: CentralTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centralTbl = await _context.CentralTbl
                .SingleOrDefaultAsync(m => m.Id == id);
            if (centralTbl == null)
            {
                return NotFound();
            }

            return View(centralTbl);
        }

        // GET: CentralTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentralTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageLink,AboutUs,Email,Mobile,Address")] CentralTbl centralTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centralTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centralTbl);
        }

        // GET: CentralTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centralTbl = await _context.CentralTbl.SingleOrDefaultAsync(m => m.Id == id);
            if (centralTbl == null)
            {
                return NotFound();
            }
            return View(centralTbl);
        }

        // POST: CentralTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageLink,AboutUs,Email,Mobile,Address")] CentralTbl centralTbl)
        {
            if (id != centralTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centralTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentralTblExists(centralTbl.Id))
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
            return View(centralTbl);
        }

        // GET: CentralTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centralTbl = await _context.CentralTbl
                .SingleOrDefaultAsync(m => m.Id == id);
            if (centralTbl == null)
            {
                return NotFound();
            }

            return View(centralTbl);
        }

        // POST: CentralTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centralTbl = await _context.CentralTbl.SingleOrDefaultAsync(m => m.Id == id);
            _context.CentralTbl.Remove(centralTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentralTblExists(int id)
        {
            return _context.CentralTbl.Any(e => e.Id == id);
        }
    }
}
