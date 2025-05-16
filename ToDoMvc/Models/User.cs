using System.ComponentModel.DataAnnotations;

namespace ToDoMvc.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        //
        public List<Todo> Todos { get; set; }
    }
}
