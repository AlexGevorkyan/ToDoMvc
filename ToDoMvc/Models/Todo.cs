using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoMvc.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey("FK_User_123")]
        public int UserId { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        //
        public User User { get; set; }

    }
}
