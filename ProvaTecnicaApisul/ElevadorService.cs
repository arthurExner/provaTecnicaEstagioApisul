using System;

/*Resolução da prova técnica para estágio na Apisul
 * Vaga: Estagiário Desenvolvedor - Produtos Digitais
 *Autor: Arthur Exner
 */

namespace ProvaTecnicaApisul;
public class ElevadorService : IElevadorService //crio uma classe que implementa a interface
{
    private List<LevantamentoDados> registros; //atributo da classe: do tipo lista de objetos 

    public ElevadorService(List<LevantamentoDados> registros) //construtor da classe 
    {
        this.registros = registros;
    }
    //aqui desenvolvo os métodos 
    //prédio 99a da Tecnopuc, com 16 andares e cinco elevadores
    public List<int> andarMenosUtilizado()
    {
        int[] usoAndar = new int[16]; //array de 16 posições onde os índices de 0 a 15 representam os andares e o valor contido em cada índice corresponde ao uso de cada andar | todos valores contidos iniciam em zero 
        for (int i = 0; i < this.registros.Count; i++)  //varrendo a lista registros(que contém os objetos) //pro tamanho da lista uso Count pra array uso Length
        {
            LevantamentoDados levantamentoDados = this.registros[i]; //acessando o objeto contido no índice i da lista registros e armazenando em uma referência para um objeto do tipo da classe LevantamentoDados
            //levantamentoDados.andar // com .andar eu acesso o atributo
                                                 
            usoAndar[levantamentoDados.andar]++; //por ex na posição 0 tenho o andar 11 // assim o índice 11 de usoAndar passa de 0 pra 1, e assim por diante
                                                 //conforme o for varre a lista somo ++ as vezes que cada andar aparece
                                                 //array usoAndar é preenchida começando pela posição 11 e assim por diante (pq quando i=0 andar = 11)
        }
        List<int> resultado = new List<int>(); //criei uma lista que recebe inteiros (andares) e deve apresetar os andares em ordem crescente
        //varrer a array usoAndar e ver qual índice armazena o menor valor. Logo preciso passar o índice de usoAndar(que corresponde ao andar) que contém esse menor valor para a posição mais à esquerda disponível na List<int>
        //depois, preciso atualizar esse valor para um numero absurdamnte alto para não contar ele novamente, então buscar o próximo menor
        //fazer isso utilizando um while(List.Count<16) for(int j=0;j<usoAndar.Length;j++)
        while (resultado.Count < 16)//while delimitando o loop para as 16 posições da lista resultado
        {
            int andarMenosUtilizado = 0; //variável auxiliar
            for (int j = 1; j < usoAndar.Length; j++)   //for para varrer os valores int contidos em cada índice de usoAndar
            {                                        //lembrar que j nesse caso corresponde ao andar
                if (usoAndar[j] < usoAndar[andarMenosUtilizado]) //se o valor contido em usoAndar[j](numero de vezes que o andar é usado ) for menor que o contido em usoAndar[andarMenosUtilizado]
                {
                    andarMenosUtilizado = j; //atualizo o andar menos utilizado recebendo variável j que corresponde ao índice de usoAndar em que está arazenado o menor int
                }

            }

            resultado.Add(andarMenosUtilizado); //adiciona o andar menos utilizado à lista alocando inicialmente no índice 0 e então até o 15 na list conforme o loop while
            usoAndar[andarMenosUtilizado] = 999; //atualizando o int contido nessa posição para não ser contado novamente
        }                                       //andares que possuirem o mesmo numero de uso, serão alocados na list em ordem crescente de acordo com o andar

        return resultado; //retorna a List<int> 
    }

    public List<char> elevadorMaisFrequentado()
    {
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.elevador
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            charsList.Add(levantamentoDados.elevador); //adiciono o char atribuído ao atributo elevador à lista
        }

        int[] usoElevador = new int[5]; //crio uma array de 5 posições que armazena o número de vezes que cada elevador foi utilizado na ordem ABCDE respectivamente de acordo com o índice

