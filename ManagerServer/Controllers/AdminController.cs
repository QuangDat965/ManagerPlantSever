﻿using Microsoft.AspNetCore.Mvc;

namespace ManagerServer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
