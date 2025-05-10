using System.Text.Json.Serialization;

namespace WebApiDemo.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        //[JsonIgnore]    this way is not recommened but it fixes problem in this route api/Employee/dept/{id}
        public virtual List<Employee>? Employees { get; set; }
    }
}
