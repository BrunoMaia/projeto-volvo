using System.IO;
using System;


namespace RedeConcessionarias.Log{
    static public class Logger{
        static public bool AdicionaLog(string Mensagem,int Gravidade,string FuncaoRaiz,string Observacao=""){
            /* Essa função salva as mensagens de erros em um arquivo de log em formato csv. A gravidade da ocorrência é definida como:
            1 - Pouco grave/não afeta totalmente o serviço
            2 - Causa problemas na entrega do serviço
            3 - Pode deixar o serviço instavél/fora
            4 - Paraliza totalmente o serviço
            retorna: true - adicionou ao log, false - não adicionou por ter registrado erro
            */
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