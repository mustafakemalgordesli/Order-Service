using Application.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace API.BackgroundJobs
{
    public class CarrierReport : ICarrierReport
    {
        private readonly IServiceProvider _serviceProvider;
        public CarrierReport(IServiceProvider serviceProvider)
        {
            _serviceProvider= serviceProvider;
        }
        public void ReportCarriers()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                IUnitOfWork _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
                Console.WriteLine("Deneme");
            }
        }
    }
}
