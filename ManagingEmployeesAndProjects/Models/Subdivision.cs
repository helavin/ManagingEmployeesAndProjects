using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagingEmployeesAndProjects.Models
{
    public class Subdivision
    {
        //[Column(TypeName = "smallint")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
