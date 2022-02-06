using RedeConcessionarias.Log;

void IniciaWebApi(){
    try{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
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

bool ConfiguraSalarioMinimo(){
    System.Console.WriteLine("Fará a configuração");
    return true;
}

int MenuInicial(){
    System.Console.WriteLine("Bem vindo ao Sistema de Gestão de Concessionárias!\nO que gostaria de fazer?\n[1] Carregar a API\n[2] Configurar o salário mínimo\n[3] Sair");
    var resposta = Convert.ToInt32(Console.ReadLine());
    if (resposta == 1){
        IniciaWebApi();
        return 0;
    }
    else if(resposta == 2){
        if (ConfiguraSalarioMinimo()){
            MenuInicial();
        }
        return 1;
    }
    else if(resposta == 3){
        return 0;
    }
    else{
        System.Console.WriteLine("Oção não encontrada");
        MenuInicial();
        return 0;
    }
}

try{
    MenuInicial();
}
catch(Exception ex){
    Logger.AdicionaLog(ex.Message,4,"","Erro ao iniciar o menu de opções");
}






