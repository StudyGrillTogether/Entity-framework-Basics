using System.ComponentModel.DataAnnotations;

namespace StudentManagementEF.Models
{
    public class Student
    {
        public int Id { get; set; }//EF automatically makes this a primary

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1,100)]
        public int Age { get; set; }
        //designing database table without writing the sql
    }
}
