using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManegement.Web.Data;

namespace LeaveManegement.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveTypes = await _context.LeaveTypes.ToListAsync();
            return View(leaveTypes);
        }



        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveTypes == null)
            {
                return NotFound();
            }

            return View(leaveTypes);
        }



        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveTypes leaveTypes)
        {                                          //binder data hver felt fra formen og gemmer i leavetypes object.
            if (ModelState.IsValid)
            {
                _context.Add(leaveTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypes);
        }



        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes.FindAsync(id);
            if (leaveTypes == null)
            {
                return NotFound();
            }
            return View(leaveTypes);
        }



        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,DefaultDays,Id,DateCreated,DateModified")] LeaveTypes leaveTypes)
        {
            if (id != leaveTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveTypes);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)   //fanger evt.Issue
                {
                    if (!LeaveTypesExists(leaveTypes.Id))
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
            return View(leaveTypes);
        }



        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveTypes == null)
            {
                return NotFound();
            }

            return View(leaveTypes);
        }



        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveTypes = await _context.LeaveTypes.FindAsync(id);
            if (leaveTypes != null)
            {
                _context.LeaveTypes.Remove(leaveTypes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool LeaveTypesExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }
    }
}
