using Application.DTOs;
using Application.Features.CarrierConfigurationFeatures.Commands.CreateCarrierConfiguration;
using Application.Features.CarrierFeatures.Commands.CreateCarrier;
using Application.Features.OrderFeatures.Commands.CreateOrder;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Carrier, CarrierViewDto>().ReverseMap();
            CreateMap<CreateCarrierCommand, Carrier>().ReverseMap();
            CreateMap<CreateCarrierConfigurationCommand, CarrierConfiguration>().ReverseMap();
            CreateMap<CarrierConfiguration, CarrierConfigurationViewDto>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<Order, OrderViewDto>().ReverseMap();
        }
    }
}
