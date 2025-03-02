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
        public List<SelectListItem> Classes { get; set; }
        public int CountryId { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public int StateId { get; set; }
        public List<SelectListItem> States { get; set; }
        public int CityId { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}
