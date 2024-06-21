using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.DTO.OrderDto
{
    public class OrderDto
    {
           
            public int ID { get; set; }
            public string ClientName { get; set; }

            
            public string WorkerName { get; set; }
            public string Date { get; set; }

            public string Time { get; set; }
            public string ClientAddress { get; set; }
            public string Phone { get; set; }
            public string Problem { get; set; }
            public TypeOfOrder typeOfOrder { get; set; }
            public TypeOfPayment typeOfPayment { get; set; }
            public string AdminName { get; set; }
        }
}
