using ClientAPI.API;
using FluentValidation;
using static ClientAPI.API.Entities;

namespace ClientAPI.Validation
{
    public class Validator<T> : AbstractValidator<T>
    {
        public Validator()
        {
            if(typeof(T) == typeof(Memberships))
            {
                RuleFor(x => ((Memberships)(object)x).membershipName).NotEmpty().WithMessage("Enter gym name: ");
                RuleFor(x => ((Memberships)(object)x).membershipPrice).GreaterThanOrEqualTo(0).WithMessage("Price cannot be 0");
                RuleFor(x => ((Memberships)(object)x).validityDays).GreaterThan(0).WithMessage("Validity days cannot be 0.");
                RuleFor(x => ((Memberships)(object)x).validityEntries).GreaterThan(0).WithMessage("Entry days cannot be 0.");
                RuleFor(x => ((Memberships)(object)x).fitnessID).GreaterThan(0).WithMessage("Gym ID cannot be 0.");
                RuleFor(x => ((Memberships)(object)x).fromHour).GreaterThanOrEqualTo(0).LessThanOrEqualTo(24).WithMessage("Start hour cannot be 0.");
                RuleFor(x => ((Memberships)(object)x).toHour).GreaterThanOrEqualTo(0).LessThanOrEqualTo(24)
                .Must((membership, toHour) => toHour > ((Memberships)(object)membership).fromHour)
                .WithMessage("End hour cannot be 0.");
                RuleFor(x => ((Memberships)(object)x).dailyEntriesNumber).GreaterThan(0).WithMessage("Daily entries cannot be 0.");
            }
            else if (typeof(T) == typeof(Clients)) {
                RuleFor(x => ((Clients)(object)x).clientName).NotEmpty().WithMessage("Please enter name");
                RuleFor(x => ((Clients)(object)x).phoneNumber).NotEmpty().WithMessage("Please enter phone number").Matches(@"^\+.[0-9]{1,3}\s[0-9]{9}$").WithMessage("Invalid number format");
                RuleFor(x => ((Clients)(object)x).email).NotEmpty().WithMessage("Enter E-mail address").EmailAddress().WithMessage("Invalid email address");
                RuleFor(x => ((Clients)(object)x).CNP).NotEmpty().WithMessage("Enter you ID number").Length(13).WithMessage("Invalid ID number");
                RuleFor(x => ((Clients)(object)x).address).NotEmpty().WithMessage("Please enter your address");
                RuleFor(x => ((Clients)(object)x).barcode).NotEmpty().WithMessage("Please enter barcode number");

            }
        }
    }
}

