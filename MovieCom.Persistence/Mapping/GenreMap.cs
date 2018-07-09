using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence.Mapping
{
    public class GenreMap : EntityTypeConfiguration<Genre>
    {
        public GenreMap()
        {
            ToTable("Genres");
            HasKey(x => x.Id);
            HasMany(x => x.Movies)
                .WithMany(y => y.Genres);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
