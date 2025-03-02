using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Repository.IRepository;
using School.Models;
using School.Models.ViewModels;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var student = await _unitOfWork.Student.GetAllStudents();
            return View(student);
        }

        public async Task<IActionResult> Create()
        {
            var model = new StudentViewModel
            {
                Classes = (await _unitOfWork.Classes.GetAll()).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.ClassName }).ToList(),
                Countries = (await _unitOfWork.Countrys.GetAll()).Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList(),

                 States = new List<SelectListItem>(),
                Cities = new List<SelectListItem>()
            }; 

            return PartialView("_StudentPartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Students
                {
                    Name = model.Name,
                    DOB = model.DOB,
                    Address = model.Address,
                    ClassId = model.ClassId,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    CityId = model.CityId
                };
                await _unitOfWork.Students.Add(student);
                return RedirectToAction("Index");
            }
            return PartialView("_StudentPartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> GetStates(int countryId)
        {
            var states = await _unitOfWork.States.GetAll();
            return Json(states.Where(s => s.CountryId == countryId));
        }

        [HttpGet]
        public async Task<IActionResult> GetCities(int stateId)
        {
            var cities = await _unitOfWork.Citys.GetAll();
            return Json(cities.Where(c => c.StateId == stateId));
        }

    }
}





