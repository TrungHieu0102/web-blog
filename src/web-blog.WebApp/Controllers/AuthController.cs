﻿using Microsoft.AspNetCore.Authorization;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_blog.Core.Events.LoginSuccessed;
using web_blog.Core.Events.RegisterSuccessed;
using web_blog.Core.Domain.Identity;
using web_blog.Core.SeedWorks.Constants;
using web_blog.WebApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static web_blog.Core.SeedWorks.Constants.Permissions;

namespace web_blog.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMediator _mediator;
        public AuthController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegsiterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userManager.CreateAsync(new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            }, model.Password);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                await _signInManager.SignInAsync(user, true);
                await _mediator.Publish(new RegisterSuccessedEvent(model.Email));
                return Redirect(UrlConsts.Profile);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email not found!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                await _mediator.Publish(new LoginSuccessedEvent(model.Email));

                return Redirect(UrlConsts.Profile);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login failed");
            }
            return View();
        }
    }
}