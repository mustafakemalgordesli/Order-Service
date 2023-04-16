using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace API.BackgroundJobs
{
    public class CarrierReport : ICarrierReport
    {
        private readonly IServiceProvider _serviceProvider;
        public CarrierReport(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task ReportCarriers()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    IUnitOfWork _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
                    IOrderRepository _orderRepository = _unitOfWork.OrderRepository;
                    ICarrierReportRepository _carrierReportRepository = _unitOfWork.CarrierReportRepository;

                    var orders = await _orderRepository.GetAllAsync();

                    var groupedOrders = orders.GroupBy(o => new { o.CarrierId, o.OrderDate });

                    List<Domain.Entities.CarrierReport> result = groupedOrders.Select(g => new Domain.Entities.CarrierReport()
                    {
                        CarrierId = g.Key.CarrierId,
                        CarrierReportDate = g.Key.OrderDate,
                        CarrierCost = g.Sum(o => o.OrderCarrierCost)
                    }).ToList();

                    await _carrierReportRepository.AddRangeAsync(result);

                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                ReportCarriers();
            }
        }
    }
}
