using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public int ClassId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Classes classes { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country country { get; set; }

        [ForeignKey("StateId")]
        public virtual State state { get; set; }

        [ForeignKey("CityId")]
        public virtual City city { get; set; }
    }
}
