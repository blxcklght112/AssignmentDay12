using Day7.Data;
using Day7.Models;
using Day7.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day7.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IRookiesService _rookiesService;
        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger, IRookiesService rookiesService)
        {
            _logger = logger;
            _rookiesService = rookiesService;

        }

        public IActionResult Index()
        {
            return View(RookiesData.People);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonModel model)
        {
            _rookiesService.AddPerson(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int personId)
        {
            var data = _rookiesService.GetPersonById(personId);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(PersonModel model)
        {
            _rookiesService.EditPerson(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            var deletedPersonName = HttpContext.Session.GetString("deletedPersonName");
            ViewBag.DeletedPersonName = deletedPersonName;
            return View();
        }

        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            var item = _rookiesService.GetPersonById(id);
            _rookiesService.DeletePerson(id);
            return RedirectToAction("Delete");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}