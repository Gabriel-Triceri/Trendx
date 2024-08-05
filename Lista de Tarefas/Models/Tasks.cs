using System.ComponentModel.DataAnnotations;

namespace Lista_de_Tarefas.Models
{
    public class Tasks
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public Boolean completed  { get; set; }


    }
}
