using System.Collections.Generic;
using System.Linq;
using Nancy.ViewEngines.Razor;
using Paldi.Web.Data.Repos.Interfaces;
using Paldi.Web.Models;

namespace Paldi.Web.HtmlHelpers
{
    public static class Navigation
    {
        private static ICatalogRepository _catalogRepository;

        public static void Enable(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public static IEnumerable<MenuItem> NavItems<T>(this HtmlHelpers<T> helpers)
        {
            yield return new MenuItem { Url = "/service", Title = "Услуги" };
            yield return new MenuItem
            {
                Url = "/catalog",
                Title = "Каталог",
                Items = _catalogRepository.GetSections().Select(
                    x => new MenuItem { Url = "/catalog/" + x.Slug, Title = x.Name }
                ).ToArray()
            };
            yield return new MenuItem { Url = "/contacts", Title = "Контакты" };
        }

        public static IEnumerable<MenuItem> NavRightItems<T>(this HtmlHelpers<T> helpers, NancyRazorViewBase view)
        {
            if (view.Context.CurrentUser == null)
            {
                yield return new MenuItem { Url = "/login", Title = "Войти" };
                yield break;
            }

            yield return new MenuItem
            {
                Url = "/user",
                Title = view.Context.CurrentUser.UserName,
                Items = new[]
                {
                    new MenuItem {Url = "/admin/changepassword", Title = "Сменить пароль"},
                    new MenuItem {Url = "/logout", Title = "Выйти"},
                }
            };
        }
    }
}