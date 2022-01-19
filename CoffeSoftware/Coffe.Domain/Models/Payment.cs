using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class Payment : Entity
    {
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string CardName { get; set; }
        public string Sum { get; set; }
        public List<User> Users { get; set; }

        public Payment()
        {

        }

        public Payment(
            string cardNumber, 
            string cvv, 
            string cardName,
            string sum
           )
        {
            CardNumber = cardNumber;
            CVV = cvv;
            CardName = cardName;
            Sum = sum;
        }
    }
}
