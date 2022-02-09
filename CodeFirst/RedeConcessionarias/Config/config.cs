using RedeConcessionarias.Log;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace RedeConcessionarias.configurador{
    static public class Config{
        public static Double Salario {get;set;}
        static public bool DefineSalario (string Arquivo = @".\config.json"){ 
            /* Essa função cria uma linha de comando para auxiliar a definir o salário em um arquivo .json. Se o arquivo não existir, cria ele, se existir, salva o salário passado */
            System.Console.WriteLine("O salário atual é:\n"+ObtemSalario(Arquivo));
            System.Console.WriteLine("Digite o salário que deseja salvar:\n");
            try{
                Salario = Convert.ToDouble(System.Console.ReadLine());
                System.Console.WriteLine("Salvo: "+Salario);
            }
            catch(Exception ex){
                Logger.AdicionaLog(ex.Message,3,"DefineSalario","Erro ao converter salario");
                return false;
            }
            if(File.Exists(Arquivo)){
                try{
                    var Json ="";
                    using (StreamReader reader = new StreamReader(Arquivo)){
                        var JsonLido = JsonDocument.Parse(reader.ReadToEnd());
                        var Atualizado = JsonLido.RootElement.GetProperty("Atualizado").ToString();
                        Json = "{\"SalarioMinimo\":\""+Salario+"\",\"Atualizado\":\""+Atualizado+"\"}";
                    }
                    using (StreamWriter writer = new StreamWriter(Arquivo)){    
                        writer.Write(Json);
                    }
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,3,"DefineSalario","Erro ao salvar salario");
                }
                return true;
            }
            else{
                try{
                    var Json = @"{""SalarioMinimo"":""1212.0"",""Atualizado"":""False""}";
                    using (StreamWriter writer = new StreamWriter(Arquivo)){    
                        writer.Write(Json);
                    }
                }
                catch (Exception ex){
                        Logger.AdicionaLog(ex.Message,3,"DefineSalario","Erro ao criar json");
                        return false;
                }
                return true;
            }
        }
        static public double ObtemSalario(string Arquivo = @".\config.json"){
            /* Essa função lê o arquivo de configuração e retorna qual é o salário definido, se o arquivo não existir, retorna 0.0*/
            if(File.Exists(Arquivo)){
                try{
                    using (StreamReader reader = new StreamReader(Arquivo)){
                        var JsonLido = JsonDocument.Parse(reader.ReadToEnd());
                        Salario = Convert.ToDouble(JsonLido.RootElement.GetProperty("SalarioMinimo").ToString());
                    }
                    return Salario;
                    
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,3,"ObtemSalario","Erro ao obter salario");
                }
            }
            return 0.0;

        }
        static public bool DefineAtualizado(bool Atualizado = true, string Arquivo = @".\config.json"){
            /* Essa função faz a troca do booleano no arquivo, salvando se foi ou não atualizado, é útil para gerenciamento futuro da atualização mensal. */
            if(File.Exists(Arquivo)){
                try{
                    var Json ="";
                    using (StreamReader reader = new StreamReader(Arquivo)){
                        var JsonLido = JsonDocument.Parse(reader.ReadToEnd());
                        var Salario = JsonLido.RootElement.GetProperty("SalarioMinimo").ToString();
                        Json = "{\"SalarioMinimo\":\""+Salario+"\",\"Atualizado\":\""+Atualizado+"\"}";
                    }
                    using (StreamWriter writer = new StreamWriter(Arquivo)){    
                        writer.Write(Json);
                    }
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,3,"DefineAtualizado","Erro ao salvar salario");
                }
                return true;
            }
            else{
                try{
                    var Json = @"{""SalarioMinimo"":""1212.0"",""Atualizado"":""true""}";
                    using (StreamWriter writer = new StreamWriter(Arquivo)){    
                        writer.Write(Json);
                    }
                }
                catch (Exception ex){
                        Logger.AdicionaLog(ex.Message,3,"DefineSalario","Erro ao criar json");
                        return false;
                }
                return true;
            }
        }
    }
}