using _8pos.Controllers.Model;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _8pos.Controllers.Api
{
    public class UserApiController : ApiController
    {
        // GET: api/PosUser
        public List<PosUser> Get()
        {
            return (List<PosUser>)new UserViewModel().get();
        }

        // GET: api/PosUser/5
        public PosUser Get(int id)
        {
            return new UserViewModel().getById(id);
        }

        // POST: api/PosUser
        public string Post([FromBody]PosUser PosUser)
        {
            string retValue = "PosUser Inserted Sucessfully!";

            try
            {
                new UserViewModel().insert(PosUser);
            }
            catch (Exception)
            {

                retValue = "Inserted PosUser Failed";

            }

            return retValue;
        }

        // PUT: api/PosUser/5
        public string Put([FromBody]PosUser PosUser)
        {
            string retValue = "Updated PosUser Sucessfully!";

            try
            {
                new UserViewModel().update(PosUser);
            }
            catch (Exception)
            {

                retValue = "Updated PosUser Failed";

            }

            return retValue;

        }

        // DELETE: api/PosUser/5
        public string Delete(int id)
        {
            string retValue = "Deleted PosUser Sucessfully!";
            try
            {
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.delete(userViewModel.getById(id));

            }
            catch (Exception)
            {
                retValue = "Deleted PosUser Failed!";
            }

            return retValue;

        }


    }
}
