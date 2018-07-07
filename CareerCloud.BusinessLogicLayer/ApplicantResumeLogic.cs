﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
    {
        public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository)
            : base(repository)
        {
        }
        public override void Add(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantResumePoco[] pocos)
        {
            base.Update(pocos);
            {
                Verify(pocos);
                base.Update(pocos);
            }
        }

        protected override void Verify(ApplicantResumePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            {
                foreach (ApplicantResumePoco poco in pocos)
                {
                    if (string.IsNullOrEmpty(poco.Resume)) 
                    {
                        exceptions.Add(new ValidationException(113, $"Resume cannot be empty - {poco.Id}"));
                    }
                   
                }
                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }

}
