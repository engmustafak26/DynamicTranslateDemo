using DynamicTranslate;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DynamicTranslateDemo.Filters
{
    public class TranslationResultFilter : ResultFilterAttribute, IResultFilter
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await (context.Result as Microsoft.AspNetCore.Mvc.ObjectResult)?.Value.Translate(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            await base.OnResultExecutionAsync(context, next);
        }


    }
}