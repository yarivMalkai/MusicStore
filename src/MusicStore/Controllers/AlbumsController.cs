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
using Microsoft.AspNetCore.Identity;

namespace MusicStore.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly MusicContext _context;
        public UserManager<ApplicationUser> UserManager { get; set; }

        public AlbumsController(MusicContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        // GET: Albums
        public async Task<IActionResult> Index(string albumName, string genreFilter, string aritistNation)
        {
            string userID = this.UserManager.GetUserId(this.User);

            var Albums = _context.Albums.Include(a => a.Artist).Include(a => a.Genre).Include(a => a.Songs).Where(a => true);
            ViewBag.Genres = _context.Genres.Select(g => g.Name).ToList();
            
            if (this.User.IsInRole("user"))
            {
                ViewBag.Purchases = _context.Purchases.Where(p => p.UserId == userID).ToList();
            }

            if (!String.IsNullOrEmpty(albumName))
            {
                Albums = Albums.Where(a => a.Name.Contains(albumName));
            }

            if (!String.IsNullOrEmpty(genreFilter))
            {
                Albums = Albums.Where(a => a.Genre.Name == genreFilter);
            }

            if (!String.IsNullOrEmpty(aritistNation))
            {
                Albums = from a in Albums
                         join b in _context.Artists on
                          a.ArtistID equals b.Id
                         where (b.Nationality.Contains(aritistNation))
                         select a;
            }

            return View(await Albums.ToListAsync());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.Include(a => a.Artist).Include(a => a.Genre).Include(a => a.Songs).SingleOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["ArtistID"] = new SelectList(_context.Artists, "Id", "Name").OrderBy(a => a.Text);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "Id", "Name").OrderBy(a => a.Text);
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,ArtistID,GenreID,Name,Picture,Price,Year")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "Id", "Id", album.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "Id", "Id", album.GenreID);
            return View(album);
        }

        // GET: Albums/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.SingleOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "Id", "Name", album.ArtistID).OrderBy(a => a.Text);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "Id", "Name", album.GenreID).OrderBy(a => a.Text);
            return View(album);
        }
        
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Purchase(int id)
        {
            string userID = this.UserManager.GetUserId(this.User);
            Purchase p = new Purchase()
            {
                UserId = userID,
                AlbumId = id,
                Date = DateTime.Now
            };

             _context.Add(p);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArtistID,GenreID,Name,Picture,Price,Year")] Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.Id))
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
            ViewData["ArtistID"] = new SelectList(_context.Artists, "Id", "Id", album.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "Id", "Id", album.GenreID);
            return View(album);
        }

        // GET: Albums/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.SingleOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.SingleOrDefaultAsync(m => m.Id == id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }
    }
}
