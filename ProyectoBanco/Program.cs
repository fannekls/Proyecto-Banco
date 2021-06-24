using System.Collections;
using System;

namespace ProyectoBanco
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Banco galicia = new Banco ("Banco Galicia");
			
			bool menuOpciones=true;
			
			while(menuOpciones){
				
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
					

				}else if(menu=="c" || menu=="C"){
					
					Opciones.OpcionC(galicia);
					
					
				}else if(menu=="d" || menu=="D"){
					
				
				}else if(menu=="e" || menu=="E"){
					
					
				}else if(menu=="f" || menu=="F"){
					
					Console.WriteLine("___________Cuentas Bancarias____________");
					
					
					Opciones.OpcionF(galicia);
					
					
					Console.WriteLine("________________________________________");
					
				} else if(menu=="g" || menu=="G"){
					
					Console.WriteLine("___________Clientes____________");
					
					
					Opciones.OpcionG(galicia);
					
					
					Console.WriteLine("_________________________________");
					
				} else if(menu=="h" || menu=="H"){
					
					menuOpciones=false;
				}
			}
			
			Console.ReadKey(true);
		}
		
	}
}