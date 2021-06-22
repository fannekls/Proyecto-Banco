using System.Collections;
using System;

namespace ProyectoBanco
{
	
	public class Banco
	{
		//Atributos
		
		private string nombreBanco;
		private ArrayList cuentasBancarias;
		private ArrayList clientes;
		
		//Constructor
		
		public Banco(string nombreBanco)
		{
			this.nombreBanco=nombreBanco;
			this.cuentasBancarias = new ArrayList();
			this.clientes = new ArrayList();
		}
		
		//Getters y Setters
		
		public string NombreBanco{
			get{return nombreBanco;}
			set{nombreBanco=value;}
		}
		
		
		//METODOS GESTION DE CLIENTES
		
		public void AgregarCliente (string nombre, string apellido, int dni, string direccion, int telefono, string email){
			bool existeCliente=false;
			
			foreach(Cliente clienteX in clientes){
				if(clienteX.Dni==dni){
					
					existeCliente=true;
					break;
				}
				
			}
			
			if(!existeCliente){
				Cliente nuevoCliente = new Cliente(nombre,apellido,dni,direccion,telefono,email);
				clientes.Add(nuevoCliente);
			}
			
			else{
				
				Console.WriteLine("Este cliente ya existe");
			}
		}
		
		public void EliminarCliente ( int dniCliente ) {
			
			foreach(Cliente clienteX in clientes){
				
				if (clienteX.Dni==dniCliente) {
					
					clientes.Remove(clienteX);
				}
				
				else {
					Console.WriteLine("Cliente no registrado");
				}
			}
		}
		
		public int CantidadClientes (int totalClientes){
			
			
			return clientes.Count;
			
		}
		
		public Cliente VerCliente(int dni){
			
			foreach(Cliente clienteX in clientes){
				
				if(clienteX.Dni==dni){
					
					return clienteX;
				}
			}
			
			Console.WriteLine("No se encontro a este cliente registrado");
			return null;
			
		}
		
		public ArrayList TodoslosClientes{
			
			get {return clientes;}
		}
		
		
		public bool esCliente(int dniCliente){
			
			foreach(Cliente clienteX in clientes){
				
				
				if(clienteX.Dni==dniCliente){
					
					return true;
				}
			}
			
			Console.WriteLine("No existe cliente con este DNI");
			
			return false;
			
		}
		
		public void AgregarcuentasCliente (int dni){
			
			
		}
		
		
		//METODOS GESTION DE CUENTAS BANCARIAS
		
		private bool ExisteCuenta (int numeroCuenta) {
			
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				Console.WriteLine(cuentaX.ToString());
				
				if(cuentaX.NumeroCta==numeroCuenta){
					
					
					return true;
				}
			}
			
			return false;
		}
		
		
		public void AltaCuenta (int numeroCuenta,string apellido, int dniTitular, double saldo){
			
			//Console.WriteLine("pase por aca pelado");
			
			if(!ExisteCuenta(numeroCuenta)){
				
				CtaBancaria nuevaCuenta = new CtaBancaria(numeroCuenta,apellido,dniTitular,saldo);
				
				cuentasBancarias.Add(nuevaCuenta);
				
				foreach(Cliente cliente in clientes){
					
					if(dniTitular == cliente.Dni){
						cliente.AddNewAcount(nuevaCuenta);
					}
				}
			}
			
			else {
				
				Console.WriteLine("Ya existe una cuenta con este DNI {0}",dniTitular);
			}
		}
		
		public void BajaCuenta(int nroCuenta){
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				if(cuentaX.NumeroCta == nroCuenta){
					
					Console.WriteLine("Eliminando cuenta {0}",nroCuenta);
					cuentasBancarias.Remove(cuentaX);
					break;
					
				} else {
					
					throw new CuentaInexistenteException();
				}
			}
		}
		
		public void Depositar (int numeroCuenta,double monto){
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				if(cuentaX.NumeroCta==numeroCuenta){
					
					cuentaX.Saldo=cuentaX.Saldo+monto;
				}
			}
		}
		
		public void Extraer (int numeroCuenta,double monto){
			
			CtaBancaria cuentaExtraer=null;
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				if(cuentaX.NumeroCta == numeroCuenta){
					cuentaExtraer=cuentaX;
						
				}
			}
			
			if(cuentaExtraer == null){
				throw new Exception("cuenta no existe");
			}
			
			if(cuentaExtraer.Saldo > monto){
				cuentaExtraer.Saldo=cuentaExtraer.Saldo-monto;
			}else{
				throw new SaldoInsuficienteException(cuentaExtraer.Saldo.ToString());
			}
			
		}
		
		public int CantidadCuentas (int totalCuentas){
			
			
			return cuentasBancarias.Count;
			
		}
		
		public CtaBancaria verCuenta (int numCuenta){
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				if(cuentaX.NumeroCta==numCuenta){
					
					return cuentaX;
				}
				
			}
			
			Console.WriteLine("No existe una cuenta con este numero");
			
			return null;
		}
		
		public ArrayList TodasCuentas {
			
			get {return cuentasBancarias;}
		}
	}
}
