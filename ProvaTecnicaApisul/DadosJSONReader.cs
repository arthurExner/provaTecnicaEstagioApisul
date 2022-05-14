using System;
using System.Text.Json;
using System.Text.Json.Serialization;

/*Resolução da prova técnica para estágio na Apisul
 * Vaga: Estagiário Desenvolvedor - Produtos Digitais
 *Autor: Arthur Exner
 */

namespace ProvaTecnicaApisul
{
    public class DadosJSONReader
    {
        public static List<LevantamentoDados> read(string json) //método static que recebe uma string com o caminho até o .json e retorna uma lista de objetos
        {
            List<LevantamentoDados> registros; //declaro a variável que armazena uma lista de objetos

            string arquivoJSON; //declaro a variável que armazena a string obtida da leitura do json

            arquivoJSON = File.ReadAllText(json); //le o arquivo json e transforma em uma string

            registros = JsonSerializer.Deserialize<List<LevantamentoDados>>(arquivoJSON); //utiliza o metodo Deserialize para criar uma lista de objetos a partir da string  


            return registros; //retorna a lista de objetos
        }
    }
}
