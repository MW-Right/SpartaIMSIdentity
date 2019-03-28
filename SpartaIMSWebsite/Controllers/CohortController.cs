using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpartaIMS_Database.Data;
using SpartaIMS_Database.Models;

namespace SpartaIMSWebsite.Controllers
{
    [Authorize]
    public class CohortController : Controller
    {
        List<SpartanUser> spartans = new List<SpartanUser>();
        
        private readonly SpartaIMSDbContext _context;

        public CohortController(SpartaIMSDbContext context)
        {
            _context = context;
        }

        // GET: Cohort
        public async Task<IActionResult> Index()
        {

            var spa = _context.SpartanUsers;
            spartans= spa.ToList<SpartanUser>();

            return View(await _context.Cohorts.ToListAsync());
        }

        // GET: Cohort/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohorts
                .FirstOrDefaultAsync(m => m.CohortID == id);
            if (cohort == null)
            {
                return NotFound();
            }
            else
            {
                spartans = _context.SpartanUsers.Where(su => su.CohortID == cohort.CohortID).ToList();
            }

            return View(cohort);
        }

        // GET: Cohort/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cohort/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CohortID,CohortName")] Cohort cohort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cohort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cohort);
        }

        // GET: Cohort/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohorts.FindAsync(id);
            if (cohort == null)
            {
                return NotFound();
            }
            return View(cohort);
        }

        // POST: Cohort/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CohortID,CohortName")] Cohort cohort)
        {
            if (id != cohort.CohortID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cohort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CohortExists(cohort.CohortID))
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
            return View(cohort);
        }

        // GET: Cohort/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohorts
                .FirstOrDefaultAsync(m => m.CohortID == id);
            if (cohort == null)
            {
                return NotFound();
            }


            return View(cohort);
        }

        // POST: Cohort/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cohort = await _context.Cohorts.FindAsync(id);
            //var spartan = await _context.SpartanUsers.FindAsync(id);
             
            //spartan  = spartan.Where(s => s.Cohort.Contains(searchName));
            //if ()
            //{
            //    ViewBag.ErrorMessage = "Can't delete record attached to user";
            //    //_context.Cohorts.Remove(cohort);
            //    //await _context.SaveChangesAsync();
                
            //}
            return RedirectToAction(nameof(Index));

        }

        private bool CohortExists(int id)
        {
            return _context.Cohorts.Any(e => e.CohortID == id);
        }
    }
}
