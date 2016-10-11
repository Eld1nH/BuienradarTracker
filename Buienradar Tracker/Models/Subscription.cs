using FluentValidation;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Buienradar_Tracker.Models
{
    [Table("Subscription")]
    [Validator(typeof(SubscriptionValidator))]
    public class Subscription
    {
        [Key]
        public int Id { get; set; }
        public string WeatherStationCode { get; set; }
        public string Gender { get; set; }
        public string Initials { get; set; }
        public string FirstNames { get; set; }
        public string Prefix { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }

    public class SubscriptionDbContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
    }

    public class SubscriptionValidator : AbstractValidator<Subscription>
    {
        private SubscriptionDbContext _subscriptionDbContext = new SubscriptionDbContext();

        public SubscriptionValidator()
        {
            RuleFor(s => s.WeatherStationCode)
                .NotEmpty()
                .Length(0, 10)
                .WithMessage("Weatherstation code is invalid");

            RuleFor(s => s.EmailAddress)
                .EmailAddress()
                .NotEmpty()
                .Length(0, 256)
                .WithMessage("Email address is invalid");

            RuleFor(s => s.EmailAddress)
                .Must(BeUniqueWeatherStationEmailAddressCombination)
                .WithMessage("Email address is already subscribed to weather location");
        }

        private bool BeUniqueWeatherStationEmailAddressCombination(Subscription subscription, string emailAddress)
        {
            return _subscriptionDbContext.Subscriptions
                .FirstOrDefaultAsync(s => s.EmailAddress == emailAddress && s.WeatherStationCode == subscription.WeatherStationCode)
                .Result == null;
        }
    }
}