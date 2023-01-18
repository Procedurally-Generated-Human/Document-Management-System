using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDMS.Models
{
    public interface Item {
        int Id {set; get;}

        string? Name { get; set; }
        
        [DataType(DataType.DateTime)]
        DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        DateTime DateModified { get; set; }

        bool IsComposite();

        int ParentId {get; set;}
    }
}