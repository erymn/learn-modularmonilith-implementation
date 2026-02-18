using FastEndpoints;
using HazPro.HR.Endpoints;
using HazPro.HR.Extensions;
using HazPro.Marketing.Endpoints;
using HazPro.Marketing.Extensions;
using HazPro.Payroll.Endpoints;
using HazPro.Payroll.Extensions;

var builder = WebApplication.CreateBuilder(args);

//register FastEnpoints
builder.Services.AddFastEndpoints();

//Register Module into Host App
builder.Services.AddHRServices(builder.Configuration);
builder.Services.AddMarketingServices();
builder.Services.AddPayrollServices();

var app = builder.Build();

//Map EndPoints
app.MapFastEndpoints();

//Map the endpoints for each modules into Host App
// app.MapHREndpoints();
app.MapMarketingEndpoints();
app.MapPayrollEndpoints();

app.Run();
