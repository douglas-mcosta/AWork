using AWork.Core.Data;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace AWork.Core.Messages
{
    public class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected void AddError(string type,string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(type, message));
        }

        protected async Task<ValidationResult> SaveChanges(IUnitOfWork unitOfWork)
        {
            var success = await unitOfWork.Commit();

            if (!success)
            {
                AddError("Houve um erro ao persistir os dados.");
            }

            return ValidationResult;
        }
    }
}
