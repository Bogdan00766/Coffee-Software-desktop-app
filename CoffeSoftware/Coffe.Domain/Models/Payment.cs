using Coffe.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffe.Domain.Models
{
    public class Payment : Entity
    {
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public string CardName { get; set; }
        public int Sum { get; set; }
        public User User { get; set; }

        public Payment()
        {

        }

        public Payment(
            int cardNumber,
            int cvv, 
            string cardName,
            int sum
           )
        {
            CardNumber = cardNumber;
            CVV = cvv;
            CardName = cardName;
            Sum = sum;
        }
    }
}
