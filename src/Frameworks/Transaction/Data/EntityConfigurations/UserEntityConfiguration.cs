namespace Transaction.Framework.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Transaction.Framework.Data.Entities;

    public static class UserEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Fname).IsRequired(); 
            entityBuilder.Property(t => t.Lname).IsRequired(); 
            entityBuilder.Property(t => t.Email).IsRequired(); 
            entityBuilder.Property(t => t.Username).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
        }
    }
}
