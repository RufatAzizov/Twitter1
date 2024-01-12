using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Core.Entities;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDay { get; set; }
    public IEnumerable<Blog> Posts { get; set; }
}