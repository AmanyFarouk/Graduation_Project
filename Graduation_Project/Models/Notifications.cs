using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graduation_Project.Models
{
    public class Notifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Messege { get; set; }
        [ForeignKey("Client")]
        public int? ClientId { get; set; }

        [ForeignKey("Worker")]
        public int? WorkerId { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;

        public virtual Client ?Client { get; set; }
        public virtual Worker ?Worker { get; set; }
    }
}
