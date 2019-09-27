

namespace WebEval.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum Gender
    {
        Masculino,
        Femenino
    }
    public class Estudiante
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required]
        public string Date { get; set; }
    }
}