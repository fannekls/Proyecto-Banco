
using System;

namespace ProyectoBanco
{

	public class Opciones
	{
		
		public static void OpcionA (Banco banco){
			
			
			int dniTitular=0;
			
			bool otraCuenta=true;
			bool dniInvalidoValido=true;

			
			while(otraCuenta){
				
				while(dniInvalidoValido){
					
					
					Console.Write("Ingrese dni del cliente: ");
					
					try{
						
						dniTitular= int.Parse(Console.ReadLine());
						
						if(dniTitular.ToString().ToCharArray().Length != 8){
							
							throw new DniException("ERROR");
						}
						
						dniInvalidoValido=false;
						
					} catch(FormatException){
						
						Console.WriteLine("\nError. Ingrese un valor numerico. \n" +
						                  "-------------------------------");
						
						dniTitular=1;
						
					} catch(DniException){
						
						Console.WriteLine("Debe ingresar 8 digitos. \n" +
						                  "-------------------------------");
						
						dniTitular=1;
						
					} catch(Exception){
						
						Console.WriteLine("INTERNAL ERROR");
						
						dniTitular=1;
						
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
					
					
					Console.Write("Ingrese monto inicial");
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
