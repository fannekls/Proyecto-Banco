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
			
			
			if(!ExisteCuenta(numeroCuenta)){
				
				CtaBancaria nuevaCuenta= new CtaBancaria(numeroCuenta,apellido,dniTitular,saldo);
				cuentasBancarias.Add(nuevaCuenta);
			}
			
			else {
				
				
				Console.WriteLine("Ya existe una cuenta con numero");
				
				throw new CuentaExistenteExcepcion();
			}
		}
		
		public void BajaCuenta(int nroCuenta){
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				if(cuentaX.NumeroCta==nroCuenta){
					
					cuentasBancarias.Remove(cuentaX);
				}
				else {
					
					Console.WriteLine("Cuenta inexistente");
				}
			}
		}
		
		public void Depositar (int numeroCuenta,double monto){
			
			CtaBancaria cuentaDeposito = null;
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				if(cuentaX.NumeroCta==numeroCuenta){
					
					cuentaDeposito=cuentaX;
				}
			}
			
			if(cuentaDeposito == null){
				
				throw new CuentaExistenteExcepcion();
				
			}
			
			if((cuentaDeposito.Saldo+monto) > (Math.Pow(1.7976931348623158, 308))){
				
				throw new LimiteCajaException();
				
			}
			
			else {
				
				cuentaDeposito.Saldo=cuentaDeposito.Saldo+monto;
			}
			
		}
		
		public void Extraer (int numeroCuenta,double monto){
			
			CtaBancaria cuentadeExtraccion = null;
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				if(cuentaX.NumeroCta==numeroCuenta){
					
					cuentadeExtraccion=cuentaX;
				}
			}
			
			
			if (cuentadeExtraccion == null){
				
				
				throw new CuentaExistenteExcepcion();
			}
			
			
			if(cuentadeExtraccion.Saldo<monto){
				
				throw new SaldoInsuficienteException();
				
			}
			
			else{
				
				cuentadeExtraccion.Saldo = cuentadeExtraccion.Saldo - monto;
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
		
		public ArrayList TodasCuentas{
			
			get {return cuentasBancarias;}
			
		}
		

	}
}
