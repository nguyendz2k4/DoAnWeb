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
    public class ProductsController : Controller
    {
        private readonly APSWeb1Context _context;

        public ProductsController(APSWeb1Context context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
              return _context.TblProducts != null ? 
                          View(await _context.TblProducts.ToListAsync()) :
                          Problem("Entity set 'APSWeb1Context.TblProducts'  is null.");
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CateId"] = new SelectList(_context.TblProductCategoys, "CateId", "Name");
            ViewData["SupplierId"] = new SelectList(_context.TblSuppliers, "Id", "Name");
            ViewData["BrandId"] = new SelectList(_context.TblBrands, "Id", "Name"); // Đảm bảo rằng ViewData["BrandId"] được thiết lập
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,SeoTitle,Status,Image,ListImages,Price,PromotionPrice,Vat,Quantity,Warranty,Hot,Decription,Detail,ViewCount,CateId,UpdateBy,BrandId,SupplierId,UpdateDate,MetaKeyWords,MetaDecription,CreateBy,CreateDate")] TblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                tblProduct.Name = DoAn.Utilities.Function.TitleSlugGenerationAlias(tblProduct.Name);
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CateId"] = new SelectList(_context.TblProductCategoys, "CateId", "CateId", tblProduct.CateId);
            ViewData["SupplierId"] = new SelectList(_context.TblSuppliers, "Id", "Name", tblProduct.SupplierId);
            ViewData["BrandId"] = new SelectList(_context.TblBrands, "Id", "Name", tblProduct.BraindId); // Đảm bảo rằng ViewData["BrandId"] được thiết lập lại
            return View(tblProduct);
        }


        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            ViewData["CateId"] = new
                SelectList(_context.TblProductCategoys, "CateId", "Name", tblProduct.CateId);
            return View(tblProduct);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,SeoTitle,Status,Image,ListImages,Price,PromotionPrice,Vat,Quantity,Warranty,Hot,Decription,Detail,ViewCount,CateId,UpdateBy,BraindId,SupplierId,UpdateDate,MetaKeyWords,MetaDecription,CreateBy,CreateDate")] TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.ProductId))
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
            return View(tblProduct);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblProducts == null)
            {
                return Problem("Entity set 'APSWeb1Context.TblProducts'  is null.");
            }
            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct != null)
            {
                _context.TblProducts.Remove(tblProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(int id)
        {
          return (_context.TblProducts?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
