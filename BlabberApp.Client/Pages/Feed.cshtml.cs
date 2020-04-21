using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlabberApp.Services;

namespace BlabberApp.Client
{
    public class FeedModel : PageModel
    {
        private readonly IBlabService _service;
        public FeedModel(IBlabService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            // ArrayList blabs = _service.
        }
        public void OnPost()
        {
            var user = Request.Form["emailaddress"];
            var blab = Request.Form["message"];
            try
            {
                _service.AddBlab(blab, user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
