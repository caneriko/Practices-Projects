﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookSaw.Web.Extensions
{
    public static class ModelStateExtension
    {
        public static void AddModelErrorList(this ModelStateDictionary modelState, List<string> errors)
        {
            errors.ForEach(x =>
            {
                modelState.AddModelError(string.Empty, x);
            });
        }
    }
}