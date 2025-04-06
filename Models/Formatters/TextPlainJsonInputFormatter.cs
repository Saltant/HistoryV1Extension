using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Text;

namespace HistoryV1Extension.Models.Formatters
{
    public class TextPlainJsonInputFormatter : TextInputFormatter
    {
        public TextPlainJsonInputFormatter()
        {
            SupportedMediaTypes.Add("text/plain");
            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            using var reader = new StreamReader(context.HttpContext.Request.Body, encoding);
            string content = await reader.ReadToEndAsync();
            return await InputFormatterResult.SuccessAsync(JsonConvert.DeserializeObject(content, context.ModelType));
        }
    }
}
