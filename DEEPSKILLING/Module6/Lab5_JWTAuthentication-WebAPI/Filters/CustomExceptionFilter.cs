using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebAPI.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string filePath = @"C:\Temp\ExceptionLog.txt";

            Directory.CreateDirectory(@"C:\Temp");

            File.AppendAllText(
                filePath,
                $"[{DateTime.Now}] {context.Exception.Message}{Environment.NewLine}"
            );

            context.Result = new ObjectResult("Internal Server Error")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}