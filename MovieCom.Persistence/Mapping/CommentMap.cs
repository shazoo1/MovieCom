using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            ToTable("Comments");
            HasKey(x => x.Id);
            HasOptional(x => x.Movie)
                .WithMany(y => y.Comments);
            HasRequired(x => x.User)
                .WithMany(y => y.Comments);
            HasOptional(x => x.ReplyTo)
                .WithMany(y => y.Replies);
            HasMany(x => x.Replies)
                .WithOptional(y => y.ReplyTo);

            Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(500);
            Property(x => x.CreatedAt)
                .IsRequired();
            Property(x => x.LastModifiedAt)
                .IsOptional();
        }
    }
}
