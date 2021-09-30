// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core {
    using System.Text;
    using System.ComponentModel;
    using System.Collections;
	using System.Collections.Generic;
    
	
	public class RegistroViajes: IEnumerable<Viaje>, INotifyPropertyChanged {
		/// <summary>
        /// Crea un <see cref="T:Viajes.Core.RegistroViajes"/> sin viajes.
        /// </summary>
		public RegistroViajes()
		{
			this.viajes = new List<Viaje>();
		}
        
        /// <summary>
        /// Crea un <see cref="T:Viajes.Core.RegistroViajes"/>
        /// con los viajes dados.
        /// </summary>
        /// <param name="viajes">Varios <see cref="Viaje"/> de partida.</param>
        public RegistroViajes(IEnumerable<Viaje> viajes)
            :this()
        {
            this.viajes.AddRange( viajes );
        }

        /// <summary>
        /// Inserta un viaje dado al final de la lista.
        /// </summary>
        /// <param name="v">Un objeto <see cref="Viaje"/>.</param>
		public void Add(Viaje v)
		{
			this.viajes.Add( v );
			OnPropertyChanged( nameof( RegistroViajes ) );
		}

        /// <summary>
        /// Elimina un viaje dado.
        /// </summary>
        /// <returns>True si se ha eliminado, False en otro caso.</returns>
        /// <param name="v">El <see cref="Viaje"/> a eliminar.</param>
		public bool Remove(Viaje v)
		{
			return this.viajes.Remove( v );
		}

        /// <summary>
        /// Elimina un viaje en la pos. i.
        /// </summary>
        /// <param name="i">La pos. a eliminar</param>
		public void RemoveAt(int i)
		{
			this.viajes.RemoveAt( i );
		}

        /// <summary>
        /// Inserta al final varios viajes dados.
        /// </summary>
        /// <param name="vs">Los <see cref="Viaje"/>s a insertar.</param>
		public void AddRange(IEnumerable<Viaje> vs)
		{
			this.viajes.AddRange( vs );
		}

        /// <summary>
        /// Devuelve el total de viajes guardados en este registro.
        /// </summary>
        /// <value>El total de viajes, como entero.</value>
		public int Count {
			get { return this.viajes.Count; }
		}

        /// <summary>
        /// Elimina todos los viajes almacenados.
        /// </summary>
		public void Clear()
		{
			this.viajes.Clear();
		}

        /// <summary>
        /// Copia los viajes a partir de la pos. dada a un nuevo vector.
        /// </summary>
        /// <returns>Un vecctor con todos los viajes.</returns>
        public Viaje[] ToArray()
        {
	        var toret = new Viaje[ this.viajes.Count ];
	        
			this.viajes.CopyTo( toret, 0 );
			return toret;
        }

		// Enumerador aplicado a Viaje.
		IEnumerator<Viaje> IEnumerable<Viaje>.GetEnumerator()
	 	{
	 		foreach(var v in this.viajes) {
	 			yield return v;
	 		}
	 	}
	 			
	 	// Enumerador sin tipo
	 	IEnumerator IEnumerable.GetEnumerator()
	 	{
	 			foreach(var v in this.viajes) {
	 				yield return v;
	 			}
	 	}

		// Indizador
		public Viaje this[int i] {
			get { return this.viajes[ i ]; }
			set { this.viajes[ i ] = value; }
		}

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.RegistroViajes"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.RegistroViajes"/>.</returns>
		public override string ToString()
		{
			var toret = new StringBuilder();

			foreach(Viaje v in this.viajes) {
				toret.AppendLine( v.ToString() );
			}

			return toret.ToString();
		}
        
        protected void OnPropertyChanged(string propertyName)
        {
	        if ( this.PropertyChanged != null ) {
		        this.PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
	        }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
		List<Viaje> viajes;
	}
}
