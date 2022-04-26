using GenericRepository.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Interfaces;
using System.Diagnostics;

namespace GenericRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<People> _repository;


        public HomeController(ILogger<HomeController> logger, IGenericRepository<People> repository)
        {
            _logger = logger;
            _repository = repository;   
    
        }

        public IActionResult Index()
        {
            var people = _repository.GetAll();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(People people)
        {
            _repository.Create(people);
         
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people = _repository.GetById(id);

            return View(people);
        }

        [HttpPost]
        public IActionResult Edit(People people)
        {
            _repository.Update(people.Id, people);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var people = _repository.GetById(id);
            return View(people);
        }

        [HttpPost]
        public IActionResult Delete(People people)
        {
            _repository.Delete(people.Id);

            return RedirectToAction("Index", "Home");
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