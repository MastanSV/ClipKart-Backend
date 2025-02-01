using System.ComponentModel.DataAnnotations.Schema;

namespace ClipKart.Core.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
