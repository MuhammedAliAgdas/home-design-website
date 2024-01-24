using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exit3.Models
{
    public class Yorumlar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YorumId { get; set; }
        public string Yorum { get; set; }
        public int ResimId { get; set; }
        [ForeignKey("ResimId")]
        public Resim Resim { get; set; }

    }
}
    