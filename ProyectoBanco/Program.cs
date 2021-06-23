using System.Collections;
using System;

namespace ProyectoBanco
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Banco galicia = new Banco ("Banco Galicia");
			
			bool flag=true;
			
			while(flag){
				
				Console.WriteLine("Gestión {0}",galicia.NombreBanco);
				Console.WriteLine("________________________________\n");
				Console.WriteLine("Elija su operacion:\n"+
				                  "\na) Agregar cuenta bancaria" +
				                  "\nb) Eliminar cuenta bancaira" +
				                  "\nc) Listado de clientes que tienen mas de una cuenta"+
				                  "\nd) Realizar extraccion"+
				                  "\ne) Depositar dinero de cuenta"+
				                  "\nf) Listado de cuentas bancarias"+
				                  "\ng) Listado de clientes"+
				                  "\nh) Finalizar programa"+
				                  "\n");
				string menu = Console.ReadLine();
				if(menu=="a" || menu=="A"){
					
					Opciones.OpcionA(galicia);
					
				} else if(menu=="b" || menu=="B"){

				} else if(menu=="f" || menu=="F"){
					
					ArrayList cuentasGalicia = galicia.TodasCuentas;
					
				} else if(menu=="g" || menu=="G"){
					
					galicia.TodoslosClientes;
				} else if(menu=="h" || menu=="H"){
					
					flag=false;
				}
			}
			
			Console.ReadKey(true);
		}
		
	}
}