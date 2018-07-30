﻿using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {


        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles  { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes  { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories  { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions  { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions  { get; set; }
        public DbSet<CompanyJobEducationPoco> companyJobEducations  { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs  { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills  { get; set; }
        public DbSet<CompanyLocationPoco> companyLocations  { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles  { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs  { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins  { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles  { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles  { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes  { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes  { get; set; }


public CareerCloudContext() : base("HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }
    }
}
