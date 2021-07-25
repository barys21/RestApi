using AutoMapper;
using RestApi.Models;
using RestApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<AutoMapperUser, AutoMapperUserViewModel>().ReverseMap();
            CreateMap<DirectoryOne, AutoMapperUser>();
        }
    }
}
