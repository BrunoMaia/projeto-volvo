using RedeConcessionarias.Log;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Globalization;
using RedeConcessionarias.configurador;

class Program{
    static void Main(string[] args) {  
        var arquivo = @".\config.json";
        if ((args.Length > 0) && (args[0] == "config")){
            System.Console.WriteLine("Entrando no modo de configuração\n--------------------------------\n");
            if (Config.DefineSalario(arquivo)){
                System.Console.WriteLine("Configuração Feita!\n--------------------------------\n");
            }
        }
            
    try{
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers().AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
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
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
        }
        catch(Exception ex){
        Logger.AdicionaLog(ex.Message,4,"IniciaWebApi","Erro ao criar builder do WebApi");
        }
    }
}








