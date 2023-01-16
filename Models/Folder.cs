using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDMS.Models
{
    public interface Item{

    }
    
    public class Folder: Item
    {
        public int Id { get; set; } 
        public string? Name { get; set; }

        [NotMapped]
        public Item[]? Contents {get; set; }
    }

}