using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.MVC.Filters
{
    public class WriteResponseHeader : ResultFilterAttribute
    {
        private readonly string _name = "Name";
        private readonly string _value = "Darshit";

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(_name, new string[] { _value });
            base.OnResultExecuting(context);
        }
    }
}
