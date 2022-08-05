﻿using Microsoft.AspNetCore.Builder;
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
                context.SaveChanges();
            }
            if (!context.Chords.Any())
            {
                context.Chords.AddRange(GetChords());
                context.SaveChanges();
            }
            if (!context.Repertoires.Any())
            {
                context.Repertoires.AddRange(GetRepertoires());
                context.SaveChanges();
            }
        }
        private static Song[] GetSongs()
        {
            //TODO: add index to Lyrics URL when creating (0 = songs[0])
            var songs = new Song[3];
            songs[0] = new Song
            {
                Title = "Seni kendime sakladim",
                Band = "Duman",
                Lyrics = "wwwroot/assets/songs/0",
                Mood = "Rock",
                RepertoireId = 1
            };
            songs[1] = new Song
            {
                Title = "Elimdeki saz yeter canima",
                Band = "Duman",
                Lyrics = "wwwroot/assets/songs/1",
                Mood = "Rock",
                RepertoireId = 1
            };
            songs[2] = new Song
            {
                Title = "Melek",
                Band = "Duman",
                Lyrics = "wwwroot/assets/songs/2",
                Mood = "Rock",
                RepertoireId = 1
            };
            return songs;
        }
        private static Chord[] GetChords()
        {
            var chords = new Chord[2];
            chords[0] = new Chord
            {
                Name = "Am",
                Image = $"wwwroot/assets/chords/Am.svg"
            };
            chords[1] = new Chord
            {
                Name = "Em",
                Image = "wwwroot/assets/chords/Em.svg"
            };
            chords[2] = new Chord
            {
                Name = "D",
                Image = "wwwroot/assets/chords/D.svg"
            };
            return chords;
        }
        private static Repertoire[] GetRepertoires()
        { 
            var repertoires = new Repertoire[0];
            repertoires[0] = new Repertoire
            {
            Name = "Rock repertoire"
            };
            return repertoires;
            }


     
    }
}