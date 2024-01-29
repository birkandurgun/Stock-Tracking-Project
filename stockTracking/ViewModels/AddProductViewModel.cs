using stockTracking.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stockTracking.ViewModals
{
    public class AddProductViewModel
    {
        public products ProductModel { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}