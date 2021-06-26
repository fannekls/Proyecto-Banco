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
					
					Opciones.OpcionB(galicia);
					

				}else if(menu=="c" || menu=="C"){
					
					Opciones.OpcionC(galicia);
					
					
				}else if(menu=="d" || menu=="D"){
					
					Opciones.OpcionD(galicia);
					
				}else if(menu=="e" || menu=="E"){
					
					Opciones.OpcionE(galicia);
					
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