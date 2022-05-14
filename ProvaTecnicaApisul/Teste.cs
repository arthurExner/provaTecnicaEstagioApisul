using System;

namespace ProvaTecnicaApisul;

/*Resolução da prova técnica para estágio na Apisul
 * Vaga: Estagiário Desenvolvedor - Produtos Digitais
 *Autor: Arthur Exner
 */
class Teste //classe que invoca o método main
{
    static void Main(string[] args)
    {
        List<LevantamentoDados> registros; //declaro minha referência para a lista de objetos
        registros = DadosJSONReader.read("C:/Users/tudye/Desktop/C#/ProvaApisul/ProvaTecnicaApisul/ProvaTecnicaApisul/input.json"); //faço a atribuição da lista de objetos invocando o método read() da classe DadosJSONReader

        ElevadorService elevador1 = new ElevadorService(registros); //instancio um objeto do tipo ElevadorService que recebe por parâmetro o seu atributo (a lista de objetos)

        //1) Andar menos utilizado
        Console.WriteLine("1) Andar menos utilizado:");
        List<int> andar = elevador1.andarMenosUtilizado(); //para poder printar em tela, declaro uma referencia pra lista de int e faço a atribuição invocando o método desejado através do ojeto instanciado.
        Console.WriteLine(andar[0]);
        //para imprimir a lista inteira:
        /*List<int> andar = elevador1.andarMenosUtilizado();  
        for (int i = 0; i < andar.Count; i++) //condição de parada é quando varrer toda lista
        {
            Console.WriteLine(andar[i]); //printo em tela o resultado em cada índice da lista
        }*/

        //2) Elevador mais frequentado
        Console.WriteLine("2) Elevador mais frequentado:");
        List<char> elevador = elevador1.elevadorMaisFrequentado();
        Console.WriteLine(elevador[0]);
        /*List<char> elevador = elevador1.elevadorMaisFrequentado();
        for (int i = 0; i < elevador.Count; i++)
        {
            Console.WriteLine(elevador[i]);
        }*/

        //3) Período de maior fluxo do elevador mais frequentado
        Console.WriteLine("3) Período de maior fluxo do elevador mais frequentado:");
        List<char> periodo = elevador1.periodoMaiorFluxoElevadorMaisFrequentado();
        Console.WriteLine(periodo[0]);
        /*List<char> periodo = elevador1.periodoMaiorFluxoElevadorMaisFrequentado();
        for (int i = 0; i < elevador.Count; i++)
        {
            Console.WriteLine(periodo[i]);
        }*/

        //4) Elevador menos frequentado
        Console.WriteLine("4) Elevador menos frequentado:");
        elevador = elevador1.elevadorMenosFrequentado();
        Console.WriteLine(elevador[0]);
        /*List<char> elevador = elevador1.elevadorMenosFrequentado();
        for (int i = 0; i < elevador.Count; i++)
        {
            Console.WriteLine(elevador[i]);
        }*/

        //5) Período de menor fluxo do elevador menos frequentado
        Console.WriteLine("5) Período de menor fluxo do elevador menos frequentado:");
        periodo = elevador1.periodoMenorFluxoElevadorMenosFrequentado();
        Console.WriteLine(periodo[0]);
        /*List<char> periodo = elevador1.periodoMenorFluxoElevadorMenosFrequentado();
        for (int i = 0; i < elevador.Count; i++)
        {
            Console.WriteLine(periodo[i]);
        }*/

        //6) Período de maior utilização do conjunto de elevadores
        Console.WriteLine("6) Período de maior utilização do conjunto de elevadores:");
        periodo = elevador1.periodoMaiorUtilizacaoConjuntoElevadores();
        Console.WriteLine(periodo[0]);
        /*List<char> elevador = elevador1.periodoMaiorUtilizacaoConjuntoElevadores();
        for (int i = 0; i < elevador.Count; i++)
        {
            Console.WriteLine(elevador[i]);
        }*/

        //7) Percentual de uso elevador A
        Console.WriteLine("7) Percentual de uso elevador A:");
        float percentualElevador = elevador1.percentualDeUsoElevadorA();
        Console.WriteLine(percentualElevador);
        
        //8) Percentual de uso elevador B
        Console.WriteLine("8) Percentual de uso elevador B:");
        percentualElevador = elevador1.percentualDeUsoElevadorB();
        Console.WriteLine(percentualElevador);
        
        //9)Percentual de uso elevador C
        Console.WriteLine("9) Percentual de uso elevador C:");
        percentualElevador = elevador1.percentualDeUsoElevadorC();
        Console.WriteLine(percentualElevador);
       
        //10)
        Console.WriteLine("10) Percentual de uso elevador D:");
        percentualElevador = elevador1.percentualDeUsoElevadorD();
        Console.WriteLine(percentualElevador);
        
        //11)
        Console.WriteLine("11) Percentual de uso elevador E:");
        percentualElevador = elevador1.percentualDeUsoElevadorE();
        Console.WriteLine(percentualElevador);
                        
    }
}
 