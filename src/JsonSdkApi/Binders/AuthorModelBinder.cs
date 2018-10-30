using System;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Binders
{
    public class AuthorModelBinder : IModelBinder
    {
        private readonly IMediator _mediator;

        public AuthorModelBinder(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // Specify a default argument name if none is set by ModelBinderAttribute
            string modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            ValueProviderResult valueProviderResult =
                bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(modelName,
                    valueProviderResult);

                string value = valueProviderResult.FirstValue;

                // Check if the argument value is null or empty
                if (!string.IsNullOrEmpty(value))
                {
                    if (!Guid.TryParse(value, out Guid id))
                    {
                        bindingContext.ModelState.TryAddModelError(modelName,
                            "Author Id must be a Guid.");
                    }
                    else
                    {
                        Author result = await _mediator.Send(new GetAuthorByIdQuery(id));
                        bindingContext.Result = ModelBindingResult.Success(result);
                    }
                }
            }

        }
    }
}