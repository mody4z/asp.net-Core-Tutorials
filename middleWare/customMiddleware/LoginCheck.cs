using Microsoft.Extensions.Primitives;

namespace middleWare.customMiddleware
{
  
    public class LoginCheck
    {
       
        private readonly RequestDelegate _next;
        public LoginCheck(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/" && context.Request.Method == "POST")
            {
                var form = await context.Request.ReadFormAsync();

                var username = form["username"];
                var password = form["password"];

                if (StringValues.IsNullOrEmpty(username))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'username'");
                    return;
                }

                if (  StringValues.IsNullOrEmpty(password))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password'");
                    return;                                                                     
                }
                 var usernameStr = username.ToString().Trim('"');
                var passwordStr = password.ToString().Trim('"');

                if (usernameStr == "admin" && passwordStr == "admin@123")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Successful login");
                    return;
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid login");
                    return;
                }
            }

        }

    }
}
