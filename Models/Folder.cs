using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDMS.Models
{
    public class Folder: Item
    {
        public int Id { get; set; }

        public bool IsComposite() {
            return true;
        }

        public string? Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }

        public List<Item> Contents = new List<Item>();

        public int ParentId {get; set;}
    }
}