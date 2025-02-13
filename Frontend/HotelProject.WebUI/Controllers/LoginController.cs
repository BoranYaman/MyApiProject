﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult LoginIndex()
        {

            return View();
        }

        [HttpPost]
        public async Task <IActionResult> LoginIndex(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("StaffIndex", "Staff");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
