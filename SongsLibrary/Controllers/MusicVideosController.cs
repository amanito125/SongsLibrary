using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SongsLibrary.Data;

namespace SongsLibrary.Controllers
{
    [Authorize]
    public class MusicVideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusicVideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MusicVideos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MusicVideo.Include(m => m.Artist).Include(m => m.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MusicVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MusicVideo == null)
            {
                return NotFound();
            }

            var musicVideo = await _context.MusicVideo
                .Include(m => m.Artist)
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicVideo == null)
            {
                return NotFound();
            }

            return View(musicVideo);
        }

        // GET: MusicVideos/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Name");
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "GenreTitle");
            return View();
        }

        // POST: MusicVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Duration,ReleaseDate,ArtistId,GenreId")] MusicVideo musicVideo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", musicVideo.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "GenreTitle", musicVideo.GenreId);
            return View(musicVideo);
        }

        // GET: MusicVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MusicVideo == null)
            {
                return NotFound();
            }

            var musicVideo = await _context.MusicVideo.FindAsync(id);
            if (musicVideo == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Name", musicVideo.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "GenreTitle", musicVideo.GenreId);
            return View(musicVideo);
        }

        // POST: MusicVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Duration,ReleaseDate,ArtistId,GenreId")] MusicVideo musicVideo)
        {
            if (id != musicVideo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicVideoExists(musicVideo.Id))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", musicVideo.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", musicVideo.GenreId);
            return View(musicVideo);
        }

        // GET: MusicVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MusicVideo == null)
            {
                return NotFound();
            }

            var musicVideo = await _context.MusicVideo
                .Include(m => m.Artist)
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musicVideo == null)
            {
                return NotFound();
            }

            return View(musicVideo);
        }

        // POST: MusicVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MusicVideo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MusicVideo'  is null.");
            }
            var musicVideo = await _context.MusicVideo.FindAsync(id);
            if (musicVideo != null)
            {
                _context.MusicVideo.Remove(musicVideo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicVideoExists(int id)
        {
          return (_context.MusicVideo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
