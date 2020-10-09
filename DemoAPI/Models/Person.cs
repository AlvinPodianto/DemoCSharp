using System.Collections.Generic;

namespace DemoDataService.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }

        public List<string> Emails { get; set; }

        public Person()
        {
            Emails = new List<string>();
        }
    }

    public class SuccessResponse
    {
        public bool Success { get; set; }
        public string Reason { get; set; }
    }
}