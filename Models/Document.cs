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

        [DataType(DataType.DateTime)]
        public DateTimeOffset UploadDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset ModifiedDate { get; set; }

        public double? Size { get; set;}
        
        [Display(Name="File")]
        public string? FilePath { get; set; }

        public string? FileType { get; set; }
        
        public string? AuthorName { get; set; }

        public string? SupervisorName { get; set; }      

        public Level Level { get; set; }

        public Department Department { get; set; }

        public Faculty Faculty { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTimeOffset PublicationDate { get; set; }

    }

    public enum Level {کارشناسی, ارشد, دکترا}

    public enum Department {فنی, ادبیات, علوم}

    public enum Faculty {برق, کامپیوتر}

}