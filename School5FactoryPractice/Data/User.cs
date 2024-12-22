using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School5FactoryPractice.Data
{
    public class User
    {
        public int UserId {  get; set; }
        public string Role {  get; set; }
        public string? Name { get; set; }
        public int? CurrentClass { get; set; }
        public  Int64 PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? CurrentHomework { get; set; }
        public DateTime HomeworkRemainingTime { get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }
    }
}
