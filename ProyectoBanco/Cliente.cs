using System.Collections;
using System;

namespace ProyectoBanco
{

	public class Cliente
	{
		//Atributos
		
		private string nombre, apellido, email, direccion;
		private int dni, telefono;
		//private ArrayList cuentasCliente;
		
		
		//Constructores
		
		
		public Cliente(string nombre, string apellido, int dni, string direccion, int telefono, string email)
		{
			this.nombre=nombre;
			this.apellido=apellido;
			this.dni=dni;
			this.direccion=direccion;
			this.telefono=telefono;
			this.email=email;
			//this.cuentasCliente= new ArrayList ();
		}
		
		//Getters y setters
		public string Nombre{
			get{return nombre;}
			set{nombre=value;}
		}
		public string Apellido{
			get{return apellido;}
			set{apellido=value;}
		}
		public int Dni{
			get{return dni;}
			set{dni=value;}
		}
		public string Direccion{
			get{return direccion;}
			set{direccion=value;}
		}
		public int Telefono{
			get{return telefono;}
			set{telefono=value;}
		}
		public string Email{
			get{return email;}
			set{email=value;}
		}
		
		/**
		public ArrayList CuentasCliente {
			
			get{return cuentasCliente;}
		}
		
		public void EliminarCuenta(CtaBancaria cta){
			
			cuentasCliente.Remove(cta);
			
		}
		
		public void AgregarCuenta (CtaBancaria cta){
			
			cuentasCliente.Add(cta);
			
		}*/
		
		/**
		public override string ToString(){

			return string.Format("Nombre: {0}\n" +
			                     "Apellido: {1}\n" +
			                     "Email: {2}\n" +
			                     "Direccion: {3}\n" +
			                     "Dni: {4}\n" +
			                     "Telefono: {5}\n" +
			                     "Cuentas: {6}" +
			                     "\n", nombre, apellido, email, direccion, dni, telefono, cuentasCliente.Count);
		}*/
		
		public override string ToString(){

			return string.Format("Nombre: {0}\n" +
			                     "Apellido: {1}\n" +
			                     "Email: {2}\n" +
			                     "Direccion: {3}\n" +
			                     "Dni: {4}\n" +
			                     "Telefono: {5}\n" +
			                     "\n", nombre, apellido, email, direccion, dni, telefono);
		}
	}
}
