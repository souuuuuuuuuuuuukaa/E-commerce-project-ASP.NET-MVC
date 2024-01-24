using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lunettes.Data;
using lunettes.Models;

namespace lunettes.Controllers
{
    public class PaniersController : Controller
    {
        private readonly lunettesContext _context;

        public PaniersController(lunettesContext context)
        {
            _context = context;
        }

        // GET: Paniers
        public async Task<IActionResult> Index()
        {
            List<Products> l = new List<Products>();
            try
            {
                string[] panier = HttpContext.Request.Cookies["panier"].Split('-');

                for (int i = 0; i < panier.Length; i++)
                {
                    l.Add(await _context.Products.FirstOrDefaultAsync(m => m.Id == Int32.Parse(panier[i])));
                }


                /*var produit = await _context.Produit.FindAsync(id);
                if (produit == null)
                {
                    return NotFound();
                }
                Console.WriteLine(produit.Categorie);*/
                return View(l);
            }
            catch (Exception ex)
            {
                return View(l);
            }
           // var lunettesContext = _context.Panier.Include(p => p.Products);
          //  return View(await lunettesContext.ToListAsync());
        }

        // GET: Paniers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Panier
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // GET: Paniers/Create
        public IActionResult Create()
        {
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Paniers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantite,ProductsId")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Name", panier.ProductsId);
            return View(panier);
        }

        // GET: Paniers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Panier.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Name", panier.ProductsId);
            return View(panier);
        }

        // POST: Paniers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantite,ProductsId")] Panier panier)
        {
            if (id != panier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanierExists(panier.Id))
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
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Name", panier.ProductsId);
            return View(panier);
        }

        // GET: Paniers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Panier
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // POST: Paniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var panier = await _context.Panier.FindAsync(id);
            if (panier != null)
            {
                _context.Panier.Remove(panier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanierExists(int id)
        {
            return _context.Panier.Any(e => e.Id == id);
        }
    }
}
