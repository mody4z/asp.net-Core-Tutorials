using middleWare.customMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MycustomMiddlewarecs>();
var app = builder.Build();
// middleware 1
app.Use(async ( HttpContext context,RequestDelegate next) =>
{
    var query = context.Request.Query; 
    context.Response.ContentType = "text/html";

    await context.Response.WriteAsync($"Before 1st Middleware<br>{query["n"]}");
    await next(context);
   await context.Response.WriteAsync($"After 1st Middleware<br>{query["n2"]}");
});
app.UseMiddleware<MycustomMiddlewarecs>();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Before 2nd Middleware<br>");
   await next(context);
    Console.WriteLine("After 2nd Middleware");
});




app.Run( async(HttpContext context)=>{
    await Task.Delay(10000); // Wait for 10 seconds
    Console.WriteLine("gvgggggggggggggggggggggg");
 
await context.Response.WriteAsync("2nd middle ware");
});

app.Run();
  