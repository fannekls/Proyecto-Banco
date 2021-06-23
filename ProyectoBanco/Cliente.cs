using System.Collections;
using System;

namespace ProyectoBanco
{

	public class Cliente
	{
		//Atributos
		
		private string nombre, apellido, email, direccion;
		private int dni, telefono;
		private ArrayList cuentasBancarias;
		
		
		//Constructores
		
		
		public Cliente(string nombre, string apellido, int dni, string direccion, int telefono, string email)
		{
			this.nombre=nombre;
			this.apellido=apellido;
			this.dni=dni;
			this.direccion=direccion;
			this.telefono=telefono;
			this.email=email;
			this.cuentasBancarias= new ArrayList ();
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
		public ArrayList ListaCuentas {
			
			get{return cuentasBancarias;}
		}
		
		public override string ToString(){
			
			string listaCuentas = "";
			
			foreach(CtaBancaria cuentaX in cuentasBancarias){
				
				listaCuentas=listaCuentas + cuentaX.ToString();
			}

			return string.Format("[Cliente Nombre={0}, Apellido={1}, Email={2}, Direccion={3}, Dni={4}, Telefono={5}, CuentasBancarias={6}]", nombre, apellido, email, direccion, dni, telefono, listaCuentas);
		}

	}
}
