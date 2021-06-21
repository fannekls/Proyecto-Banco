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
					
					OpcionA(galicia);
					
				} else if(menu=="b" || menu=="B"){

				} else if(menu=="f" || menu=="F"){
					
					ArrayList cuentasGalicia = galicia.TodasCuentas;
				} else if(menu=="g" || menu=="G"){
					
					ArrayList clientesGalicia = galicia.TodoslosClientes;
				} else if(menu=="h" || menu=="H"){
					
					flag=false;
				}
			}
			
			Console.ReadKey(true);
			
			
			
			
			
			
		}
		
		//OPCIONES MODULARIZADAS
		
		public static void OpcionA (Banco banco){
			
			
			int dniTitular=0;
			
			bool otraCuenta=true;
			bool dniInvalidoValido=true;

			
			while(otraCuenta){
				
				while(dniInvalidoValido){
					
					
					Console.WriteLine("Ingrese dni del cliente");
					
					try{
						
						dniTitular= int.Parse(Console.ReadLine());
						
						if(dniTitular.ToString().ToCharArray().Length != 8){
							
							throw new DniException("se rompio todillo");
						}
						
						Console.WriteLine("PASE POR ACA");
						dniInvalidoValido=false;
						
					} catch(FormatException ex){
						
						Console.WriteLine("Error. Ingrese un valor numerico.");
						
						dniTitular=1;
						
					} catch(DniException ex){
						
						Console.WriteLine("DNI invalido wachin");
						
						dniTitular=1;
						
					} catch(Exception ex){
						
						Console.WriteLine("INTERNAL ERROR");
						
						dniTitular=1;
						
					}
				}
				
				
				if(!banco.esCliente(dniTitular)){
					
					
					Console.WriteLine("Nuevo cliente, ingrese el nombre: ");
					string nombreNuevo= Console.ReadLine();
					
					Console.WriteLine("Ingrese apellido: ");
					string apellidoNuevo = Console.ReadLine();
					
					Console.WriteLine("Ingrese dirección: ");
					string direccioNueva= Console.ReadLine();
					
					Console.WriteLine("Ingrese telefono: ");
					int telefonoNuevo=int.Parse(Console.ReadLine());
					
					Console.WriteLine("Ingrese E-mail: ");
					string emailNuevo=Console.ReadLine();
					
					banco.AgregarCliente(nombreNuevo,apellidoNuevo,dniTitular,direccioNueva,telefonoNuevo,emailNuevo);
					
					Console.WriteLine("Ingrese numero de cuenta: ");
					int numeroCuentaNueva = int.Parse(Console.ReadLine());
					
					
					Console.WriteLine("Ingrese monto inicial");
					double montoInicial= double.Parse(Console.ReadLine());
					
					banco.AltaCuenta(numeroCuentaNueva,apellidoNuevo,dniTitular,montoInicial);
					
					
					Console.WriteLine("El cliente y su cuenta fueron guardados exitosamente");
					
				}
				else{
					
					Console.WriteLine("Ingrese numero de cuenta: ");
					int numeroCuenta = int.Parse(Console.ReadLine());
					
					Console.WriteLine("Ingrese apellido: ");
					string apellidoNuevo = Console.ReadLine();
					
					Console.WriteLine("Ingrese monto inicial");
					double montoInicial= double.Parse(Console.ReadLine());
					
					banco.AltaCuenta(numeroCuenta,apellidoNuevo,dniTitular,montoInicial);
					
					
					Console.WriteLine("Cuenta bancaria creada exitosamente");
					
				}
				
				Console.WriteLine("Desea realizar cargar otra cuenta? " +
				                  "\n <ENTER> para seguir, <N> para salir");
				
				string otraOperacion = Console.ReadLine();
				if(otraOperacion.ToUpper()=="N"){
					
					otraCuenta=false;
					
				}
				
			}
		}
		
	}
}