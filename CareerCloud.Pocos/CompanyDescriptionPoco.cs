using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Company{get; set;}

        public Guid LanguageId { get; set; }

    }
}
