// AvVisualViajes (c) 2021/23 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core.Autobuses {
    /// <summary>Autocar de larga distancia: nacional, internacioal...</summary>
	public class LargaDistancia: Autobus {
        /// <summary>Asientos totales</summary>
        public const int NumAsientosTotal = 80;
        /// <summary>Velocidad tope.</summary>
        public const double MaxVelocidad = 120;
        /// <summary>El nombre del transporte.</summary>
		public const string Id = "Autocar larga distancia";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Viajes.Core.Autobuses.LargaDistancia"/> class.
        /// </summary>
        public LargaDistancia()
            :base( NumAsientosTotal )
        {
        }
        
        /// <summary>
        /// Retorna la velocidad tope del bus.
        /// </summary>
        /// <value>Un valor real entre 60 y 200.</value>
        public override double VelocidadMaxima => MaxVelocidad;

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.Autobuses.LargaDistancia"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.Autobuses.LargaDistancia"/>.</returns>
		public override string ToString()
		{
			return Id + base.ToString();
		}
	}
}
