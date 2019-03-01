using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Model;
using Utility.Model.ApplicationClass;

namespace CoreAngularApp.AutoMapper
{
    public class AutoMapperProfileConfiguration
	{   
		// public class AutoMapperProfileConfiguration : Profile
		public class OrganizationProfile : Profile
		{
			public OrganizationProfile()
			{
				CreateMap<UserAC, ApplicationUser>().ReverseMap();
			}
		}
	}
}
