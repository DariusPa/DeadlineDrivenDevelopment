using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class LearningDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Topic Topic { get; set; }
        
        [Required]
        public Employee Employee { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
    }
}