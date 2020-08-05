using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int AvailableQuantity { get; set; }

        public string Image { get; set; }

        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
