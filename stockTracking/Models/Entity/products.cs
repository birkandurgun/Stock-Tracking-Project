namespace stockTracking.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class products
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Product Name")]
        public string pName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Description")]
        public string pDescription { get; set; }

        [Display(Name = "Quantity")]
        public Nullable<int> pQuantity { get; set; }

        [Display(Name = "Price")]
        public Nullable<int> pPrice { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Brand")]
        public string pBrand { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Brand")]
        public string pCategory { get; set; }
    }
}
