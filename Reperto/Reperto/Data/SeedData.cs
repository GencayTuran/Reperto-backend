using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Reperto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reperto.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            RepertoDbContext context =
                app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RepertoDbContext>();
            if (!context.Songs.Any())
            {
                context.Songs.AddRange(GetSongs());
                context.Chords.AddRange(GetChords());
                context.Repertoires.AddRange(GetRepertoires());
                context.Keys.AddRange(GetKeys());

                context.SaveChanges();
            }

            //if (!context.Chords.Any())
            //{
            //    context.Chords.AddRange(GetChords());
            //}
            //if (!context.Repertoires.Any())
            //{
            //    context.Repertoires.AddRange(GetRepertoires());
            //}
        }
        private static Song[] GetSongs()
        {
            //TODO: add index to Lyrics URL when creating (0 = songs[0])
            var songs = new Song[3];
            songs[0] = new Song
            {
                Title = "Seni kendime sakladim",
                Band = "Duman",
                Lyrics = "assets/songs/0.txt",
                Mood = "Rock",
                RepertoireId = 1,
                KeyId = 1
            };
            songs[1] = new Song
            {
                Title = "Elimdeki saz yeter canima",
                Band = "Duman",
                Lyrics = "assets/songs/1.txt",
                Mood = "Rock",
                RepertoireId = 1,
                KeyId = 1
            };
            songs[2] = new Song
            {
                Title = "Melek",
                Band = "Duman",
                Lyrics = "assets/songs/2.txt",
                Mood = "Rock",
                RepertoireId = 1,
                KeyId = 1
            };
            return songs;
        }
        private static Chord[] GetChords()
        {
            var chords = new Chord[3];
            chords[0] = new Chord
            {
                Name = "Am",
                Image = "assets/chords/Am.svg"
            };
            chords[1] = new Chord
            {
                Name = "Em",
                Image = "assets/chords/Em.svg"
            };
            chords[2] = new Chord
            {
                Name = "D",
                Image = "assets/chords/D.svg"
            };
            return chords;
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
