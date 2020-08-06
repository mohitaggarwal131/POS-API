using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Category
    {
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }

        public string Name { get; set; }

    }
}
