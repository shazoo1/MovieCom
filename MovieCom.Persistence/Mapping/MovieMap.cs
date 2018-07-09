using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence.Mapping
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            ToTable("Movies");
            HasKey(x => x.Id);

            HasOptional(x => x.Poster);
            HasMany(x => x.Actors)
                .WithMany(y => y.Movies);
            HasMany(x => x.Media);
            HasMany(x => x.Genres)
                .WithMany(y => y.Movies);
            HasMany(x => x.Comments)
                .WithOptional(y => y.Movie);
            HasMany(x => x.Grades);

            Property(x => x.Slogan)
                .IsRequired()
                .HasMaxLength(150);

            Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            //Constraints?
            Property(x => x.Year)
                .IsRequired();

            //Max/min values constraints?
            Property(x => x.Imdb)
                .HasPrecision(3, 1);

            //Max/min values constraints?
            Property(x => x.Rating)
                .HasPrecision(3, 1);
        }
    }
}
