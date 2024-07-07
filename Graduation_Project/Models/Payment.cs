using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graduation_Project.Models
{
    public class Payment
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ID { get; set; }
        //[ForeignKey("Client")]
        //public int ClientId { get; set; }
        //[Required]
        //public int Price { get; set; }
        //[Required]
        //[RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        //public string Phone { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //public string WalletPassword { get; set; }
        //public DateTime Date { get; set; }= DateTime.Now;

        //public virtual Client? Client { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string Phone { get; set; }
        public Int16? confirm { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public virtual Client? Client { get; set; }
    }
}
