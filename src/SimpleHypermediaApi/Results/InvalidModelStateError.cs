using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// See <see cref="InvalidModelStateResult"/>
    /// </summary>
    public class InvalidModelStateResult : HypermediaResult
    {
        /// <summary>
        /// Invalid model state
        /// </summary>
        public ModelStateDictionary ModelState { get; }

        /// <summary>
        /// Creates a new instance of <see cref="InvalidModelStateResult"/>
        /// </summary>
        /// <param name="modelState">Invalid model state</param>
        public InvalidModelStateResult(ModelStateDictionary modelState)
        {
            ModelState = modelState ?? throw new ArgumentNullException(nameof(modelState));
        }
    }
}