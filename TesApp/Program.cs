using System.Net.Mime;
using System.Text;

namespace TesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", (HttpContext context) =>
            {
                string html = @"
                                <html>
                                    <body>
                                        <h1>HelloWorld</h1>
                                        <br/>
                                        Welcome to this world!
                                    </body>
                                 </html>
                              ";
                WriteHtml(context, html);
            });

            app.Run();

            void WriteHtml(HttpContext context, string html)
            {
                context.Response.ContentType = MediaTypeNames.Text.Html;
                context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
                context.Response.WriteAsync(html);
            }
        }
    }
}
