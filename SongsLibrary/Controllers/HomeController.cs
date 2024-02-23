using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongsLibrary.Data;
using SongsLibrary.Models;
using System.Diagnostics;

namespace SongsLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            int artistsCount = _context.Artist.Count();
            int genresCount = _context.Genre.Count();
            int musicVideosCount = _context.MusicVideo.Count();
            ViewData["ArtistsCount"] = artistsCount;
            ViewData["GenresCount"] = genresCount;
            ViewData["MusicVideosCount"] = musicVideosCount;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
