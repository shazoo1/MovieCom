using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence.Mapping
{
    public class MediaMap : EntityTypeConfiguration<Media>
    {
        public MediaMap()
        {
            ToTable("Media");
            HasKey(x => x.Id);
            HasRequired(x => x.Movie);

            Property(x => x.Link)
                .IsRequired();
            Property(x => x.Type)
                .IsRequired();
        }
    }
}
