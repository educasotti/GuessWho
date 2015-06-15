using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Model;

namespace CMS.Models
{
    public class CountryViewModel
    {
        Country Country { get; set; }
        HttpPostedFile File { get; set; }
    }
}