using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDMS.Models
{
    
    public class Document
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Extension { get; set;}
        
        public string? UserName { get; set; } 

        public Category Category { get; set; }

  
        [DataType(DataType.DateTime)]
        public DateTimeOffset UploadDate { get; set; }
        

        [DataType(DataType.DateTime)]
        public DateTimeOffset ModifiedDate { get; set; }

        public double? Size { get; set;}

        
        [Display(Name="File")]
        public string? FilePath { get; set; }
        public string? FileType { get; set; }


        // new fields

        
        public string? StudentName { get; set; }
        public Faculty Faculty { get; set; }
        public Department Department { get; set; }
        public int? YearOfPublication { get; set; }
        public Degree Degree { get; set; }   
        public string? Supervisor { get; set; }      
        

    }
    public enum Category {اداری, مالی, مدیریت, عمومی}
    public enum Faculty {فنی, انسانی, غلوم}
    public enum Department {برق, کامپیوتر}
    public enum Degree {ارشد, دکتری}
}