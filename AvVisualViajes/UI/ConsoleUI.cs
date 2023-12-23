// AvVisualViajes (c) 2021/23 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.UI {
    using System;
    
    using Core;
    

	class ConsoleUI {
		public static int Menu()
		{
			int toret = 0;

			Console.WriteLine( "\nViajes Dinamarca-Italia-Alemania\n" );
			Console.WriteLine( "1. Lista recorridos" );
			Console.WriteLine( "2. Inserta nuevo recorrido" );
			Console.WriteLine( "0. Fin" );

			do {
				Console.WriteLine( "\nSelecciona (0-2): " );

				if ( !int.TryParse( Console.ReadLine(), out toret ) ) {
					toret = -1;
				}
			} while( toret < 0 && toret > 2 );

			return toret;
		}

		public static Viaje PideRecorrido()
		{
			string inic;
			string dest;
			int kms = -1;

			Console.WriteLine( "Inicio: " );
			inic = Console.ReadLine() ?? "";

			Console.WriteLine( "Destino: " );
			dest = Console.ReadLine() ?? "";

			while( kms < 0 ) {
				Console.WriteLine( "Kms: " );
				if ( !int.TryParse( Console.ReadLine(), out kms ) ) {
					kms = -1;
				}
			}

			return new Viaje( inic, dest, kms );
		}

		public static void MainLoop(string[] args)
		{
			int op;
			var viajes = XmlRegistroViajes.RecuperaXml();

			op = Menu();
			while( op != 0 ) {
				switch( op ) {
				case 1:
					Console.WriteLine( viajes.ToString() );
					break;
				case 2:
					viajes.Add( PideRecorrido() );
					break;
				}

				op = Menu();
			}

			new XmlRegistroViajes( viajes ).GuardaXml();
			return;
		}
	}
}
