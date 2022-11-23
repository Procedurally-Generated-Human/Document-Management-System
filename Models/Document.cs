using System.ComponentModel.DataAnnotations;

namespace DemoDMS.Models
{
    
    public class Document
    {
        public int Id { get; set; }
        public Category Category { get; set; }

        public string? Name { get; set; }
        
        public string? UserName { get; set; } // TODO: true authentication 

        [DataType(DataType.DateTime)]
        public DateTime? UploadDate { get; set; } // TODO: persian calendar



        // TODO: file
        // TODO: file metadata
    }
    public enum Category {تسنیا, تیس, یستن}
}