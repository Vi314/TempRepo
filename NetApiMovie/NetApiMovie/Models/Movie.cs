using System.ComponentModel.DataAnnotations;

namespace NetApiMovie.Models
{
    public class Movie
    {


        public int Id { get; set; }
        [Required(ErrorMessage ="Film adı boş geçilemez!")]
        [MaxLength(255,ErrorMessage ="max 255 karakter girilmeli")]

        public string Title { get; set; }
        [Required(ErrorMessage ="Tür boş geçilemez")]
        [MaxLength(255,ErrorMessage = "max 255 karakter girilmeli")]
        public string Genre { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        public int Rank { get; set; }



    }
}
