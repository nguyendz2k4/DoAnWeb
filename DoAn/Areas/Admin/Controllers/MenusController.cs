using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn.Models;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenusController : Controller
    {
        private readonly APSWeb1Context _context;

        public MenusController(APSWeb1Context context)
        {
            _context = context;
        }

        // GET: Admin/Menus


        public async Task<IActionResult> Index()
        {

            return _context.TblMenus != null ? 
                          View(await _context.TblMenus.ToListAsync()) :
                          Problem("Entity set 'APSWeb1Context.TblMenus'  is null.");
        }

        // GET: Admin/Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblMenus == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMenu == null)
            {
                return NotFound();
            }

            return View(tblMenu);
        }

        // GET: Admin/Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Link,Target,Description,Status,Position")] TblMenu tblMenu)
        {
            if (ModelState.IsValid)
            {
                tblMenu.Name = DoAn.Utilities.Function.TitleSlugGenerationAlias(tblMenu.Name);
                _context.Add(tblMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMenu);
        }

        // GET: Admin/Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblMenus == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus.FindAsync(id);
            if (tblMenu == null)
            {
                return NotFound();
            }
            return View(tblMenu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Link,Target,Description,Status,Position")] TblMenu tblMenu)
        {
            if (id != tblMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMenuExists(tblMenu.Id))
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
            return View(tblMenu);
        }

        // GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblMenus == null)
            {
                return NotFound();
            }

            var tblMenu = await _context.TblMenus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMenu == null)
            {
                return NotFound();
            }

            return View(tblMenu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblMenus == null)
            {
                return Problem("Entity set 'APSWeb1Context.TblMenus'  is null.");
            }
            var tblMenu = await _context.TblMenus.FindAsync(id);
            if (tblMenu != null)
            {
                _context.TblMenus.Remove(tblMenu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMenuExists(int id)
        {
          return (_context.TblMenus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
