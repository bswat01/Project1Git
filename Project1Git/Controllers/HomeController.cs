﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project1Git.Models;

namespace Project1Git.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //JAXON KNOWS HOW TO USE GIT!!!
        //KEN TRIED
        //comment

        
        public ActionResult Index()
        {
            return View(); 
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult signUp()
        {
            //add ability to create account record in database with view
            //linked from login page (i.e. "Dont have an account? Sign up here")
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
                //login authentication from login view
                //authentication already added to web.config
                //should return to login view if not authenticated from any view
                return View();
            
        }
    }
}