using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SongsLibrary.Data
{
    public class MusicVideo
    {
        public MusicVideo() 
        {
            Artists = new List<Artist>();
            Genres = new List<Genre>();
        }
        public int Id { get; set; }
       public string Title { get; set; }
       public double Duration { get; set; }
       public DateTime ReleaseDate { get; set; }

        public virtual List<Artist> Artists { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist? Artist { get; set; }

        public virtual List<Genre> Genres { get; set; }
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
