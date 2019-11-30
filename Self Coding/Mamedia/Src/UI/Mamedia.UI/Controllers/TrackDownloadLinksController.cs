using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mamedia.Domain.Core.Entities;
using Mamedia.Infrastructure.Data;

namespace Mamedia.UI.Controllers
{
    public class TrackDownloadLinksController : Controller
    {
        private readonly MamediaDataContext _context;

        public TrackDownloadLinksController(MamediaDataContext context)
        {
            _context = context;
        }

        // GET: TrackDownloadLinks
        public async Task<IActionResult> Index()
        {
            var mamediaDataContext = _context.TrackDownloadLinks.Include(t => t.Track);
            return View(await mamediaDataContext.ToListAsync());
        }

        // GET: TrackDownloadLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackDownloadLink = await _context.TrackDownloadLinks
                .Include(t => t.Track)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trackDownloadLink == null)
            {
                return NotFound();
            }

            return View(trackDownloadLink);
        }

        // GET: TrackDownloadLinks/Create
        public IActionResult Create()
        {
            ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Id");
            return View();
        }

        // POST: TrackDownloadLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrackId,Id,Tilte,UrlForLink")] TrackDownloadLink trackDownloadLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trackDownloadLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Id", trackDownloadLink.TrackId);
            return View(trackDownloadLink);
        }

        // GET: TrackDownloadLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackDownloadLink = await _context.TrackDownloadLinks.FindAsync(id);
            if (trackDownloadLink == null)
            {
                return NotFound();
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Id", trackDownloadLink.TrackId);
            return View(trackDownloadLink);
        }

        // POST: TrackDownloadLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrackId,Id,Tilte,UrlForLink")] TrackDownloadLink trackDownloadLink)
        {
            if (id != trackDownloadLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trackDownloadLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackDownloadLinkExists(trackDownloadLink.Id))
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
            ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Id", trackDownloadLink.TrackId);
            return View(trackDownloadLink);
        }

        // GET: TrackDownloadLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trackDownloadLink = await _context.TrackDownloadLinks
                .Include(t => t.Track)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trackDownloadLink == null)
            {
                return NotFound();
            }

            return View(trackDownloadLink);
        }

        // POST: TrackDownloadLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trackDownloadLink = await _context.TrackDownloadLinks.FindAsync(id);
            _context.TrackDownloadLinks.Remove(trackDownloadLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrackDownloadLinkExists(int id)
        {
            return _context.TrackDownloadLinks.Any(e => e.Id == id);
        }
    }
}
