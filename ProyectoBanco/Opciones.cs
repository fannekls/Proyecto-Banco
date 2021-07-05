using System.Collections;
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
						
						if(dniTitular.ToString().ToCharArray().Length!=7){
							
							if(dniTitular.ToString().ToCharArray().Length!=8){
								
								throw new DniException();
							}
							
						}

						dniInvalido=false;
						
						
					} catch(FormatException){
						
						Console.WriteLine("\nError. Ingrese un valor numerico. \n" +
						                  "-------------------------------");
						

					} catch(DniException){
						
						Console.WriteLine("Debe ingresar 7 digitos u 8 digitos. \n" +
						                  
						                  "-------------------------------");
						
						
					} catch(OverflowException){
						
						
						Console.WriteLine("ERROR. El dni ingresado es demasiado largo");
						
						
					} catch (Exception) {
						
						Console.WriteLine("Ha ocurrido un error inesperado");
						
					}
				}
				
				
				if(!banco.esCliente(dniTitular)){
					
					
					Console.Write("\nNuevo cliente\n ingrese el nombre: ");
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
					
					Console.Write("Ingrese monto inicial: ");
					double montoInicial= double.Parse(Console.ReadLine());
					
					string apellidoTitular = banco.VerCliente(dniTitular).Apellido;
					
					banco.AltaCuenta(numeroCuenta,apellidoTitular,dniTitular,montoInicial);
					
					
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
		
		public static void OpcionB(Banco banco){
			
			bool datos=true;
			
			Cliente cuentaelim = null;
			
			CtaBancaria borrarCta = null;
			
			foreach(Cliente clientex in banco.TodoslosClientes){
				
				Console.WriteLine(clientex);
				
			}
			
			
			while(datos){
				try{
					
					Console.Write("Ingrese el dni del cliente: ");
					
					int dniCliente= int.Parse(Console.ReadLine());
					
					Console.Clear();
					
					if(banco.esCliente(dniCliente)){
						
						ArrayList cuentasTitular = banco.VerCliente(dniCliente).CuentasCliente;
						
						foreach(CtaBancaria cuentaX in cuentasTitular){
							
							Console.WriteLine(cuentaX.ToString());
							
						}
						
						if(cuentasTitular.Count==1){
							
							Console.Write("Ingrese numero de cuenta a borrar: ");
							int cuentaEliminar = int.Parse(Console.ReadLine());
							
							foreach(Cliente clientex in banco.TodoslosClientes){
								
								if(clientex.Dni==dniCliente){
									
									cuentaelim=clientex;
									
								}
								
							}
							
							foreach(CtaBancaria ctax in banco.TodasCuentas){
								
								if(ctax.NumeroCta==cuentaEliminar){
									
									borrarCta=ctax;
									
								}
								
							}
							
							banco.BajaCuenta(cuentaEliminar);
							
							banco.EliminarCliente(dniCliente);
							
							cuentaelim.EliminarCuenta(borrarCta);
							
							Console.WriteLine("Cuenta y cliente eliminados");
							
							datos=false;
						}
						
						else {
							
							Console.Write("Ingrese numero de cuenta a borrar: ");
							
							int cuentaEliminar = int.Parse(Console.ReadLine());
							
							
							banco.BajaCuenta(cuentaEliminar);
							
							Console.WriteLine("Cuenta eliminada");
							
							datos=false;
							
						}
						
					}
					
					
				} catch(FormatException){
					
					Console.WriteLine("Ingrese valores numericos");
					
				} catch(CuentaExistenteExcepcion){
					
					Console.WriteLine("Cuenta inexistente");
				}
				
			}
			
		}
		
		public static void OpcionC(Banco banco){
			
			foreach(Cliente clienteX in banco.TodoslosClientes){
				
				if(clienteX.CuentasCliente.Count>1){
					
					Console.WriteLine(clienteX.ToString());
					
				}
				
				
			}
			
			Console.WriteLine("No hay clientes con mas de una cuenta\n");


			
			
		}
		
		public static void OpcionD (Banco banco){
			
			bool datos = true;
			
			foreach (CtaBancaria ctaX in banco.TodasCuentas){
				
				Console.WriteLine(ctaX.ToString());
			}
			
			while(datos){

					try{
						Console.Write("Ingrese el numero de cuenta: ");
						int cta= int.Parse(Console.ReadLine());
						
						Console.Write("Ingrese el monto que desea extraer: ");
						double montoExt= double.Parse(Console.ReadLine());
						
						banco.Extraer(cta,montoExt);
						
						Console.WriteLine("\n¡Extraccion realizada con exito!");
						
						datos=false;

						
					} catch (FormatException) {
						
						Console.WriteLine("Solo se permiten datos numericos");
						
					} catch (CuentaExistenteExcepcion) {
						
						Console.WriteLine("Esta cuenta no se encuentra registrada");
						
					} catch (SaldoInsuficienteException) {
						
						Console.WriteLine("\nSaldo Insuficiente\n");
						
					} catch (Exception) {
						
						Console.WriteLine("INTERNAL ERROR. Ocurrio un error inesperado");
					}
				 
			}
		}
		
		
		public static void OpcionE(Banco banco){
			
			bool datos=true;
			
			while(datos){
				
				try{
					
					Console.Write("Ingrese el numero de cuenta: ");
					int cta= int.Parse(Console.ReadLine());
					
					Console.Write("Ingrese el monto a depositar: ");
					double deposito = double.Parse(Console.ReadLine());
					
					banco.Depositar(cta,deposito);
					
					datos=false;
					
					
				}catch(FormatException){
					
					Console.WriteLine("Solo se permiten valores numericos");
					
				}catch(CuentaExistenteExcepcion){
					
					Console.WriteLine("Cuenta inexistente");
					
				}catch(LimiteCajaException){
					
					Console.WriteLine("Este monto supera el limite de efectivo de la caja de ahorros");
					
				}catch(Exception){
					
					Console.WriteLine("INTERNAL ERROR. Ocurrio un error inesperado.");
					
				}
				
			}
			
		}
		
		public static void OpcionF (Banco banco){
			
			foreach(CtaBancaria cuentaX in banco.TodasCuentas){
				
				Console.WriteLine(cuentaX);
			}
			
			
			
		}
		
		public static void OpcionG (Banco banco){
			
			foreach(Cliente clienteX in banco.TodoslosClientes){
				
				Console.WriteLine(clienteX);
				
			}
			
		}
		
		
	}
}
