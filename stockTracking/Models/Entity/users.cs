namespace stockTracking.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class users
    {
        [Display(Name = "Username")]
        public string username { get; set; }

        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
