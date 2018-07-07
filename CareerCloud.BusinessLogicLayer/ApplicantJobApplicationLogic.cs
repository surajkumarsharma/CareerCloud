﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
    {
        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository)
            : base(repository)
        {
        }
        public override void Add(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            base.Update(pocos);
            {
                Verify(pocos);
                base.Update(pocos);
            }
        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            {
               // base.Verify(pocos);

                foreach (ApplicantJobApplicationPoco poco in pocos)
                {
                    if (poco.ApplicationDate > DateTime.Now)
                    {
                        exceptions.Add(new ValidationException(110, $"ApplicationDate cannot be greater than today - {poco.Id}"));
                    }
                }
            }
        }
    }
}
