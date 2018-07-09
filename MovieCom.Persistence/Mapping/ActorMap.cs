using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Entities;

namespace MovieCom.Persistence.Mapping
{
    public class ActorMap : EntityTypeConfiguration<Actor>
    {
        public ActorMap()
        {
            ToTable("Actors");
            HasKey(x => x.Id);
            HasMany(x => x.Movies)
                .WithMany(y => y.Actors);

            Property(x => x.Id)
                .IsRequired();
            Property(x => x.FirstName)
                .HasMaxLength(20)
                .IsRequired();
            Property(x => x.MiddleName)
                .HasMaxLength(20)
                .IsRequired();
            Property(x => x.LastName)
                .HasMaxLength(20)
                .IsRequired();
            Property(x => x.Bio)
                .HasMaxLength(1000)
                .IsRequired();
            Property(x => x.BirthDate)
                .IsRequired();
        }
    }
}
