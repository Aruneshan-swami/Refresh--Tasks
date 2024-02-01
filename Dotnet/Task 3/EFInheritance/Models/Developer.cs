using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFInheritance.Models
{
    [Table("DEVELOPERS")]
    public class Developer:Employee
    {
        public string ? softWare{get;set;}        
    }
    
}