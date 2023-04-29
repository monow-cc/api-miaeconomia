using Api_Mercado.Middlewares;
using Api_Mercado.Program;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddInjections();
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.DbConnectorSetup(builder.Configuration);
builder.Services.AddCorsPolicy();
builder.Services.AddSwagger();


var app = builder.Build();
app.UseMiddleware(typeof(ErrorHandlerMiddleware));
app.UseMiddleware(typeof(AuthenticatorMiddleware));
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");


app.MapControllers();

app.Run();
