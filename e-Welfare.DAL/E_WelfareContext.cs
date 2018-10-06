namespace e_Welfare.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using e_Welfare.DTO;
    using e_Welfare.DAL.Migrations;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class E_WelfareContext : DbContext
    {
        public E_WelfareContext()
            : base("name=E_WelfareContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<E_WelfareContext, Configuration>());
        }


        #region Master tables    
        public DbSet<UserType> UserTypes;
        public DbSet<UserStatus_Master> UserStatus_Masters;
        #endregion

        public DbSet<Users> Users { get; set; }
        public DbSet<Permissions> Permission { get; set; }
        public DbSet<DTO.Medicine> Medicine { get; set; }
        public DbSet<User_MedicineRelation> User_MedicineRelation { get; set; }
        public DbSet<User_EducationRelation> User_EducationRelation { get; set; }
        public DbSet<User_FoodRelation> User_FoodRelation { get; set; }
        public DbSet<User_TrainingRelation> User_TrainingRelation { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Training> Training { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Master tables
            modelBuilder.Entity<UserType>();
            modelBuilder.Entity<UserStatus_Master>();
            #endregion

            modelBuilder.Entity<Users>();
            modelBuilder.Entity<User_MedicineRelation>();
            modelBuilder.Entity<Permissions>();
            modelBuilder.Entity<DTO.Medicine>();

            modelBuilder.Entity<User_EducationRelation>();
            modelBuilder.Entity<User_FoodRelation>();
            modelBuilder.Entity<User_TrainingRelation>();
            modelBuilder.Entity<Food>();
            modelBuilder.Entity<Training>();
        }
    }
}
