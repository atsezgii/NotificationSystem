using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Profiles
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<User, RegisterCommand>().ReverseMap();
            CreateMap<User, RegisterResponse>().ReverseMap();
        }
    }
}
