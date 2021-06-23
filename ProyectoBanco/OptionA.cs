using System;
using System.Collections;

namespace ProyectoBanco
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class OptionA : Option {
		
		public OptionA(){
			
		}
		
		public override void Execute(Banco banco) {
			
			int dniTitular=0;
			
			bool otraCuenta = true;

			
			while(otraCuenta){
				
				
				dniTitular=IngresarDNIYValidar(dniTitular);
				
				if(!banco.esCliente(dniTitular)){
					
					CreacionDeNuevoClienteYCuenta(dniTitular, banco);
					
				}else{
					
					CrearCuenta(dniTitular, banco, "");
					
				}
				
				Console.WriteLine("Desea realizar cargar otra cuenta? " +
				                  "\n <ENTER> para seguir, <N> para salir");
				
				string otraOperacion = Console.ReadLine();
				if(otraOperacion.ToUpper()=="N"){
					
					otraCuenta=false;
					
				}
				
			}
			
		}


		void CrearCuenta(int dniTitular, Banco banco, string apellido){
			
			Console.WriteLine("Ingrese numero de cuenta: ");
			int numeroCuenta = int.Parse(Console.ReadLine());
			
			if(apellido.Equals("")) {
				
				Console.WriteLine("Ingrese apellido: ");
				string apellidoNuevo = Console.ReadLine();
			}
			
			Console.WriteLine("Ingrese monto inicial");
			double montoInicial = double.Parse(Console.ReadLine());
			
			banco.AltaCuenta(numeroCuenta, apellido, dniTitular, montoInicial);
			Console.WriteLine("Cuenta bancaria creada exitosamente");
		}


		void CreacionDeNuevoClienteYCuenta(int dniTitular, Banco banco)
		{
			Console.WriteLine("Nuevo cliente, ingrese el nombre: ");
			string nombreNuevo = Console.ReadLine();
			
			Console.WriteLine("Ingrese apellido: ");
			string apellidoNuevo = Console.ReadLine();
			
			Console.WriteLine("Ingrese dirección: ");
			string direccioNueva = Console.ReadLine();
			
			Console.WriteLine("Ingrese telefono: ");
			int telefonoNuevo = int.Parse(Console.ReadLine());
			
			Console.WriteLine("Ingrese E-mail: ");
			string emailNuevo = Console.ReadLine();
			
			banco.AgregarCliente(nombreNuevo, apellidoNuevo, dniTitular, direccioNueva, telefonoNuevo, emailNuevo);
			
			Console.WriteLine("Ingrese numero de cuenta: ");
			int numeroCuentaNueva = int.Parse(Console.ReadLine());
			
			Console.WriteLine("Ingrese monto inicial");
			double montoInicial = double.Parse(Console.ReadLine());
			
			banco.AltaCuenta(numeroCuentaNueva, apellidoNuevo, dniTitular, montoInicial);


			Console.WriteLine("El cliente y su cuenta fueron guardados exitosamente");
		}


		int IngresarDNIYValidar(int dniTitular){
			
			bool dniInvalidoValido = true;
			
			while (dniInvalidoValido) {
				
				Console.WriteLine("Ingrese dni del cliente");
				
				try {
					
					dniTitular = int.Parse(Console.ReadLine());
					
					if (dniTitular.ToString().ToCharArray().Length != 8) {
						
						throw new DniException("se rompio todillo");
						
					}
					
					Console.WriteLine("PASE POR ACA");
					dniInvalidoValido = false;
					
				} catch (FormatException ex) {
					
					Console.WriteLine("Error. Ingrese un valor numerico.");
					dniTitular = 1;
					
				} catch (DniException ex) {
					
					Console.WriteLine("DNI invalido wachin");
					dniTitular = 1;

				} catch (Exception ex) {

					Console.WriteLine("INTERNAL ERROR");
					dniTitular = 1;

				}
			}
			
			return dniTitular;
		}
	}
}
