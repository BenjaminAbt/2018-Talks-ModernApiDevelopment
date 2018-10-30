using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Binders
{
    //[ModelBinder(BinderType = typeof(AuthorIdModelBinder))]
    public class AuthorId
    {
        public AuthorId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get;  }
    }

    public class AuthorIdModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // Specify a default argument name if none is set by ModelBinderAttribute
            string modelName = bindingContext.BinderModelName;
            if (string.IsNullOrEmpty(modelName))
            {
                modelName = "id";
            }

            // Try to fetch the value of the argument by name
            ValueProviderResult valueProviderResult =
                bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName,
                valueProviderResult);

            string value = valueProviderResult.FirstValue;

            // Check if the argument value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            if (!Guid.TryParse(value, out Guid id))
            {
                bindingContext.ModelState.TryAddModelError(modelName, "Author Id must be a Guid.");
                return Task.CompletedTask;
            }

            AuthorId authorId = new AuthorId(id);

            bindingContext.Result = ModelBindingResult.Success(authorId);
            return Task.CompletedTask;
        }
    }


}