        for (int j = 0; j < charsList.Count; j++)
        {
            if (charsList[j] == 'A') //por exemplo em usoElevador[0] armazeno o numero de vezes que o elevador A foi usado
            {
                usoElevador[0]++;
            }
            else if (charsList[j] == 'B')
            {
                usoElevador[1]++;
            }
            else if (charsList[j] == 'C')
            {
                usoElevador[2]++;
            }
            else if (charsList[j] == 'D')
            {
                usoElevador[3]++;
            }
            else if (charsList[j] == 'E')
            {
                usoElevador[4]++;
            }
        }
        //agora preciso descobrir qual índice da array usoElevador guarda o maior int e relacionar de volta com o char correspondente
        //fazer isso novamente usando um while (List.Count < 5) para dicionar à lista final, utilizar um for (int k = 0; k < usoElevador.Length; k++) para descobrir o elevador mais usado e relacionar o ídice da array usoElevador com o char correspondente usando um if
        int elevadorMaisUsado = 0;
        List<char> resultado = new List<char>();
        while (resultado.Count < 5)
        {
            for (int k = 0; k < usoElevador.Length; k++) //nesse caso k corresponde ao elevador
            {
                if (usoElevador[k] > usoElevador[elevadorMaisUsado])
                {
                    elevadorMaisUsado = k;
                }
            }

            if (elevadorMaisUsado == 0) //por exemplo se o índice 0 de usoElevador contiver o maior int, adiciono o char correspondente à essa posição na List (nesse caso 'A')
            {
                resultado.Add('A');
                usoElevador[elevadorMaisUsado] = -1; //atualizo com um valor menor para evitar que seja contado novamente
            }
            else if (elevadorMaisUsado == 1)
            {
                resultado.Add('B');
                usoElevador[elevadorMaisUsado] = -1;
            }
            else if (elevadorMaisUsado == 2)
            {
                resultado.Add('C');
                usoElevador[elevadorMaisUsado] = -1;
            }
            else if (elevadorMaisUsado == 3)
            {
                resultado.Add('D');
                usoElevador[elevadorMaisUsado] = -1;
            }
            else if (elevadorMaisUsado == 4)
            {
                resultado.Add('E');
                usoElevador[elevadorMaisUsado] = -1;
            }
        }

