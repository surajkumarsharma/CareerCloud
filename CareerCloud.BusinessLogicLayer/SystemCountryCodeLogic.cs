﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemCountryCodeLogic : SystemCountryCodePoco
    {
     protected IDataRepository<SystemCountryCodePoco> _repository;
            public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
            {
                _repository = repository;
            }

        public virtual SystemCountryCodePoco Get(string code)
        {
            return _repository.GetSingle(c => c.Code == code);
        }

        public virtual List<SystemCountryCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual void Add(SystemCountryCodePoco[] pocos)
            {
                Verify(pocos);
                _repository.Add(pocos);
            }

            public virtual void Update(SystemCountryCodePoco[] pocos)
            {
                    Verify(pocos);
                    _repository.Update(pocos);
            }

            public void Delete(SystemCountryCodePoco[] pocos)
            {
                _repository.Remove(pocos);
            }


        protected virtual void Verify(SystemCountryCodePoco[] pocos)
            {
                List<ValidationException> exceptions = new List<ValidationException>();
                {
                    foreach (SystemCountryCodePoco poco in pocos)
                    {
                        if (string.IsNullOrEmpty(poco.Code))
                        {
                            exceptions.Add(new ValidationException(900, $"Cannot be empty - {poco.Code}"));
                        }
                        if (string.IsNullOrEmpty(poco.Name))
                        {
                            exceptions.Add(new ValidationException(901, $"Cannot be empty - {poco.Code}"));
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

