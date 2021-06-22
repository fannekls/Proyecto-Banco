using System;

namespace ProyectoBanco
{
	/// <summary>
	/// Description of DniException.
	/// </summary>
	public class DniException : Exception 
	{
		public string mensaje;
		
		public DniException(){
			
		}
		
		public DniException(string mensaje){
			
			this.mensaje=mensaje;
		}
		
		
	}
}
