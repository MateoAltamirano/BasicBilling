using System;
using AutoMapper;
using BasicBilling.Core.DTOs;
using BasicBilling.Core.Entities;

namespace BasicBilling.Infrastructure.Mappings
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Bill, BillDTO>();
			CreateMap<BillDTO, Bill>();
        }
	}
}

