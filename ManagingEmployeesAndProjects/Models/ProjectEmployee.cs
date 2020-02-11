using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingEmployeesAndProjects.Models
{
    public class ProjectEmployee
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
