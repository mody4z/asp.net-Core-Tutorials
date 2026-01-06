namespace middleWare.customMiddleware
{
    public static class Extension
    {
     public static IApplicationBuilder UseMycustomMiddlewarecs(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MycustomMiddlewarecs>();
        }
        public static IApplicationBuilder UseLoginCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginCheck>();
        }
    }
}
