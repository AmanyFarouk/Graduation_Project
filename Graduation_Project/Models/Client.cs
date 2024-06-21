using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graduation_Project.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //[Required]
        [DataType(DataType.Password)]
        public string ?Password { get; set; }

        public virtual List<SpareParts>? SpareParts { get; set; }
        public virtual List<Order>? Order { get; set; }
        public virtual List<Notifications>? Notifications { get; set; }
        public virtual List<Payment>? Payment { get; set; }



    }
}
