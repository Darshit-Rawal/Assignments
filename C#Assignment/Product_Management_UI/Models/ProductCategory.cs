using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Product_Management_UI.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Required]
        [MaxLength(30)]
        public string ProductCategoryName { get; set; }
    }
}