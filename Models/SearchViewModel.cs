using System.ComponentModel.DataAnnotations;

namespace Moo_Arvelous_Coders.Models
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "ID is required")]
        public string SearchId { get; set; } = null!;// keep as string to allow user input, parse to int in controller
        public string? Message { get; set; }
    }
}
