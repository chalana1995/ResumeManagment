using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResumeBackend.Core.Context;

namespace ResumeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        public CompanyController(ApplicationDbContext context)
        {
            context = _context;
        }


    }
}
