using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wikipedia.Models
{
    public class SearchItem
    {
        public int SearchItemId { get; set; }
        public string ItemName { get; set; }
        public DateTime SearchDate { get; set; }
    }

}