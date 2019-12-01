using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LBANC.Models;
using DataLayer;
using DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using BuissnesLayer.Interfaces;
using BuissnesLayer;

namespace LBANC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly EFDBContext _context;
        //private readonly IDirectoryRepository _directoryRepository;
        private readonly DataManager _dataManager;
        public HomeController(ILogger<HomeController> logger, /*EFDBContext context, IDirectoryRepository directoryRepository,*/ DataManager dataManager)
        {
            _logger = logger;
            //_context = context;
            //_directoryRepository = directoryRepository;
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            HelloModel _model = new HelloModel() { HelloMessage = "Hey Roman!" };
            //List<Directory> dirs = _context.Directories.Include(x => x.Materials).ToList();
            //List<Directory> dirs = _directoryRepository.GetAllDirectories().ToList();
            List<Directory> dirs = _dataManager.Directorys.GetAllDirectories(true).ToList();
            return View(dirs);
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
