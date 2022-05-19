using System.ComponentModel.DataAnnotations;

namespace contas_api_model.DTO
{
    public class SaveUserDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string RepeatPassword { get; set; }
    }
}