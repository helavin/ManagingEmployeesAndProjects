using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagingEmployeesAndProjects.Models
{
    public class Project
    {
        //[Column(TypeName = "smallint")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        //public Project()
        //{
        //    ProjectEmployees = new List<ProjectEmployee>();
        //}
    }
}
