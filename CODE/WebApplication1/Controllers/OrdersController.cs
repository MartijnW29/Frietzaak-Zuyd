using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication1.Migrations;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly FrietzaakDBContext _context;

        public OrdersController(FrietzaakDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddToOrder(int? id, int OrderId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Name == "Henk");

            var order = await _context.Orders
                .Include(o => o.OrderLines)  // Inclusief de bestaande orderregels
                .FirstOrDefaultAsync(o => o.Id == OrderId);


            if (order.OrderLines == null)
            {
                order.OrderLines = new List<OrderLine>();
            }

            var existingOrderLine = order.OrderLines.FirstOrDefault(ol => ol.ProductId == id);

            if (existingOrderLine != null)
            {
                existingOrderLine.PoductAmount += 1;
            }
            else
            {
                OrderLine newOrderLine = new OrderLine
                {
                    ProductId = id.Value,
                    OrderId = order.Id,
                    PoductAmount = 1
                };

                order.OrderLines.Add(newOrderLine);
            }


            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                order.TotalPrice += product.Price;
            }

            await _context.SaveChangesAsync();




            var viewModel = new BestellenViewModel
            {
                Products = await _context.Products.ToListAsync(),
                Order = order // Geef de bijgewerkte order mee
            };

            // Configuratie voor JsonSerializerSettings
            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            // Sla het viewmodel op in TempData met de aangepaste instellingen
            TempData["BestellenViewModel"] = JsonConvert.SerializeObject(viewModel, jsonSettings);


            return RedirectToAction("BestellenReturn", "Products");





            //return RedirectToAction(controllerName: "Products", actionName: "BestellenReturn", BestellenViewModel viewModel);
        }

        public async Task<IActionResult> RemoveFromOrder()
        {
            return RedirectToAction(controllerName: "Products", actionName: "Bestellen");
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var frietzaakDBContext = _context.Orders.Include(o => o.Customer);
            return View(await frietzaakDBContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,TotalPrice,OrderDate,Completed")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,TotalPrice,OrderDate,Completed")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderLines)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
