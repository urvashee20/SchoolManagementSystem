using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string ClassName { get; set; }

        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

    }
}
