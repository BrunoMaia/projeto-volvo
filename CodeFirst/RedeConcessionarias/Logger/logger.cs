using System.IO;
using System;


namespace RedeConcessionarias.Log{
    static public class Logger{
        static public bool AdicionaLog(string Mensagem,int Gravidade,string FuncaoRaiz,string Observacao=""){
            string arquivo = @".\log.csv";
            if (File.Exists(arquivo)){
                try{
                    using (StreamWriter writer = new StreamWriter(arquivo, true)){
                        DateTime DataLog = DateTime.Now;
                        writer.WriteLine(FuncaoRaiz+";"+DataLog+";"+Gravidade+";"+Mensagem);
                    }
                }
                catch (Exception erro){
                    Console.WriteLine("Houve um erro na classe Logger, resolva antes de utilizar:\n"+erro.Message);
                    return false;
                }
                return true;
                
            }
            else{
                using (StreamWriter writer = new StreamWriter(arquivo)){
                    writer.Write("Funcao Raiz;Data e hora; Gravidade; Mensagem erro;OBS;\n");
                }
                return Logger.AdicionaLog(Mensagem,Gravidade,FuncaoRaiz);
            }
        }     
    }
}