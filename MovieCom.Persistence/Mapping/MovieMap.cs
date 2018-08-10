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
            
            HasMany(x => x.Actors)
                .WithMany(y => y.Movies);
            HasMany(x => x.Media);
            HasMany(x => x.Genres)
                .WithMany(y => y.Movies);
            HasMany(x => x.Comments)
                .WithOptional(y => y.Movie);
            HasMany(x => x.Grades);

            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            Property(x => x.Slogan)
                .HasMaxLength(150);

            Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            Property(x => x.Year)
                .IsRequired();

            Property(x => x.Imdb)
                .HasPrecision(3, 1);
            
            Property(x => x.Rating)
                .HasPrecision(3, 1);
            
        }
    }
}
