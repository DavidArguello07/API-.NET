public class TimeMiddlewares
{
    readonly RequestDelegate next;
    //Poder invocar al middleware que sigue dentro del ciclo
    //Nos permite hacer el llamado al siguiente middleware

    public TimeMiddlewares(RequestDelegate nextRequest)
    {
        next = nextRequest;
        //asigna lo que llega dentro del constructor a la variable next
        //La informacion necesaria para hacer el llamado al siguiente middleware
    }

    public async Task Invoke(HttpContext context)
    //Recibe el contexto de la peticion, toda la informacion del request
    {
        await next(context);
        //llamado del siguiente middleware

        if (context.Request.Query.Any(p=>p.Key == "time"))
        //evalua si dentro del query string viene el parametro time
        {
            await context.Response.WriteAsync($"La hora actual es: {DateTime.Now.ToShortTimeString()}");
        }
    }

}
public static class TimeMiddlewareExtensions
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddlewares>();
    }
}