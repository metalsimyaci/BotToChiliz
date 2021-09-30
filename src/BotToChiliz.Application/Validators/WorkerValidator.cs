using BotToChiliz.Domain.Data.Entity;
using FluentValidation;

namespace BotToChiliz.Domain.Validators
{
    public class WorkerValidator:AbstractValidator<Worker>
    {
        public WorkerValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().WithMessage("Bot İsimi boş olamaz");
            RuleFor(r => r.Name).MaximumLength(128).WithMessage("Bot ismi en fazla 128 karakter olabilir");
            RuleFor(r => r.Type).NotEmpty().IsInEnum();
        }
    }
}
