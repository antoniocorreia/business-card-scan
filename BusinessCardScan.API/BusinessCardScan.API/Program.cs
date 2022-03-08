using BusinessCardScan.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/processcard",
    async Task<IResult> (HttpRequest request) =>
    {
        if (!request.HasFormContentType)
            return Results.BadRequest();

        var form = await request.ReadFormAsync();
        var formFile = form.Files["file"];

        if (formFile is null || formFile.Length == 0)
            return Results.BadRequest();

        await using var stream = formFile.OpenReadStream();

        BusinessCardRecognizer rec = new BusinessCardRecognizer(builder.Configuration);
        var businessCard = await rec.ProcessBusinessCardAsync(stream);
       
        return Results.Ok(businessCard);
    });

app.Run();
