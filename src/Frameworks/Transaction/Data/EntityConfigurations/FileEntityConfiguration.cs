namespace Transaction.Framework.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Transaction.Framework.Data.Entities;

    public static class FileEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<File> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FileName).IsRequired(); 
            entityBuilder.Property(t => t.FilePath).IsRequired();
            entityBuilder.Property(t => t.UserId).IsRequired();
            entityBuilder.HasOne(u => u.User).WithMany(e => e.Files).HasForeignKey(u => u.UserId);

        }
    }
}
