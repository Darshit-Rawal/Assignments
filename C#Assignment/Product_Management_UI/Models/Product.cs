using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Management_UI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product Name must be between 3 and 50")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product Category is Required")]
        [Display(Name = "Product Category")]
        public int ProductCategoryId { get; set; }

        [Required(ErrorMessage = "Product Price is Required")]
        [Display(Name = "Price Per Unit")]
        public double PricePerUnit { get; set; }

        [Required(ErrorMessage = "Product Quantity is Required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Short Description is Required")]
        [Display(Name = "Short Description")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Short Description must be between 10 and 100")]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        [MaxLength(500, ErrorMessage = "Long Description can not be greater than 500")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Small Image is Required")]
        [Display(Name = "Small Image")]
        public string SmallImagePath { get; set; }

        [Display(Name = "Large Image")]
        public string LargeImagePath { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "UserId")]
        public string CreatedBy { get; set; }

        public ProductCategory ProductCategory { get; set; }
        
    }
}