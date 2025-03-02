using System.Web.Mvc;

namespace School.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public IEnumerable<SelectListItem> Classes { get; set; } = new List<SelectListItem>();
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; } = new List<SelectListItem>();
        public int StateId { get; set; }
        public IEnumerable<SelectListItem> States { get; set; } = new List<SelectListItem>();
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; } = new List<SelectListItem>();
    }
}
