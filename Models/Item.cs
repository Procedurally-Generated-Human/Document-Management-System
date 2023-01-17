using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDMS.Models
{
    public interface Item{
        int Id {set; get;}

        string? Name { get; set; }
        
        [DataType(DataType.DateTime)]
        DateTimeOffset DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        DateTimeOffset DateModified { get; set; }

        bool IsComposite();
    }
}