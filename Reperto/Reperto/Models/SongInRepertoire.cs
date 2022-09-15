using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reperto.Models
{
    public class SongInRepertoire
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int RepertoireId { get; set; }
        public Song Song { get; set; }
        public Repertoire Repertoire { get; set; }
    }
}
