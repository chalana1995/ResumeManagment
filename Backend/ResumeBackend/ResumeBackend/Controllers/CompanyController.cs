using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeBackend.Core.Context;
using ResumeBackend.Core.Dtos.Company;
using ResumeBackend.Core.Entities;

namespace ResumeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDto dto)
        {
            Company newCompnay = _mapper.Map<Company>(dto);
            await _context.Companies.AddAsync(newCompnay);
            await _context.SaveChangesAsync();

            return Ok("Company created succefully");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            var convertedComapanies = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);

            return Ok(convertedComapanies);
        }


    }
}
