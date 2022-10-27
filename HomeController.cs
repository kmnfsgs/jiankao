using Realyoung.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;
using System.Collections.Generic;
using jiankao2.UserData;
using Microsoft.AspNetCore.Authorization;

namespace jiankao2.Controllers
{
   // [Authorize(Policy = "User")] //表示当前的控制器要授权才能访问
    public class HomeController : WebApiController
    {
        private readonly AppDbcontext dbcontext;

        public HomeController(AppDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<string> Index()
        {
            return await Task.FromResult("hello world");
        }



    }
}