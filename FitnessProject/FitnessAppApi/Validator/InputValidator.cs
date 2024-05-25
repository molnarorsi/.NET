using FitnessAppApi.Api;
using FluentValidation;

namespace FitnessAppApi.Validator
{
    public class InputValidator<T> : AbstractValidator<T>
    {
        public InputValidator()
        {
            if (typeof(T) == typeof(TicketTypes))
            {
                RuleFor(x => ((TicketTypes)(object)x).Name)
                    .NotEmpty()
                    .WithMessage("Please enter a name.");

                RuleFor(x => ((TicketTypes)(object)x).Price)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Price must be greater than 0.");

                RuleFor(x => ((TicketTypes)(object)x).ValidityDays)
                    .GreaterThan(0)
                    .WithMessage("Validity days must be greater than 0.");

                RuleFor(x => ((TicketTypes)(object)x).ValidityEntries)
                    .GreaterThan(0)
                    .WithMessage("Validity entries must be greater than 0.");

                RuleFor(x => ((TicketTypes)(object)x).ArenaId)
                    .GreaterThan(0)
                    .WithMessage("ArenaId must be greater than 0.");

                RuleFor(x => ((TicketTypes)(object)x).StartHour)
                    .GreaterThanOrEqualTo(0)
                    .LessThanOrEqualTo(24)
                    .WithMessage("Start hour must be greater than or equal to 0.");

                RuleFor(x => ((TicketTypes)(object)x).EndHour)
                    .GreaterThanOrEqualTo(0)
                    .LessThanOrEqualTo(24)
                    .Must((ticketType, endHour) => endHour > ((TicketTypes)(object)ticketType).StartHour)
                    .WithMessage("End hour must be less than or equal to 24.");
                
                RuleFor(x => ((TicketTypes)(object)x).EntriesPerDay)
                    .GreaterThan(0)
                    .WithMessage("Entries per day must be greater than 0.");
            }
            else if (typeof(T) == typeof(Clients))
            {
                RuleFor(x => ((Clients)(object)x).Name)
                    .NotEmpty()
                    .WithMessage("Please enter a name.");

                RuleFor(x => ((Clients)(object)x).Phone)
                    .NotEmpty()
                    .WithMessage("Please enter a phone number.")
                    .Matches(@"^\+.[0-9]{1,3}\s[0-9]{9}$")
                    .WithMessage("Please enter a valid phone number in the format '+X 0123456789' or '+XX 0123456789'");

                RuleFor(x => ((Clients)(object)x).Email)
                    .NotEmpty()
                    .WithMessage("Please enter an email address.")
                    .EmailAddress()
                    .WithMessage("Please enter a valid email address.");

                RuleFor(x => ((Clients)(object)x).CNP)
                    .NotEmpty()
                    .WithMessage("Please enter a CNP number.")
                    .Matches("^[0-9]{13}$")
                    .WithMessage("Please enter a valid CNP number with 13 characters.");

                RuleFor(x => ((Clients)(object)x).Address)
                    .NotEmpty()
                    .WithMessage("Please enter an address.");

                RuleFor(x => ((Clients)(object)x).Barcode)
                    .NotEmpty()
                    .WithMessage("Please enter a barcode.");
            }
        }
    }
}
