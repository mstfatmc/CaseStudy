using CaseStudy.Services.Model;
using CaseStudy.Services.Requests;
using FluentValidation;

namespace CaseStudy.Services.Validations
{
    public class CompanyValidator : AbstractValidator<CreateCompanyServiceRequest>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address can not be empty");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber can not be empty");
        }
    }
}