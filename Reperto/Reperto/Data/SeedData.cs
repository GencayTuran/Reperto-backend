using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Reperto.Helpers;
using Reperto.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reperto.Data
{
    public class SeedData
    {
        public static RepertoDbContext context;
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            context =
                app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RepertoDbContext>();
            if (!context.Chords.Any())
            {
                context.Songs.AddRange(GetSongs());
                context.Chords.AddRange(GetChords());
                context.Repertoires.AddRange(GetRepertoires());
                context.Keys.AddRange(GetKeys());
                context.SaveChanges();
            }
            if (!context.ChordImages.Any())
            {
                context.ChordImages.AddRange(GetChordImages());
                context.SaveChanges();
            }
        }
        private static Song[] GetSongs()
        {
            var songs = new Song[3];
            songs[0] = new Song
            {
                Title = "Seni kendime sakladim",
                Band = "Duman",
                Mood = "Rock",
                RepertoireId = 1,
                KeyId = 1
            };
            songs[1] = new Song
            {
                Title = "Elimdeki saz yeter canima",
                Band = "Duman",
                Mood = "Rock",
                RepertoireId = 1,
                KeyId = 1
            };
            songs[2] = new Song
            {
                Title = "Melek",
                Band = "Duman",
                Mood = "Rock",
                RepertoireId = 1,
                KeyId = 1
            };

            string lyricData;
            int index = 0;
            var files = Directory.GetFiles("D:/Projects/Reperto/Backend/Reperto/Reperto/wwwroot/assets/songs/");
            foreach (var lyric in files)
            {
                lyricData = FileHelper.FileToText(lyric);
                songs[index].Lyrics = lyricData;
                index++;
            }

            return songs;
        }

        public static string[] ChordNames =
        {
                "A","Am","A#","A#m","B","Bm",
                "C","Cm","C#","C#m","D","Dm",
                "D#","D#m","E","Em","F","Fm",
                "F#", "F#m", "G","Gm","G#","G#m",
                "Fmaj7C"
        };

        private static Chord[] GetChords()
        {
            int index = 0;
            var chords = new Chord[ChordNames.Length];

            do
            {
                chords[index] = new Chord { ChordName = ChordNames[index] };
                index++;
            } while (index != ChordNames.Length);

            return chords;
        }

        private static ChordImage[] GetChordImages()
        {
            var files = Directory.GetFiles("D:/Projects/Reperto/Backend/Reperto/Reperto/wwwroot/assets/chords/");
            string svgData, fileName, chord;
            int chordId; 
            List<ChordImage> chordImages = new List<ChordImage>();
            foreach (var svg in files)
            {
                svgData = FileHelper.FileToText(svg);
                fileName = svg.Substring(66);
                chord = fileName.Contains("-") ? fileName.Substring(0, fileName.Length - 6) : fileName.Substring(0, fileName.Length - 4);

                foreach (var chordName in ChordNames)
                {
                    if (chord == chordName)
                    {
                        chordId = context.Chords.SingleOrDefault(c => c.ChordName == chordName).ChordId;
                        chordImages.Add(new ChordImage { ImageData = svgData, ChordName = chordName, ChordId = chordId });
                    }
                }
            }            
            return chordImages.ToArray();
        }

        private static Repertoire[] GetRepertoires()
        {
            var repertoires = new Repertoire[1];
            repertoires[0] = new Repertoire
            {
                Name = "Rock repertoire"
            };
            return repertoires;
        }

        private static Key[] GetKeys()
        {
            var keys = new Key[1];
            keys[0] = new Key
            {
                Name = "E"
            };
            return keys;
        }
    }
}
