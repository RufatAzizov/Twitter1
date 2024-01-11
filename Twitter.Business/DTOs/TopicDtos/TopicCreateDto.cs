using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.AuthDtos;
using FluentValidation;


namespace Twitter.Business.DTOs.TopicDtos
{
    public class TopicCreateDto
    {
        public string Name { get; set; }
    }
    public class TopicCreateDtoValidator : FluentValidation.AbstractValidator<TopicCreateDto>
    {
        public TopicCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(32);
        }
    }
}
