using System.Collections.Generic;
using System.Linq;
using Nancy;

namespace Paldi.Web.Models
{
    public class NavigationModel : Dictionary<string, object>
    {
        public NavigationModel Extend(NancyContext context, string key, object value)
        {
            Add(key, value);
            return Extend(context);
        }

        public NavigationModel Extend(NancyContext context)
        {
            Add("Nav", NavItems().ToArray());
            return this;
        }

        private static IEnumerable<MenuItem> NavItems()
        {
            yield return new MenuItem {Url = "/service", Title = "Услуги"};
            yield return new MenuItem
            {
                Url = "/catalog",
                Title = "Каталог",
                Items = new List<MenuItem>
                {
                    new MenuItem {Url = "/catalog/section1", Title = "Категория 1"},
                    new MenuItem {Url = "/catalog/section2", Title = "Категория 2"},
                    new MenuItem {Url = "/catalog/section3", Title = "Категория 3"},
                }
            };
            yield return new MenuItem {Url = "/contacts", Title = "Контакты"};
        }
    }
}