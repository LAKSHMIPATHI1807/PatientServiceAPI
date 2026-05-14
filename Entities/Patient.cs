using System.ComponentModel.DataAnnotations;

namespace PatientServiceAPI.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Range(1,120,ErrorMessage ="Age should be between 1 and 120")]
        public int Age { get; set; }
        public string Gender { get; set; }
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string ContactNumber { get; set; }
       
    }
}
