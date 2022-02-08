using RedeConcessionarias.Log;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace RedeConcessionarias.configurador{
    static public class Config{
        public static Double Salario {get;set;}
        static public bool DefineSalario (string arquivo){ 
            System.Console.WriteLine("O salário atual é:\n"+Convert.ToString(ObtemSalario(arquivo)));
            System.Console.WriteLine("Digite o salário que deseja salvar:\n");
            try{
                Salario = Convert.ToDouble(System.Console.ReadLine());
                System.Console.WriteLine("Salvo: "+Salario);
            }
            catch(Exception ex){
                Logger.AdicionaLog(ex.Message,3,"DefineSalario","Erro ao converter salario");
                return false;
            }
            if(File.Exists(arquivo)){
                try{
                    var Json ="";
                    using (StreamReader reader = new StreamReader(arquivo)){
                        var JsonLido = JsonDocument.Parse(reader.ReadToEnd());
                        var Atualizado = JsonLido.RootElement.GetProperty("Atualizado").ToString();
                        Json = "{\"SalarioMinimo\":\""+Salario+"\",\"Atualizado\":\""+Atualizado+"\"}";
                    }
                    using (StreamWriter writer = new StreamWriter(arquivo)){    
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
                    using (StreamWriter writer = new StreamWriter(arquivo)){    
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
        static public double ObtemSalario(string arquivo){
            if(File.Exists(arquivo)){
                try{
                    using (StreamReader reader = new StreamReader(arquivo)){
                        var JsonLido = JsonDocument.Parse(reader.ReadToEnd());
                        var Salario = JsonLido.RootElement.GetProperty("SalarioMinimo").ToString();
                    }
                    return Convert.ToDouble(Salario);
                    
                }
                catch (Exception ex){
                    Logger.AdicionaLog(ex.Message,3,"ObtemSalario","Erro ao obter salario");
                }
            }
            return 0.0;

        }
    }
}