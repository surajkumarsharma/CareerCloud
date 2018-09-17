using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {
        public CareerCloudContext(bool createProxy = true) :
            base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {
            Configuration.ProxyCreationEnabled = createProxy;
            //Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyDescriptionPoco>().Ignore(n => n.SystemLanguageCodes);

            modelBuilder.Entity<ApplicantEducationPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<ApplicantJobApplicationPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<ApplicantProfilePoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<ApplicantSkillPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<ApplicantWorkHistoryPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<CompanyDescriptionPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<CompanyJobEducationPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<CompanyJobSkillPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<CompanyJobPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<CompanyJobDescriptionPoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<CompanyLocationPoco>().Property(n => n.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyLocationPoco>().Property(n => n.Province).HasMaxLength(10).IsFixedLength();
            modelBuilder.Entity<CompanyLocationPoco>().Property(n => n.PostalCode).HasMaxLength(20).IsFixedLength();

            modelBuilder.Entity<CompanyProfilePoco>().Property(n => n.TimeStamp).IsRowVersion();
            modelBuilder.Entity<CompanyProfilePoco>().HasKey(n => n.Id);

            modelBuilder.Entity<SecurityLoginPoco>().Property(n => n.TimeStamp).IsRowVersion();
            modelBuilder.Entity<SecurityLoginsRolePoco>().Property(n => n.TimeStamp).IsRowVersion();

            modelBuilder.Entity<SystemCountryCodePoco>().HasKey(n => n.Code);
            modelBuilder.Entity<SystemLanguageCodePoco>().HasKey(n => n.LanguageID);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

    }
}
