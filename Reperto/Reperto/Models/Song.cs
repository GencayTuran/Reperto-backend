using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reperto.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Band { get; set; }
        public string Lyrics { get; set; } //link to resources txt files
        public string Mood { get; set; }

        public Repertoire Repertoire { get; set; }
        public int RepertoireId { get; set; }
    }
}
