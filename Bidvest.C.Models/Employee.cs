using System.Collections.Generic;

namespace Bidvest.C.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string IPAddress { get; set; }

        public List<Employee> list(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(jsonString); ;
        }
    }
}