        return resultado;

    }

    public List<char> elevadorMenosFrequentado()
    {
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.elevador
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            charsList.Add(levantamentoDados.elevador); //adiciono o char atribuído ao atributo elevador à lista
        }

        int[] usoElevador = new int[5]; //crio uma array de 5 posições que armazena o número de vezes que cada elevador foi utilizado na ordem ABCDE respectivamente de acordo com o índice

        for (int j = 0; j < charsList.Count; j++)
        {
            if (charsList[j] == 'A') //por exemplo em usoElevador[0] armazeno o numero de vezes que o elevador A foi usado
            {
                usoElevador[0]++;
            }
            else if (charsList[j] == 'B')
            {
                usoElevador[1]++;
            }
            else if (charsList[j] == 'C')
            {
                usoElevador[2]++;
            }
            else if (charsList[j] == 'D')
            {
                usoElevador[3]++;
            }
            else if (charsList[j] == 'E')
            {
                usoElevador[4]++;
            }
        }

        int elevadorMenosUsado = 0;
        List<char> resultado = new List<char>();
        while (resultado.Count < 5)
        {
            for (int k = 0; k < usoElevador.Length; k++) //nesse caso k corresponde ao elevador
            {
                if (usoElevador[k] < usoElevador[elevadorMenosUsado])
                {
                    elevadorMenosUsado = k;
                }
            }

            if (elevadorMenosUsado == 0)
            {
                resultado.Add('A');
                usoElevador[elevadorMenosUsado] = 999; //atualizo com um valor maior para evitar que seja contado novamente
            }
            else if (elevadorMenosUsado == 1)
            {
                resultado.Add('B');
                usoElevador[elevadorMenosUsado] = 999;
            }
            else if (elevadorMenosUsado == 2)
            {
                resultado.Add('C');
                usoElevador[elevadorMenosUsado] = 999;
            }
            else if (elevadorMenosUsado == 3)
            {
                resultado.Add('D');
                usoElevador[elevadorMenosUsado] = 999;
            }
            else if (elevadorMenosUsado == 4)
            {
                resultado.Add('E');
                usoElevador[elevadorMenosUsado] = 999;
            }
        }

        return resultado;

    }

    public float percentualDeUsoElevadorA()
    {
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.elevador
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            charsList.Add(levantamentoDados.elevador); //adiciono o char atribuído ao atributo elevador à lista
        }

        int[] usoElevador = new int[5]; //crio uma array de 5 posições que armazena o número de vezes que cada elevador foi utilizado na ordem ABCDE respectivamente de acordo com o índice

        for (int j = 0; j < charsList.Count; j++)
        {
            if (charsList[j] == 'A') //por exemplo em usoElevador[0] armazeno o numero de vezes que o elevador A foi usado
            {
                usoElevador[0]++;
            }
            else if (charsList[j] == 'B')
            {
                usoElevador[1]++;
            }
            else if (charsList[j] == 'C')
            {
                usoElevador[2]++;
            }
            else if (charsList[j] == 'D')
            {
                usoElevador[3]++;
            }
            else if (charsList[j] == 'E')
            {
                usoElevador[4]++;
            }
        }

        int soma = 0;
        for(int k=0; k < usoElevador.Length; k++) //for para somar todos os serviços prestados 
        {
            soma = soma + usoElevador[k];
        }
        //(float) Math.Round((double) floatValue, 2); | para usar o metodo de arredondamento preciso transformar o valor float em double. Depois preciso transformar de volta em float para o retorno solicitado 
        float resultado;
        resultado = ((float)usoElevador[0] / soma)*100; //calculando o percentual de uso do elevador A

        return (float) Math.Round((double) resultado, 2); 
    }
    public float percentualDeUsoElevadorB()
    {
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.elevador
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            charsList.Add(levantamentoDados.elevador); //adiciono o char atribuído ao atributo elevador à lista
        }

        int[] usoElevador = new int[5]; //crio uma array de 5 posições que armazena o número de vezes que cada elevador foi utilizado na ordem ABCDE respectivamente de acordo com o índice

        for (int j = 0; j < charsList.Count; j++)
        {
            if (charsList[j] == 'A') //por exemplo em usoElevador[0] armazeno o numero de vezes que o elevador A foi usado
            {
                usoElevador[0]++;
            }
            else if (charsList[j] == 'B')
            {
                usoElevador[1]++;
            }
            else if (charsList[j] == 'C')
            {
                usoElevador[2]++;
            }
            else if (charsList[j] == 'D')
            {
                usoElevador[3]++;
            }
            else if (charsList[j] == 'E')
            {
                usoElevador[4]++;
            }
        }

        int soma = 0;
        for (int k = 0; k < usoElevador.Length; k++) //for para somar todos os serviços prestados 
        {
            soma = soma + usoElevador[k];
        }

        float resultado;
        resultado = ((float)usoElevador[1] / soma) * 100; //calculando o percentual de uso do elevador B
        //(float) Math.Round((double) floatValue, 2);
        return (float) Math.Round((double) resultado, 2);
    }

    public float percentualDeUsoElevadorC()
    {
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.elevador
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            charsList.Add(levantamentoDados.elevador); //adiciono o char atribuído ao atributo elevador à lista
        }

        int[] usoElevador = new int[5]; //crio uma array de 5 posições que armazena o número de vezes que cada elevador foi utilizado na ordem ABCDE respectivamente de acordo com o índice

        for (int j = 0; j < charsList.Count; j++)
        {
            if (charsList[j] == 'A') //por exemplo em usoElevador[0] armazeno o numero de vezes que o elevador A foi usado
            {
                usoElevador[0]++;
            }
            else if (charsList[j] == 'B')
            {
                usoElevador[1]++;
            }
            else if (charsList[j] == 'C')
            {
                usoElevador[2]++;
            }
            else if (charsList[j] == 'D')
            {
                usoElevador[3]++;
            }
            else if (charsList[j] == 'E')
            {
                usoElevador[4]++;
            }
        }

        int soma = 0;
        for (int k = 0; k < usoElevador.Length; k++) //for para somar todos os serviços prestados 
        {
            soma = soma + usoElevador[k];
        }

        float resultado;
        resultado = ((float)usoElevador[2] / soma) * 100; //calculando o percentual de uso do elevador C

        return (float) Math.Round((double) resultado, 2);
    }


    public float percentualDeUsoElevadorD()
    {
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.elevador
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            charsList.Add(levantamentoDados.elevador); //adiciono o char atribuído ao atributo elevador à lista
        }

        int[] usoElevador = new int[5]; //crio uma array de 5 posições que armazena o número de vezes que cada elevador foi utilizado na ordem ABCDE respectivamente de acordo com o índice

        for (int j = 0; j < charsList.Count; j++)
        {
            if (charsList[j] == 'A') //por exemplo em usoElevador[0] armazeno o numero de vezes que o elevador A foi usado
            {
                usoElevador[0]++;
            }
            else if (charsList[j] == 'B')
            {
                usoElevador[1]++;
            }
            else if (charsList[j] == 'C')
            {
                usoElevador[2]++;
            }
            else if (charsList[j] == 'D')
            {
                usoElevador[3]++;
            }
            else if (charsList[j] == 'E')
            {
                usoElevador[4]++;
            }
        }

        int soma = 0;
        for (int k = 0; k < usoElevador.Length; k++) //for para somar todos os serviços prestados 
        {
            soma = soma + usoElevador[k];
        }

        float resultado;
        resultado = ((float)usoElevador[3] / soma) * 100; //calculando o percentual de uso do elevador D

        return (float) Math.Round((double) resultado, 2);
    }

    public float percentualDeUsoElevadorE()
    {
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.elevador
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            charsList.Add(levantamentoDados.elevador); //adiciono o char atribuído ao atributo elevador à lista
        }

        int[] usoElevador = new int[5]; //crio uma array de 5 posições que armazena o número de vezes que cada elevador foi utilizado na ordem ABCDE respectivamente de acordo com o índice

        for (int j = 0; j < charsList.Count; j++)
        {
            if (charsList[j] == 'A') //por exemplo em usoElevador[0] armazeno o numero de vezes que o elevador A foi usado
            {
                usoElevador[0]++;
            }
            else if (charsList[j] == 'B')
            {
                usoElevador[1]++;
            }
            else if (charsList[j] == 'C')
            {
                usoElevador[2]++;
            }
            else if (charsList[j] == 'D')
            {
                usoElevador[3]++;
            }
            else if (charsList[j] == 'E')
            {
                usoElevador[4]++;
            }
        }

        int soma = 0;
        for (int k = 0; k < usoElevador.Length; k++) //for para somar todos os serviços prestados 
        {
            soma = soma + usoElevador[k];
        }

        float resultado;
        resultado = ((float)usoElevador[4] / soma) * 100; //calculando o percentual de uso do elevador E

        return (float) Math.Round((double) resultado, 2);
    }

    public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
    {
        //o elevador mais frequentado é C
        //preciso criar uma lista de caracteres (turno) de todos objetos com todos elevador = C
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.turno
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            if(levantamentoDados.elevador == 'C') 
            {
                charsList.Add(levantamentoDados.turno); //se nesse índice, tenho o atributo elevador = 'C', adiciono o turno (char) do objeto correspondente na lista
            }                                          
        }

        int[] turnoFrequencia = new int[3];
        for(int j = 0; j < charsList.Count ; j++) //varro a charsList
        {                                         //armazeno o número de vezes em que o elevador C foi utilizado em cada turno, armazeno na ordem MVN respectivamente de acordo com o índice
            if (charsList[j] == 'M')
            {
                turnoFrequencia[0]++;            
            }
            else if(charsList[j] == 'V')
            {
                turnoFrequencia[1]++;
            }
            else if (charsList[j] == 'N')
            {
                turnoFrequencia[2]++;
            }
        }
        //a partir de agora realizo um procedimento similar ao realizado anteriormente em outros métodos
        List<char> resultado = new List<char>();
        while (resultado.Count < 3)   //o loop deverá preencher a List<char> até o índice 2
        {
            int turnoMaisFrequente = 0;
            for (int k = 0; k < turnoFrequencia.Length; k++) 
            {
                if (turnoFrequencia[k] > turnoFrequencia[turnoMaisFrequente])
                {
                    turnoMaisFrequente = k;
                }

            }

            if(turnoMaisFrequente == 0)
            {
                resultado.Add('M');
                turnoFrequencia[turnoMaisFrequente] = -1;
            }
            else if(turnoMaisFrequente == 1)
            {
                resultado.Add('V');
                turnoFrequencia[turnoMaisFrequente] = -1;
            }
            else if(turnoMaisFrequente == 2)
            {
                resultado.Add('N');
                turnoFrequencia[turnoMaisFrequente] = -1;
            }

        }
            return resultado;
    }

    public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
    {
        LevantamentoDados levantamentoDados; 
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.turno
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            charsList.Add(levantamentoDados.turno); //adiciono o char atribuído ao atributo turno à lista
        }

        int[] usoElevador = new int[3]; //crio uma array de 3 posições que armazena o número de vezes que cada elevador foi utilizado na ordem MVN respectivamente de acordo com o índice

        for (int j = 0; j < charsList.Count; j++)
        {
            if (charsList[j] == 'M') //por exemplo em usoElevador[0] armazeno o numero de vezes que o elevador foi usado no Turno M
            {
                usoElevador[0]++;
            }
            else if (charsList[j] == 'V')
            {
                usoElevador[1]++;
            }
            else if (charsList[j] == 'N')
            {
                usoElevador[2]++;
            }
        }

        int turnoMaisUsado = 0;
        List<char> resultado = new List<char>();
        while (resultado.Count < 3)
        {
            for (int k = 0; k < usoElevador.Length; k++) //nesse caso k corresponde ao turno
            {
                if (usoElevador[k] > usoElevador[turnoMaisUsado])
                {
                    turnoMaisUsado = k;
                }
            }

            if (turnoMaisUsado == 0)
            {
                resultado.Add('M');
                usoElevador[turnoMaisUsado] = -1; //atualizo com um valor menor para evitar que seja contado novamente
            }
            else if (turnoMaisUsado == 1)
            {
                resultado.Add('V');
                usoElevador[turnoMaisUsado] = -1;
            }
            else if (turnoMaisUsado == 2)
            {
                resultado.Add('N');
                usoElevador[turnoMaisUsado] = -1;
            }
        }

        return resultado;
    }

    public List<char> periodoMenorFluxoElevadorMenosFrequentado()
    {
        //o elevador menos frequentado é o D (primeiro da lista executando o método elevadorMenosFrequentado())
        //ou o E (ultimo da lista ao executar o método elevadorMaisFrequentado()) indicando que D e E são frequentados o mesmo numero de vezes e se ordenam em ordem alfabética nas listas por conta de como a lista foi construída | posso ver isso também pela taxa de uso idêntica de 4,35%
        //preciso criar uma lista de caracteres (turno) de todos objetos com todos elevador = D (ou E) | nesse caso resolvi para o elevador D
        LevantamentoDados levantamentoDados;
        List<char> charsList = new List<char>(); //crio uma lista para armazenar os char contido em levantamentoDados.turno
        for (int i = 0; i < this.registros.Count; i++) //condição de parada é quando varri toda minha lista de objetos
        {
            levantamentoDados = this.registros[i]; //varro os objetos do json 
            if (levantamentoDados.elevador == 'D')
            {
                charsList.Add(levantamentoDados.turno); //se nesse índice, tenho o atributo elevador = 'D', adiciono o turno (char) do objeto correspondente na lista
            }
        }

        int[] turnoFrequencia = new int[3];
        for (int j = 0; j < charsList.Count; j++) //varro a charsList
        {                                         //armazeno o número de vezes em que o elevador D foi utilizado em cada turno, armazeno na ordem MVN respectivamente de acordo com o índice
            if (charsList[j] == 'M')
            {
                turnoFrequencia[0]++;
            }
            else if (charsList[j] == 'V')
            {
                turnoFrequencia[1]++;
            }
            else if (charsList[j] == 'N')
            {
                turnoFrequencia[2]++;
            }
        }

        List<char> resultado = new List<char>();
        while (resultado.Count < 3)   //o loop deverá preencher a List<char> até o índice 2
        {
            int turnoMenosFrequente = 0;
            for (int k = 0; k < turnoFrequencia.Length; k++)
            {
                if (turnoFrequencia[k] < turnoFrequencia[turnoMenosFrequente])
                {
                    turnoMenosFrequente = k;
                }

            }
            if (turnoMenosFrequente == 0)
            {
                resultado.Add('M');
                turnoFrequencia[turnoMenosFrequente] = 999;
            }
            else if (turnoMenosFrequente == 1)
            {
                resultado.Add('V');
                turnoFrequencia[turnoMenosFrequente] = 999;
            }
            else if (turnoMenosFrequente == 2)
            {
                resultado.Add('N');
                turnoFrequencia[turnoMenosFrequente] = 999;
            }
        }
        return resultado;
    }
}
