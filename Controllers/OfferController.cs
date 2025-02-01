using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Recrutement.Models;
using Microsoft.AspNetCore.Authorization;


namespace E_Recrutement.Controllers
{
    [Authorize(Roles = "Recruiter")]
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OfferController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        // GET: Offer
        public  IActionResult Index()
        {
            List<Offer> OffersList = _db.Offers.ToList();
            return View(OffersList);
        }

        // GET: Offer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,recruiterId,ContractType,Sector,Profile,Position,Salary")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                _db.Add(offer);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(offer);
        }

        // GET: Offer/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = _db.Offers.Find(id);
            if (offer == null)
            {
                return NotFound();
            }
            return View(offer);
        }

        // POST: Offer/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,recruiterId,ContractType,Sector,Profile,Position,Salary")] Offer offer)
        {
            if (id != offer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(offer);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.Id))
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
            return View(offer);
        }

        // GET: Offer/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = _db.Offers
                .FirstOrDefault(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offer/Delete
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var offer = _db.Offers.Find(id);
            _db.Offers.Remove(offer);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferExists(int id)
        {
            return _db.Offers.Any(e => e.Id == id);
        }
    }
}
