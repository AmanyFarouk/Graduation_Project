﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.DTO.PaymentDto
{
    public class PaymentDto
    {
        //public int ID { get; set; }
        //public string ClientName { get; set; }
        //[Required]
        //public int Price { get; set; }
        //[Required]
        //[RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        //public string Phone { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //public string WalletPassword { get; set; }
        public int ClientId { get; set; }
        public int Price { get; set; }
        public string Phone { get; set; }
        public Int16? confirm { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
