using System.ComponentModel.DataAnnotations;

namespace StudentManagementEF.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }//EF automatically makes this a primary

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1,100)]
        public int Age { get; set; }
        //designing database table without writing the sql
        [Required]
        [MaxLength(100)]
        public string Email {  get; set; }=string.Empty;//means empty value sam as sttring b=""

        public List<Course> Courses { get; set; }=new List<Course>();
    }
}
