using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.Ideas
{
    public class Idea
    {
        public int Id { get; set; }

        [Required]
        public string Note { get; set; }
    }
}
