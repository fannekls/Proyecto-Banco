
using System;

namespace ProyectoBanco
{

	public class Opciones
	{
		
		public static void OpcionA (Banco banco){
			
			
			int dniTitular=0;
			
			bool otraCuenta=true;
			
			bool dniInvalido=true;

			
			while(otraCuenta){
				
				while(dniInvalido){
					
					
					Console.Write("Ingrese dni del cliente: ");
					
					try{
						
						dniTitular= int.Parse(Console.ReadLine());
						
						if(dniTitular.ToString().ToCharArray().Length != 8){
							
							throw new DniException();
						}
						
						dniInvalido=false;
						
						
					} catch(FormatException){
						
						Console.WriteLine("\nError. Ingrese un valor numerico. \n" +
						                  "-------------------------------");
						

					} catch(DniException){
						
						Console.WriteLine("Debe ingresar 8 digitos. \n" +
						                  "-------------------------------");
					} catch(Exception){
						
						Console.WriteLine("INTERNAL ERROR");
					}
				}
				
				
				if(!banco.esCliente(dniTitular)){
					
					
					Console.Write("Nuevo cliente, ingrese el nombre: ");
					string nombreNuevo= Console.ReadLine();
					
					Console.Write("Ingrese apellido: ");
					string apellidoNuevo = Console.ReadLine();
					
					Console.Write("Ingrese dirección: ");
					string direccioNueva= Console.ReadLine();
					
					Console.Write("Ingrese telefono: ");
					int telefonoNuevo=int.Parse(Console.ReadLine());
					
					Console.Write("Ingrese E-mail: ");
					string emailNuevo=Console.ReadLine();
					
					banco.AgregarCliente(nombreNuevo,apellidoNuevo,dniTitular,direccioNueva,telefonoNuevo,emailNuevo);
					
					Console.Write("Ingrese numero de cuenta: ");
					int numeroCuentaNueva = int.Parse(Console.ReadLine());
					
					
					Console.Write("Ingrese monto inicial: ");
					double montoInicial= double.Parse(Console.ReadLine());
					
					banco.AltaCuenta(numeroCuentaNueva,apellidoNuevo,dniTitular,montoInicial);
					
					
					Console.WriteLine("El cliente y su cuenta fueron guardados exitosamente");
					
				}
				else{
					
					Console.WriteLine("Ingrese numero de cuenta: ");
					int numeroCuenta = int.Parse(Console.ReadLine());
					
					Console.WriteLine("Ingrese apellido: ");
					string apellidoNuevo = Console.ReadLine();
					
					Console.Write("Ingrese monto inicial: ");
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
				
				dniInvalido= true;
				
				
			}
		}
		
		public static void OpcionC(Banco banco){
			
			foreach(Cliente clienteX in banco.TodoslosClientes){
				
				if(clienteX.ListaCuentas.Count>1){
					
					Console.WriteLine(clienteX.ToString());
					
				}
				
			}
			
		}
		
		public static void OpcionF (Banco banco){
			
			foreach(CtaBancaria cuentaX in banco.TodasCuentas){
						
						Console.WriteLine(cuentaX.ToString());
					}
			
			
			
		}
		
		public static void OpcionG (Banco banco){
			
			foreach(Cliente clienteX in banco.TodoslosClientes){
				
				Console.WriteLine(clienteX.ToString());
				
			}
			
		}
		
		
	}
}
