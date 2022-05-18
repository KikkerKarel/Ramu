using Ramu.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/user", (Func<User>)(() =>
{
    return new User
    {
        UserId = "1",
        UserName = "Richard"
    };
}));

app.Run();
