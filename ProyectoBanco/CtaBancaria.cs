
using System;

namespace ProyectoBanco
{

	public class CtaBancaria
	{
		private string apellido;
		private int dniTitular, numeroCta;
		private double saldo;
		
		//Constructores
		public CtaBancaria(int numeroCta, string apellido, int dniTitular, double saldo)
		{
			this.numeroCta=numeroCta;
			this.apellido=apellido;
			this.dniTitular=dniTitular;
			this.saldo=saldo;
		}
		
		//Getters y setters
		
		public string Apellido{
			get{return apellido;}
			set{apellido=value;}
		}
		public int DniTitular {
			get{return dniTitular;}
			set{dniTitular=value;}
		}
		public int NumeroCta{
			get{return numeroCta;}
			set{numeroCta=value;}
		}
		public double Saldo{
			get{return saldo;}
			set{saldo=value;}
		}
		
		public override string ToString()
		{
			return string.Format("Apellido: {0}\n" +
			                     "DNI: {1}\n" +
			                     "Numero: {2}\n" +
			                     "Saldo: {3}\n", apellido, dniTitular, numeroCta, saldo);
		}

	}
}
