using System.ComponentModel.DataAnnotations;

namespace SongsLibrary.Data
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string GenreTitle { get; set; }
    }
}
