﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Sale
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InvoiceNumber { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal Discount { get; set; }

        public decimal VATAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual ICollection<SaleProduct> SaleProducts { get; set; }

    }
}
