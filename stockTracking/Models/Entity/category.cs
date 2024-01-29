namespace stockTracking.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class category
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Category Name")]
        public string cName { get; set; }
    }
}
