using System.Collections.Generic;
using System.Linq;
using Nancy;
using Paldi.Web.Data.Repos.Interfaces;

namespace Paldi.Web.Models
{
    public class NavigationModel : Dictionary<string, object>
    {
        private readonly ICatalogRepository catalogRepository;

        public NavigationModel(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }

        public NavigationModel With(NancyContext context)
        {
            Add("Nav", NavItems().ToArray());
            Add("NavRight", NavRightItems(context).ToArray());
            return this;
        }

        public NavigationModel With(string key, object value)
        {
            Add(key, value);
            return this;
        }

        private IEnumerable<MenuItem> NavItems()
        {
            yield return new MenuItem {Url = "/service", Title = "Услуги"};
            yield return new MenuItem
            {
                Url = "/catalog",
                Title = "Каталог",
                Items = catalogRepository.GetSections().Select(
                    x => new MenuItem { Url = "/catalog/" + x.Slug, Title = x.Name }
                ).ToArray()
            };
            yield return new MenuItem {Url = "/contacts", Title = "Контакты"};
        }

        private static IEnumerable<MenuItem> NavRightItems(NancyContext context)
        {
            yield return (context.CurrentUser == null)
                ? new MenuItem { Url = "/login", Title = "Войти" }
                : new MenuItem { Url = "/logout", Title = "Выйти" };
        }
    }
}