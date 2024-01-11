using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.AuthDtos;
using Twitter.Business.Exceptions.Common;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
//    public class AuthService : IAuthService
//    {
//        UserManager<AppUser> _userManager { get; }
//        public AuthService(UserManager<AppUser> userManager)
//        {
//            _userManager = userManager;
//        }

//        public async Task<TokenDto> Login(LoginDto dto, TokenDto token)
//        {
//            AppUser user = null;
//            if (dto.UserNameorEmail.Contains("@"))
//            {
//                user = await _userManager.FindByEmailAsync(dto.UserNameorEmail);
//            }
//            else
//            {    
//                user = await _userManager.FindByNameAsync(dto.UserNameorEmail);
//            }
//            if (user == null)
//            {
//                throw new NotFoundException<AppUser>();
//            }
//            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
//            if (!result) 
//            {
//                throw new NotFoundException<AppUser>(); 
//            }
//            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
//            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
//            var tokenOptions = new JwtSecurityToken(
//                issuer: "http://localhost:5138/",
//                audience: "http://localhost:5138/api",
//                claims: new List<Claim>(),
//                expires: DateTime.Now.AddMinutes(5),
//                signingCredentials: signinCredentials
//            );
//            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
//            var token = jwtHandler.WriteToken(tokenOptions);
//            return token;
//        }

//        Task IAuthService.Login(LoginDto dto)
//        {
//            throw new NotImplementedException();
//        }
//    //}
}
