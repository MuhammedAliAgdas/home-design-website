using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exit3.Models
{
    public class Paylasim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaylasimId { get; set; } // Örnek birincil anahtar
        
        public int ResimId { get; set; }
        [ForeignKey("ResimId")]
        public Resim Resim { get; set; }

        public int KullaniciId { get; set; }
        [ForeignKey("KullaniciId")]
        public Kullanici Kullanici { get; set; }
    }
}
