using System;

/*Resolução da prova técnica para estágio na Apisul
 * Vaga: Estagiário Desenvolvedor - Produtos Digitais
 *Autor: Arthur Exner
 */

namespace ProvaTecnicaApisul;

public class LevantamentoDados //uma classe que reproduz o objeto descrito no .json
{   
	//atributos dos objetos descritos no .json
	public int andar { get; set; }	
	public char elevador { get; set; }
	public char turno { get; set; }
}
