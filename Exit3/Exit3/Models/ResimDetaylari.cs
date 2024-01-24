using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exit3.Models
{
    public class ResimDetaylari
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResimDetaylariId { get; set; }

        public string ResimAciklama { get; set; }

        public DateTime ResimDate { get; set; }

        public int EtiketId { get; set; }

        [ForeignKey("EtiketId")]
        public Etiket Etiket { get; set; }

        // Add a navigation property to Resim
        public virtual Resim Resim { get; set; }
    }
}
