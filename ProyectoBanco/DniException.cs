
using System;

namespace ProyectoBanco
{

	public class DniException : Exception 
	{
		public string mensaje;
		
		public DniException(string mensaje){
			
			this.mensaje=mensaje;
		}
		
		
	}
}
