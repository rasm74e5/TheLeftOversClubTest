using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheLeftOversClubTest.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace TheLeftOversClubTest.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("https://localhost:44394/api/values").Result;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<List<Product>>(responseBody);
                return View(model);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    //    private readonly TheLeftOversClubTestContext _context;

    //    public ProductsController(TheLeftOversClubTestContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Products
    //    public async Task<IActionResult> Index()
    //    {
    //        return View(await _context.Product.ToListAsync());
    //    }

    //    // GET: Products/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Product
    //            .FirstOrDefaultAsync(m => m.ProductID == id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }

    //    // GET: Products/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Products/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("ProductID,Description,Price,AdvancedDescription,Picture")] Product product)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(product);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(product);
    //    }

    //    // GET: Products/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Product.FindAsync(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(product);
    //    }

    //    // POST: Products/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("ProductID,Description,Price,AdvancedDescription,Picture")] Product product)
    //    {
    //        if (id != product.ProductID)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(product);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!ProductExists(product.ProductID))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(product);
    //    }

    //    // GET: Products/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var product = await _context.Product
    //            .FirstOrDefaultAsync(m => m.ProductID == id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }

    //    // POST: Products/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var product = await _context.Product.FindAsync(id);
    //        _context.Product.Remove(product);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool ProductExists(int id)
    //    {
    //        return _context.Product.Any(e => e.ProductID == id);
    //    }
}

