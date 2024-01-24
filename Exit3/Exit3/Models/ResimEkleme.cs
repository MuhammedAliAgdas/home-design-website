using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exit3.Models
{
    public class ResimEkleme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResimId { get; set; }
        public IFormFile ResimUrl { get; set; }
        public int ResimDetaylariId { get; set; }
        [ForeignKey("ResimDetaylariId")]
        public ResimDetaylari ResimDetaylari { get; set; }
    }
}
