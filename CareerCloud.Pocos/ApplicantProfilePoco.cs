using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profile")]
    public class ApplicantProfilePoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }
        [Column("Current_Salary")]
        public decimal CurrentSalary { get; set; }
        [Column("Current_Rate")]
        public decimal CurrentRate { get; set; }
        public char[] Currency { get; set; }
        [Key]
        public Guid CountryCode { get; set; }
        [Column("State_Province_Code")]
        public char[] StateProvinceCode { get; set; }
        [Column("Street_Address")]
        public string StreetAddress { get; set; }
        [Column("City_Town")]
        public string CityTown { get; set; }
        [Column("Zip_Postal_Code")]
        public char[] ZipPostalCode { get; set; }
        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }


    }
}
