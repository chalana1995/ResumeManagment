﻿using AutoMapper;
using ResumeBackend.Core.Dtos.Company;
using ResumeBackend.Core.Entities;

namespace ResumeBackend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile :Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
        }
    }
}
