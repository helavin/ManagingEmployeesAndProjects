using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagingEmployeesAndProjects.Models
{
    public enum Sex { Female, Male }
    public class Employee
    {
        //[Column(TypeName = "smallint")]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        //[Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [Required]
        public int? SubdivisionId { get; set; }
        public virtual Subdivision Subdivision { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        //public Employee()
        //{
        //    Subdivision = new Subdivision();
        //    ProjectEmployees = new List<ProjectEmployee>();
        //}
    }
}
