using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exit3.Models
{
    public class Kullanici
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public DateTime DogumTarih { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public bool Cinsiyet { get; set; }
        public virtual ICollection<Paylasim> Paylasimlar { get; set; }  
    }
}
