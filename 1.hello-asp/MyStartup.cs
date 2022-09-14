using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace hello_asp
{
    public class MyStartup
    {
        //Dang ky cac dich vu su dung
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton
        }
        //Xay dung pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseRouting();

            app.UseEndpoints(enpoints => {
                enpoints.MapGet("/", async (context) => {
                    string html = @"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset=""UTF-8"">
                        <title>Trang web đầu tiên</title>
                        <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                        <script src=""/js/jquery.min.js""></script>
                        <script src=""/js/popper.min.js""></script>
                        <script src=""/js/bootstrap.min.js""></script>


                    </head>
                    <body>
                        <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                                <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                                <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                        <span class=""navbar-toggler-icon""></span>
                                </button>
                                <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                                <ul class=""navbar-nav"">
                                    <li class=""nav-item active"">
                                        <a class=""nav-link"" href=""#"">Trang chủ</a>
                                    </li>
                                
                                    <li class=""nav-item"">
                                        <a class=""nav-link"" href=""#"">Học HTML</a>
                                    </li>
                                
                                    <li class=""nav-item"">
                                        <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                    </li>
                            </ul>
                            </div>
                        </nav> 
                        <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                    </body>
                    </html>
                ";
                    await context.Response.WriteAsync(html);
                });
                enpoints.MapGet("/about", async (context) => {
                    await context.Response.WriteAsync("Trang gioi thieu - map");
                });
            });
            //terminate middleware
            app.Map("/abc", app1 => {
                app1.Run( async (context) => {
                    await context.Response.WriteAsync("Day la route abc");
                });
            });

            app.UseStatusCodePages();
            // app.Run(async (context) => {
            //     await context.Response.WriteAsync("Xin chao, day la mystartup");
            // });

            
        }
    }
}