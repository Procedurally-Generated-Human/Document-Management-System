using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDMS.Models
{
    
    public class Document
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string? Name { get; set; }
        
        [Required]
        [Display(Name = "کاربر")]
        public string? UserName { get; set; } 

        [Display(Name = "تاریخ")]
        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; } // TODO: persian calendar

        [Display(Name = "دسته بندی")]
        public Category Category { get; set; }

        
        [Display(Name="File")]
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public string? Extension { get; set;}
        public double? size { get; set;}

        // TODO: file
        // TODO: file metadata
    }
    public enum Category {تسنیا, تیس, یستن}
}