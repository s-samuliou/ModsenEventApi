using EventsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsApi.DataAccess.EntityConfiguration
{
    class EventConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.Property(f => f.Name);
            builder.Property(f => f.Description).HasMaxLength(255);
            builder.Property(f => f.Plan).HasMaxLength(255);
            builder.Property(f => f.Organizer).HasMaxLength(255);
            builder.Property(f => f.Speaker).HasMaxLength(255);
            builder.Property(f => f.EventTime).IsRequired();
            builder.Property(f => f.EventPlace).HasMaxLength(255);
        }
    }
}