using ResumeBackend.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ResumeBackend.Core.Dtos.Company
{
    public class CompanyGetDto
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public CompanySize Size { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
       
    }
}
