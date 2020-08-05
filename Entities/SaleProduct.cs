﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class SaleProduct
    {

        public int SaleId { get; set; }
        public int ProductId { get; set; }

        public int InvoiceNumber { get; set; }

        public int Quantity { get; set; }

        public virtual Sale Sale { get; set; }

        public virtual Product Product { get; set; }
    }
}
