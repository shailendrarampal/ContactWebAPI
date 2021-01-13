using System;
using ContactWebAPI.DBOperation;
using ContactWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ContactWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
       
        //[Authorize()]
        [HttpGet]
        // GET: Contact
        public ActionResult<IList<ContactEntity>> Index()
        {

            return ContactDB.GetAllContact();
        }
      //  [Authorize()]
        [HttpGet("{mobileNumber}")]
        // GET: Contact/Details/7503385915
        public ActionResult<ContactEntity> Details(string mobileNumber)
        {
            
            return ContactDB.GetContactByMobile(mobileNumber);
        }
       // [Authorize()]
        [HttpGet("{email}",Name = "DetailEmail")]
        // GET: Contact/DetailEmail/srampal@gmail.com
        public ActionResult<ContactEntity> DetailsEmail(string email)
        {
            return ContactDB.GetContactByEmail(email);
        }

       // [Authorize()]
        [HttpPost]
        public ActionResult<string> Create([FromBody]ContactEntity detail)
        {
            if (!ModelState.IsValid)
                return JsonConvert.SerializeObject(
                    ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList(), Formatting.Indented);
            detail.ContactId=new Guid();
            ContactDB.CreateContact(detail);
            return "Save Successfully";
        }



       // [Authorize()]
        [HttpPut("{mobileNumber}")]
        public ActionResult<string> Edit(string mobileNumber, [FromBody] ContactEntity contactEntity)
        {
            if (!ModelState.IsValid)
                return JsonConvert.SerializeObject(
                    ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList(), Formatting.Indented);
            return ContactDB.UpdateContactByMobile(mobileNumber, contactEntity);

        }

       // [Authorize()]
        // GET: Contact/Delete/5
        [HttpPost("{mobileNumber}",Name = "DeleteContact")]
        public ActionResult<string> Delete(string mobileNumber)
        {
            return ContactDB.DeleteContactByMobile(mobileNumber);
        }

        
    }
}