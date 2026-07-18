using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder
            .HasOne(t => t.TeamLeader)
            .WithMany()
            .HasForeignKey(t => t.TeamLeaderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}