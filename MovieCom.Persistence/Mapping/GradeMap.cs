using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCom.Domain.Models.Entities;

namespace MovieCom.Persistence.Mapping
{
    public class GradeMap : EntityTypeConfiguration<Grade>
    {
        public GradeMap()
        {
            ToTable("Grades");
            HasKey(x => x.Id);
            HasRequired(x => x.User);

            //Constraint?
            Property(x => x.Value)
                .IsRequired();
        }
    }
}
