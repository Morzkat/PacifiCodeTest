using System;
using FluentValidation;
using KHahn.ApplicationProcess.February2021.Domain.Models.DTOs;
using KHahn.ApplicationProcess.February2021.Domain.Interfaces.HttpClient;
using KHahn.ApplicationProcess.February2021.Domain.Models.Entities;

namespace KHahn.ApplicationProcess.February2021.Domain.Validators
{
    public class AssetValidator : AbstractValidator<AssetDTO>
    {
        public AssetValidator(ICountryHttpClient countryHttpClient)
        {
            RuleFor(x => x.AssetName).MinimumLength(5);
            RuleFor(x => x.Department)
                .Custom((deparment, context) =>
            {
                if(!Enum.TryParse(deparment, out Department department))
                    context.AddFailure("Is not a valid department type.");
            });
            RuleFor(x => x.CountryOfDepartment).NotNull().Custom((country, context) =>
            {
                if (!countryHttpClient.CountryExist(country).Result)
                    context.AddFailure("The specified country doesn't exist.");
            });
            RuleFor(x => x.PurchaseDate).Must(BeAValidDate); //-> must not be older then one year.
            RuleFor(x => x.EmailAdressOfDepartment).EmailAddress();
        }

        private bool BeAValidDate(string value)
        {
            if (DateTime.TryParse(value, out DateTime date))
                return (date.Year >= DateTime.Now.Year) ? true : false;

            return false;
        }
    }
}



//If the object is invalid ( on post and put ) � return 400 and an information what property does not fullyfy the requirements and which requirement is not fullyfied.


