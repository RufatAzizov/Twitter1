using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.AuthDtos;

namespace Twitter.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task Login(LoginDto dto);
    }
}
