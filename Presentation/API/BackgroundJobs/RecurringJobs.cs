using Application.Interfaces.UnitOfWork;
using Hangfire;
using Persistence.UnitOfWork;

namespace API.BackgroundJobs
{
    public static class RecurringJobs
    {
        [Obsolete]
        public static void GetHourlyCarrierReport(IServiceProvider serviceProvider)
        {
            CarrierReport carrier = new CarrierReport(serviceProvider);

            RecurringJob.RemoveIfExists(nameof(carrier.ReportCarriers));

            RecurringJob.AddOrUpdate<ICarrierReport>(nameof(carrier.ReportCarriers), x =>
                  x.ReportCarriers(), Cron.Hourly, TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));
        }
    }
}
