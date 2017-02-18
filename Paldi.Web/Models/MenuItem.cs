using System.Collections.Generic;

namespace Paldi.Web.Models
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public ICollection<MenuItem> Items { get; set; }
    }
}