using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.DTO.OrderDto
{
    public class GetAllOrdersClientDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string WorkerName { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Adress is required.")]
        public string ClientAddress { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Problem Description is required.")]
        public string Problem { get; set; }
        //[Required]
        //public TypeOfOrder typeOfOrder { get; set; }
        //[Required]
        //public TypeOfPayment typeOfPayment { get; set; }
    }
}
