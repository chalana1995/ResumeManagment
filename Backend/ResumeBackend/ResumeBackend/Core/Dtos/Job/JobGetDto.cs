using ResumeBackend.Core.Enums;

namespace ResumeBackend.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long ID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public string CompanyName { get; set; }
        public long CompanyId { get; set; }
    }
}
