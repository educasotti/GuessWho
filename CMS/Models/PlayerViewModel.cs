using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Model;

namespace CMS.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int DecadeId { get; set; }
        public int LevelId { get; set; }
        public int CountryId { get; set; }
        public bool IsPublished { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}