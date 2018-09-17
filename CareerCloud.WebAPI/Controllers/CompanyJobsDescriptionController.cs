using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyJobsDescriptionController : ApiController
    {
        private CompanyJobDescriptionLogic _logic;

        public CompanyJobsDescriptionController()
        {
            var repo =
                new EFGenericRepository<CompanyJobDescriptionPoco>(false);

            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("jobsdescription/{companyJobsDescriptionId}")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]
        public IHttpActionResult GetCompanyJobsDescription(Guid companyJobsDescriptionId)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(companyJobsDescriptionId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("jobsdescription")]
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
        public IHttpActionResult GetAllCompanyJobsDescription()
        {
            List<CompanyJobDescriptionPoco> result = _logic.GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("jobsdescription")]
        public IHttpActionResult PostCompanyJobsDescription
            ([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobsdescription")]
        public IHttpActionResult PutCompanyJobsDescription
            ([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobsdescription")]
        public IHttpActionResult DeleteCompanyJobsDescription
            ([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }

}
