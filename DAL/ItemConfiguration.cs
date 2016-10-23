using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            HasKey(item => item.ItemID);
            Property(item => item.ItemID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.Quantity).IsRequired();
            Property(item => item.CustomerID).IsRequired();
            
            Ignore(item => item.Id);
            ToTable("Items");

            HasRequired(i => i.Product).WithMany(p => p.Items)
                .HasForeignKey(f => f.ProductID).WillCascadeOnDelete(false);
        }
    }
}
