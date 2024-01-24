using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exit3.Models
{
    public class Etiket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EtiketId { get; set; }
        public string EtiketName { get; set; }
    }
}
