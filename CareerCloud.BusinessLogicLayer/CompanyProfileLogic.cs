﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository)
    : base(repository)
        {
        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            base.Update(pocos);
            {
                Verify(pocos);
                base.Update(pocos);
            }
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            {
                string[] arr = new string[] {".ca",".com",".biz"};
                foreach (CompanyProfilePoco poco in pocos)
                {
                    foreach(string s in arr)
                    {
                        if((string.IsNullOrEmpty(poco.CompanyWebsite)) || (!poco.CompanyWebsite.EndsWith(s)))
                            
                        exceptions.Add(new ValidationException(600, $"Valid websites must end with the following extensions – \".ca\" , \".com\", \".biz\" - {poco.Id}"));
                    }
                    if (string.IsNullOrEmpty(poco.ContactPhone))
                    {
                        exceptions.Add(new ValidationException(601, $"PhoneNumber for CompanyProfile is required - {poco.Id}"));
                    }
                    else
                    {
                        string[] phoneComponents = poco.ContactPhone.Split('-');
                        if (phoneComponents.Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                        }
                        else
                        {
                            if (phoneComponents[0].Length < 3)
                            {
                                exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                            }
                            else if (phoneComponents[1].Length < 3)
                            {
                                exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                            }
                            else if (phoneComponents[2].Length < 4)
                            {
                                exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number(e.g. 416-555-1234) - { poco.Id }"));
                            }
                        }
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
