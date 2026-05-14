using System.ComponentModel.DataAnnotations;

namespace PatientServiceAPI.DTOs
{
    public class CreatePatientDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required]
        [Range(1, 120, ErrorMessage = "Age should be between 1 and 120")]
        public int Age { get; set; }
        public string Gender { get; set; }
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string ContactNumber { get; set; }
        
    }
}
