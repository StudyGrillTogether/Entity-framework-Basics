using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentManagementEF.Models
{
    public class Course
    {
        [Key] public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        //foreign key
        public int StudentId { get; set; }

        [JsonIgnore] //REMOVES BACKWARD LOOP AND PREVENTS INFINITE RECURSIONS FIXES API RESPONSE OF OBJECT CYCLE
        public Student? Student { get; set; }
        //It’s called StudentId because it stores the Id of the related Student as a foreign key.
        //ef automatically understands that the above two are connected

        [Required]
        public int Duration { get; set; }


    }

}
