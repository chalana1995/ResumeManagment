namespace ResumeBackend.Core.Dtos.Candidate
{
    public class CandidateCreateDto
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public long JobId { get; set; }
    }
}
