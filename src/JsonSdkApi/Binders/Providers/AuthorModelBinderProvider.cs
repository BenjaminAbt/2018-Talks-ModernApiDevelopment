using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace BenjaminAbt.ModernAPIDevelopment.JsonSdkApi.Binders.Providers
{
    public class AuthorModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }


            if (context.Metadata.ModelType == typeof(AuthorId))
            {
                return new BinderTypeModelBinder(typeof(AuthorIdModelBinder));
            }
            else if (context.Metadata.ModelType == typeof(Author))
            {
                return new BinderTypeModelBinder(typeof(AuthorModelBinder));
            }
            else
            {
                return null;
            }
        }
    }
}

