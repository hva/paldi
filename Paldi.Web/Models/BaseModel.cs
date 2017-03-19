using System.Collections.Generic;
using System.Linq;
using Nancy.Security;
using Paldi.Web.Data.Repos.Interfaces;

namespace Paldi.Web.Models
{
    public class BaseModel : Dictionary<string, object>
    {
        private readonly ICatalogRepository catalogRepository;
        private readonly IUserIdentity userIdentity;

        public BaseModel(IUserIdentity userIdentity, ICatalogRepository catalogRepository)
        {
            this.userIdentity = userIdentity;
            this.catalogRepository = catalogRepository;

            Add("Nav", NavItems().ToArray());
            Add("NavRight", NavRightItems().ToArray());
        }

        public BaseModel With(IModel model)
        {
            Add("Current", model);
            return this;
        }

        private IEnumerable<MenuItem> NavItems()
        {
            yield return new MenuItem { Url = "/service", Title = "Услуги" };
            yield return new MenuItem
            {
                Url = "/catalog",
                Title = "Каталог",
                Items = catalogRepository.GetSections().Select(
                    x => new MenuItem { Url = "/catalog/" + x.Slug, Title = x.Name }
                ).ToArray()
            };
            yield return new MenuItem { Url = "/contacts", Title = "Контакты" };
        }

        private IEnumerable<MenuItem> NavRightItems()
        {
            if (userIdentity == null)
            {
                yield return new MenuItem { Url = "/login", Title = "Войти" };
                yield break;
            }

            yield return new MenuItem
            {
                Url = "/user",
                Title = userIdentity.UserName,
                Items = new[]
                {
                    new MenuItem {Url = "/admin/changepassword", Title = "Сменить пароль"},
                    new MenuItem {Url = "/logout", Title = "Выйти"},
                }
            };
        }
    }
}