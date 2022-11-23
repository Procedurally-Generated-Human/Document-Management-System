using System.ComponentModel.DataAnnotations;

namespace DemoDMS.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? UserName { get; set; } // TODO: true authentication 

        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; } // TODO: persian calendar

        public Category CategoryType { get; set; }

        // TODO: file
        // TODO: file metadata
    }
    public enum Category { مالی, اداری, شخصی}
}