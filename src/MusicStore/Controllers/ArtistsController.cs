using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace MusicStore.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly MusicContext _context;

        public ArtistsController(MusicContext context)
        {
            _context = context;    
        }

        // GET: Artists
        public async Task<IActionResult> Index(string artistName, string genreFilter, string aritistNation)
        {
            var Artists = _context.Artists.OrderBy(a => a.Name).Where(a => true);

            Dictionary<int, List<Genre>> dic = (from a in _context.Artists
                                                join b in _context.Albums on
                                                a.Id equals b.ArtistID
                                                select new { a.Id, b.Genre }).GroupBy(a => a.Id).ToDictionary(a => a.Key, a => a.Select(c => c.Genre).ToList());


            if (!string.IsNullOrEmpty(artistName))
            {
                Artists = Artists.Where(a => a.Name.Contains(artistName));
            }

            if (!string.IsNullOrEmpty(aritistNation))
            {
                Artists = Artists.Where(a => a.Nationality.Contains(aritistNation));
            }

            if (!string.IsNullOrEmpty(genreFilter))
            {
                Artists = Artists.Include(a => a.Albums).Where(a => a.Albums.Any(b => b.Genre.Name == genreFilter));
            }


            ViewBag.Genres = _context.Genres.Select(g => g.Name).ToList();
            ViewBag.GenresByArtist = dic;

            if (Request.IsAjaxRequest())
            {
                return PartialView("ArtistsList", await Artists.GroupBy(a => a.Type).ToListAsync());
            }

            
            return View(await Artists.GroupBy(a => a.Type).ToListAsync());
        }

        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.SingleOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewBag.Types = new SelectList((IEnumerable<ArtistType>)Enum.GetValues(typeof(ArtistType)));

            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Name,Nationality,Picture,Type")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.SingleOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }
            
            ViewBag.Types = new SelectList((IEnumerable<ArtistType>)Enum.GetValues(typeof(ArtistType)));

            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Name,Nationality,Picture,Type")] Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.SingleOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artists.SingleOrDefaultAsync(m => m.Id == id);
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }
    }
}
