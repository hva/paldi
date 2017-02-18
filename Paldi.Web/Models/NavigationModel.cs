using System.Collections.Generic;

namespace Paldi.Web.Models
{
    public class NavigationModel
    {
        public NavigationModel()
        {
            Nav = new List<MenuItem>
            {
                new MenuItem { Url = "/service", Title = "Услуги" },
                new MenuItem
                {
                    Url = "/catalog",
                    Title = "Каталог",
                    Items = new List<MenuItem>
                    {
                        new MenuItem { Url = "/catalog/section1", Title = "Категория 1" },
                        new MenuItem { Url = "/catalog/section2", Title = "Категория 2" },
                        new MenuItem { Url = "/catalog/section3", Title = "Категория 3" },
                    }
                },
                new MenuItem { Url = "/contacts", Title = "Контакты" },
            };
        }

        public ICollection<MenuItem> Nav { get; }
    }
}