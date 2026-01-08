namespace DotnetAssignment.Models
{
    public class Student
    {
        public int Id { get; set; }          
        public string StudentCode { get; set; } = "";
        public string FullName { get; set; } = "";
        public int Age { get; set; }
        public string Major { get; set; } = "";
        public double GPA { get; set; }      
    }
}
