namespace ResumeBackend.Core.Dtos.Candidate
{
    public class CandiadateGetDto
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        public long JobId { get; set; }
        public string JobTitle { get; set; }
    }
}
