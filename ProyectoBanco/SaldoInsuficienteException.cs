/*
 * Created by SharpDevelop.
 * User: serleo
 * Date: 21/6/2021
 * Time: 22:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoBanco 
{
	/// <summary>
	/// Description of SaldoInsuficienteException.
	/// </summary>
	public class SaldoInsuficienteException : Exception 
	{
		public string mensaje;
		
		public SaldoInsuficienteException(string mensaje)
		{
			this.mensaje=mensaje;
		}
		
		public SaldoInsuficienteException()
		{
		}
	}
}
