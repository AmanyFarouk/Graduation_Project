using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.DTO.OrderDto
{
    public class OrderAdminDto
    {
        [Required]
        public string WorkerName { get; set; }
        [Required]
        public string AdminName { get; set; }
    }
}
