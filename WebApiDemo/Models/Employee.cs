using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Range(1000, 10000)]
        public int Salary { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int? Dept_ID { get; set; }
        public virtual Department? Department { get; set; }
    }
}
