﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    public class SecurityLoginRolePoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Login { get; set; }

        public Guid Role { get; set; }

        [Column("Time_Stamp")]
        public byte[] Time_Stamp { get; set; }

    }
}
