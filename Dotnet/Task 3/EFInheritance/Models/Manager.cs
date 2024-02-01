using System.ComponentModel.DataAnnotations.Schema;

namespace EFInheritance.Models
{
    [Table("MANAGERS")]
    public class Manager:Employee
    {
        public string? Department {get;set;}
    }
    
}