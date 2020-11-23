using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    public class ShopListsController : Controller
    {
        private readonly ShoppingListContext _context;

        public ShopListsController(ShoppingListContext context)
        {
            _context = context;
        }

        // GET: ShopLists
        public async Task<IActionResult> Index()
        {

            ViewData["Products"] = new SelectList(_context.Product, "Id", "Id");

            return View(await _context.ShopList.ToListAsync());
        }

        // GET: ShopLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopList = await _context.ShopList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopList == null)
            {
                return NotFound();
            }

            return View(shopList);
        }

        // GET: ShopLists/Create
        public IActionResult Create()
        {
            //*****************+++++++++++++++********************++++++++++++++++*****************+++++++++++++++++************
            //!!!!!!!!!!!!!!!!!---------------!!!!!!!!!!!!!!!!!!!!----------------!!!!!!!!!!!!!!!!-----------------!!!!!!!!!!!!!!-----

            //itt kellene átadni a viewnek (ViewData-ban vagy ViewBag-ben) a termékeket amik közül választhat a felhasználó
            //Talán erre jó lenne egy new SelectList(_context....stb)
            //
            //Továbbá azt kell megoldanom hogy amikor elkészítenek egy listát, az hozzon létre egy új listát és a kiválasztott
            //termékeket kapcsolja a listához egy külön táblában ID alapján. Ez megoldható?

            return View();
        }

        // POST: ShopLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListName,CreatingDate,Price,UserId")] ShopList shopList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shopList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shopList);
        }

        // GET: ShopLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopList = await _context.ShopList.FindAsync(id);
            if (shopList == null)
            {
                return NotFound();
            }
            return View(shopList);
        }

        // POST: ShopLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListName,CreatingDate,Price,UserId")] ShopList shopList)
        {
            if (id != shopList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopListExists(shopList.Id))
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
            return View(shopList);
        }

        // GET: ShopLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopList = await _context.ShopList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopList == null)
            {
                return NotFound();
            }

            return View(shopList);
        }

        // POST: ShopLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopList = await _context.ShopList.FindAsync(id);
            _context.ShopList.Remove(shopList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopListExists(int id)
        {
            return _context.ShopList.Any(e => e.Id == id);
        }
    }
}
