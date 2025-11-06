using Microsoft.Extensions.Primitives;
using System.Runtime.Intrinsics.X86;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

 var config = builder.Configuration;
 
app.Run(async (HttpContext content) =>
{

    var query = content.Request.Query;

    if (content.Request.Query.ContainsKey("n1") && content.Request.Query.ContainsKey("n2") && content.Request.Query.ContainsKey("op"))
    {

        bool b1 = int.TryParse(query["n1"], out int x);
        bool b2 = int.TryParse(query["n2"], out int y);
        char op = query["op"].ToString().FirstOrDefault();
        bool b3 = op is '+' or '-' or '*' or '/';

        if (b1 &&b2 &&b3)
        {

 
            switch (op)
            {
                case '+':
                    await content.Response.WriteAsync((Convert.ToInt32(content.Request.Query["n1"]) +Convert.ToInt32(content.Request.Query["n2"])).ToString());
 
                    return;

                case '-':
                    await content.Response.WriteAsync((Convert.ToInt32(content.Request.Query["n1"]) - Convert.ToInt32(content.Request.Query["n2"])).ToString()); return;

                case '*':
                    await content.Response.WriteAsync((Convert.ToInt32(content.Request.Query["n1"]) *Convert.ToInt32(content.Request.Query["n2"])).ToString()); return;

                case '/':
                    await content.Response.WriteAsync((Convert.ToInt32(content.Request.Query["n1"]) /Convert.ToInt32(content.Request.Query["n2"])).ToString()); return;

                default:
                    await content.Response.WriteAsync("Invalid Operation");
                    return;
            }


        }
        else
        {
            content.Response.StatusCode = 400;

            if (b1) { await content.Response.WriteAsync("Invalid Input: n1 must be an integer."); return;
 }
            if (b2) { await content.Response.WriteAsync("Invalid Input: n2 must be an integer."); return;
            }
            if (b3) { await content.Response.WriteAsync("Invalid Input: op must be a valid operator."); return;
            }
        }

    }

});

app.Run();
