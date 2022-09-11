using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reperto.Models
{
    public class ChordImage
    {
        public int ChordImageId { get; set; }
        public string ImageData { get; set; }
        public string ChordName { get; set; }
        public int ChordId { get; set; }
        public Chord Chord { get; set; }
    }
}
