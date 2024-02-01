using System.ComponentModel.DataAnnotations.Schema;

namespace EFInheritance.Models
{
    public class Employee
    {
        public int ID{get;set;}
        public string ?Name{get;set;}
        public DateTime HireDate{get;set;}

    }
    
}