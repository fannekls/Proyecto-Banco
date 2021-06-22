using System;

namespace ProyectoBanco
{
	/// <summary>
	/// Description of Option.
	/// </summary>
	public abstract class Option
	{
		public abstract void Execute(Banco banco);
	}
}
