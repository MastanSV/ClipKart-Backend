using System.ComponentModel.DataAnnotations.Schema;

namespace ClipKart.Core.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public long Price { get; set; }
    }
}
