using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeBackend.Core.Context;
using ResumeBackend.Core.Dtos.Candidate;
using ResumeBackend.Core.Dtos.Company;
using ResumeBackend.Core.Dtos.Job;
using ResumeBackend.Core.Entities;

namespace ResumeBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public CandidateController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCandidate([FromForm] CandidateCreateDto dto, IFormFile pdfFile)
        {

            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";

            if(pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
            {
                return BadRequest("File is Not Valid");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            Candidate newCandidate = _mapper.Map<Candidate>(dto);
            newCandidate.ResumeUrl = resumeUrl;
            await _context.Candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();

            return Ok("Candidate created succefully");
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandiadateGetDto>>> GetCandidates()
        {
            var candidates = await _context.Candidates.Include(candidate => candidate.Job).ToListAsync();
            var convertedCandidates = _mapper.Map<IEnumerable<JobGetDto>>(candidates);

            return Ok(convertedCandidates);
        }

        [HttpGet]
        [Route("download/{id}")]
        public IActionResult DownloadPdfFile(string url)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);

            if(!System.IO.File.Exists(filePath))
            {
                return NotFound("File Not Found");
            }

            var pdfBytes = System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfBytes, "application/pdf", url);

            return file;

        }
    }
}
