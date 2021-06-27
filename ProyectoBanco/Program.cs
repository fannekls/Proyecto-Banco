using System.Collections;
using System;

namespace ProyectoBanco
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Banco galicia = new Banco ("Banco Galicia");
			
			DatosDefault(galicia);
			
			Cliente pruebaCliente;
			
			pruebaCliente=galicia.VerCliente(33651281);
			
			Console.WriteLine(pruebaCliente.CuentasCliente.Count);
			
			Console.WriteLine("_____________________________________________________________________________________________________________\n");
			
			bool menuOpciones=true;
			
			while(menuOpciones){
				
				
				
				Console.WriteLine("                                                 Gestión {0}",galicia.NombreBanco);
				Console.WriteLine("                                           ________________________________\n");
				Console.WriteLine("Elija su operacion:\n"+ 
				                  "\na) Agregar cuenta bancaria\n" +
				                  "\nb) Eliminar cuenta bancaira\n" +
				                  "\nc) Listado de clientes que tienen mas de una cuenta\n"+
				                  "\nd) Realizar extraccion\n"+
				                  "\ne) Depositar dinero de cuenta\n"+
				                  "\nf) Listado de cuentas bancarias\n"+
				                  "\ng) Listado de clientes\n"+
				                  "\nh) Finalizar programa"+
				                  "\n");
				
				
				string menu = Console.ReadLine();
				
				if(menu=="a" || menu=="A"){
					
					Console.Clear();
					
					Opciones.OpcionA(galicia);
					Console.WriteLine("Presione cualquier tecla para volver al menu...");
					Console.ReadKey(true);
					
					Console.Clear();
					
					
				} else if(menu=="b" || menu=="B"){
					
					Console.Clear();
					
					Opciones.OpcionB(galicia);
					Console.WriteLine("Presione cualquier tecla para volver al menu...");
					Console.ReadKey(true);
					
					Console.Clear();
					

				}else if(menu=="c" || menu=="C"){
					
					Console.Clear();
					
					Opciones.OpcionC(galicia);
					Console.WriteLine("Presione cualquier tecla para volver al menu...");
					Console.ReadKey(true);
					
					Console.Clear();
					
					
					
				}else if(menu=="d" || menu=="D"){
					
					Console.Clear();
					
					Opciones.OpcionD(galicia);
					Console.WriteLine("Presione cualquier tecla para volver al menu...");
					Console.ReadKey(true);
					
					Console.Clear();
				
					
				}else if(menu=="e" || menu=="E"){
					
					Console.Clear();
					
					
					Opciones.OpcionE(galicia);
					
					Console.WriteLine("Presione cualquier tecla para volver al menu...");
					
					Console.ReadKey(true);
					
					Console.Clear();
					
					
				}else if(menu=="f" || menu=="F"){
					Console.Clear();
					
					Console.WriteLine("                                    ___________Cuentas Bancarias____________");
					
					
					Opciones.OpcionF(galicia);
					
					
					Console.WriteLine("                                    ________________________________________\n");
					
					Console.WriteLine("Presione cualquier tecla para volver al menu...");
					
					Console.ReadKey(true);
					
					Console.Clear();
					
				} else if(menu=="g" || menu=="G"){	
					
					Console.Clear();
					
					
					Console.WriteLine("                                         ___________Clientes____________\n");
					
					
					Opciones.OpcionG(galicia);
					
					
					Console.WriteLine("                                         _________________________________\n");
					
					Console.WriteLine("Presione cualquier tecla para volver al menu...");
					Console.ReadKey(true);
					
					Console.Clear();
					
					
				} else if(menu=="h" || menu=="H"){
					
					menuOpciones=false;
					
					
					Console.WriteLine("Fin de la gestion. ¡Que tenga buen dia!");
					
				} else {
					
					Console.Clear();
					
					Console.WriteLine("No es una opcion valida");
					
					Console.WriteLine("Presione cualquier tecla para volver al menu principal");
					Console.ReadKey(true);
					
					Console.Clear();
					
				}
			}
			
			Console.ReadKey(true);
		}
		
		
		private static void DatosDefault(Banco banco){
			
			banco.AgregarCliente("Horacio", "Alvarez", 78952221, "calle 735 Bernal", 12345678, "HoracioAlvi@outlook.com");
			banco.AltaCuenta(1112,"Alvarez",78952221,123165165);
			
			banco.AgregarCliente("Matias", "Guarneri", 52164821, "calle duarte n1333", 52164821, "Mguarneri@gmail.com");
			banco.AltaCuenta(11254,"Guarneri",52164821,123165165);
			
			banco.AgregarCliente("Jorge", "Caceres", 30154691, "calle 29 bis n1344", 30154691, "jorgc.100@hotmail.com");
			banco.AltaCuenta(323,"Caceres",30154691,123165165);
			
			banco.AgregarCliente("Ezequiel", "Agusti", 21875131, "calle alsina 1243", 21875131, "eze.98.ll@gmail.com");
			banco.AltaCuenta(414,"Agusti",21875131,123165165);
			
			banco.AgregarCliente("Kevin", "Barco", 33651281, "calle 882 n2254", 21875131, "kb.barz@hotmail.com");
			banco.AltaCuenta(7541,"Barco",33651281,123165165);
			banco.AltaCuenta(21312,"Barco",33651281,123165165);
		}
		
	}
}