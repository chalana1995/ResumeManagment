using AutoMapper;
using ResumeBackend.Core.Dtos.Company;
using ResumeBackend.Core.Dtos.Job;
using ResumeBackend.Core.Entities;

namespace ResumeBackend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile :Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();

            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>();
        }
    }
}
