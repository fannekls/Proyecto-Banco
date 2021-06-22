using System.Collections;
using System;


namespace ProyectoBanco
{
	class Program {
		public static void Main(string[] args)
		{
			
			Banco galicia = new Banco ("Banco Galicia");
			DatosDefault(galicia);
			
			
			
			bool flag = true;
			
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
				if(menu.ToLower()=="a"){
					
					new OptionA().Execute(galicia);
					
				} else if(menu.ToLower()=="b"){
					OpcionB(galicia);

				} else if(menu.ToLower()=="c"){
					
					Console.WriteLine("_______________Clientes con mas de una cuenta_________________\n");
					
					foreach(Cliente cliente in galicia.TodoslosClientes){
						if(cliente.ListaCuentas.Count>1){
							
							foreach(CtaBancaria cta in cliente.ListaCuentas){
								Console.WriteLine("Apellido: {0} Nro de cuenta: {1} ,saldo: {2}",cta.Apellido, cta.NumeroCta, cta.Saldo);
							}
							
						}
					}
					
					Console.WriteLine("________________________________\n");
					

				} else if(menu.ToLower()=="d"){
					
					bool flagAPB=true;
					
					while(flagAPB){
						
						try{
							Console.WriteLine("Ingrese monto a extraer");
							double montoEx = double.Parse(Console.ReadLine());
							
							Console.WriteLine("Ingrese nro de cuenta");
							int nroCta=int.Parse(Console.ReadLine());
							
							galicia.Extraer(nroCta, montoEx);
							flagAPB=false;
							
						} catch (FormatException ex) {
							
							Console.WriteLine("Error. Ingrese un valor numerico.");
						} catch (SaldoInsuficienteException se) {
							
							Console.WriteLine("Error. Saldo insuficiente");
						}catch (Exception e) {
							
							Console.WriteLine("Error. {0}",e.Message);
						}
						
					}
					

				} else if(menu.ToLower()=="e"){
					
					bool flagAPB=true;
					
					while(flagAPB){
						
						try{
							Console.WriteLine("Ingrese monto a extraer");
							double montoEx = double.Parse(Console.ReadLine());
							
							Console.WriteLine("Ingrese nro de cuenta");
							int nroCta=int.Parse(Console.ReadLine());
							
							galicia.Depositar(nroCta, montoEx);
							flagAPB = false;
							
						} catch (FormatException ex) {
							
							Console.WriteLine("Error. Ingrese un valor numerico.");
						} catch (SaldoInsuficienteException se) {
							
							Console.WriteLine("Error. Saldo insuficiente");
						}catch (Exception e) {
							
							Console.WriteLine("Error. {0}",e.Message);
						}
						
					}
					

				} else if(menu.ToLower()=="f" ){
					
					Console.WriteLine("_______________ver todas las cuentas_________________\n");
					foreach(CtaBancaria cta in galicia.TodasCuentas){
						Console.WriteLine(cta.ToString());
					}
					Console.WriteLine("________________________________\n");
					
				} else if(menu.ToLower()=="g" ){
					
					Console.WriteLine("_______________ver todas les clientes_________________\n");
					
					foreach(Cliente cliente in galicia.TodoslosClientes){
						Console.WriteLine(cliente.ToString());
					}
					
					Console.WriteLine("________________________________\n");
					
				} else if(menu.ToLower()=="h" ){
					
					flag = false;
				}
			}
			
			Console.ReadKey(true);
			
			
			
		}
		
		//OPCIONES MODULARIZADAS
		
		
		public static void OpcionB (Banco banco) {
			
			Console.WriteLine("Eliminacion de CTA Bancaria");
			
			bool operationIsSuccess = false;
			
			while(!operationIsSuccess){
				
				
				try{
					
					Console.WriteLine("Cliente, ingrese el DNI ");
					int dni = int.Parse(Console.ReadLine());
					
					Console.WriteLine("Cliente, ingrese Nro de CTA ");
					int nroCTA = int.Parse(Console.ReadLine());
					
					if(banco.esCliente(dni)){
						
						try{
							
							banco.BajaCuenta(nroCTA);
							
						} catch (CuentaInexistenteException ce){
							Console.WriteLine("Eliminando cliente {0}",dni);
							banco.EliminarCliente(dni);
						}
						
					}else{
						Console.WriteLine("User not exits, user_id : "+ dni);
					}
					
					operationIsSuccess = true;
					
				} catch (FormatException fe){
					
					Console.WriteLine("ERROR, Ingrese solo valores numericos");
				}
			}
		}
		
		//METODOS EXTERNOS
		
		private static void DatosDefault(Banco banco){
			
			banco.AgregarCliente("horacio", "PEPE", 78952221, "calle nueva", 12345678, "hola@chau");
			banco.AltaCuenta(1112,"PEPE",78952221,123165165);
			
			banco.AgregarCliente("matias", "JORGE", 52164821, "calle falsa", 52164821, "chau@hola");
			banco.AltaCuenta(11254,"JORGE",52164821,123165165);
			
			banco.AgregarCliente("Jorge", "NITAL", 30154691, "calle falsa 123", 30154691, "chau@holanda");
			banco.AltaCuenta(323,"NITAL",30154691,123165165);
			
			banco.AgregarCliente("cada mañana", "CORAZON_DE_CEDA", 21875131, "calle true 123", 21875131, "chaucha@holanda");
			banco.AltaCuenta(414,"CORAZON_DE_CEDA",21875131,123165165);
			
			banco.AgregarCliente("cai del cielo", "TILIN_TILIN", 33651281, "calle trucha 123", 21875131, "chauchapapa@holanda");
			banco.AltaCuenta(7541,"TILIN_TILIN",33651281,123165165);
			banco.AltaCuenta(21312,"TILIN_TILIN",33651281,123165165);
		}
		
	}
}