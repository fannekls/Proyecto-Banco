/*
 * Creado por SharpDevelop.
 * Usuario: Marcio
 * Fecha: 20/6/2021
 * Hora: 20:50
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace ProyectoBanco
{
	/// <summary>
	/// Description of DniException.
	/// </summary>
	public class DniException : Exception 
	{
		public string mensaje;
		
		public DniException(string mensaje){
			
			this.mensaje=mensaje;
		}
		
		
	}
}
