using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exit3.Models
{
    public class Begeni
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BegeniId { get; set; }
        public int BegeniSayisi { get; set; }
        public int BegenmemeSayisi { get; set; }
        public int ResimId { get; set; }
        [ForeignKey("ResimId")]
        public Resim Resim { get; set; }
    }
}
