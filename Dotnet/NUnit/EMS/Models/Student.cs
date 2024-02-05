namespace EMS.Models
{
    public class Student
    {
        public int Id{get;set;}
        public string Name{get;set;} = string.Empty;
        public string Grade { get; set; }

        public int Age{get;set;}
        public string Gender{get;set;} = string.Empty;

    }
}