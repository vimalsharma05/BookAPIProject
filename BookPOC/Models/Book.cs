using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Book
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string AutherName { get; set; }
    }
}
