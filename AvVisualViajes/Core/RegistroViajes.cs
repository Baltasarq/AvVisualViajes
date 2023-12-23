// AvVisualViajes (c) 2021/23 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core {
    using System.Text;
	using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
	
    /// <summary>
    /// Esta clase deriva de ObservableCollection para poder
    /// ser utilizada como fuente de datos en una interfaz de usuario.
    /// En cuanto al resto, se comporta como una List<Viaje>.
    /// </summary>
	public class RegistroViajes: ObservableCollection<Viaje> {
		/// <summary>
        /// Crea un <see cref="T:Viajes.Core.RegistroViajes"/> sin viajes.
        /// </summary>
		public RegistroViajes()
			:this( new List<Viaje>() )
		{
		}
        
        /// <summary>
        /// Crea un <see cref="T:Viajes.Core.RegistroViajes"/>
        /// con los viajes dados.
        /// </summary>
        /// <param name="viajes">Varios <see cref="Viaje"/> de partida.</param>
        public RegistroViajes(IEnumerable<Viaje> viajes)
			:base(viajes)
        {
        }

        /// <summary>
        /// Inserta al final varios viajes dados.
        /// </summary>
        /// <param name="vs">Los <see cref="Viaje"/>s a insertar.</param>
		public void AddRange(IEnumerable<Viaje> vs)
		{
			foreach (Viaje v in vs)
			{
				this.Add( v );
			}
		}

        /// <summary>
        /// Copia los viajes a partir de la pos. dada a un nuevo vector.
        /// </summary>
        /// <returns>Un vecctor con todos los viajes.</returns>
        public Viaje[] ToArray()
        {
	        var toret = new Viaje[ this.Count ];
	        
			this.CopyTo( toret, 0 );
			return toret;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.RegistroViajes"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.RegistroViajes"/>.</returns>
		public override string ToString()
		{
			var toret = new StringBuilder();
			
			foreach(Viaje v in this) {
				toret.AppendLine( v.ToString() );
			}

			return toret.ToString();
		}
    }
}
