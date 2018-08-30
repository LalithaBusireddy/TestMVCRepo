using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


        public override string ToString()
        {
            return this.CustomerId + "|" + this.Name + "|" + this.Email;
            //return base.ToString();
        }
    }
}