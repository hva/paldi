using System;
using FluentValidation;
using Paldi.Web.Data.Repos.Interfaces;

namespace Paldi.Web.Models.Login
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        private readonly IUsersRepository usersRepository;

        public LoginRequestValidator(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(m => m.Login).NotEmpty();
            RuleFor(m => m.Password).NotEmpty().Must(BeValid);
        }

        public Guid LastGuid { get; set; }

        private bool BeValid(LoginRequest request, string _)
        {
            Guid guid;
            if (usersRepository.TryLogin(request.Login, request.Password, out guid))
            {
                LastGuid = guid;
                return true;
            }
            return false;
        }
    }
}