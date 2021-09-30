// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core.Autobuses {
	public class Intercity: Autobus {
        /// <summary>Asientos totales</summary>
        public const int NumAsientosTotal = 50;
        /// <summary>Velocidad tope</summary>
        public const double MaxVelocidad = 100;
        /// <summary>Nombre de este transporte.</summary>
		public const string Id = "Autocar InterCity";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Viajes.Core.Autobuses.Intercity"/> class.
        /// </summary>
        public Intercity()
            :base( NumAsientosTotal )
        {
        }
        
        /// <summary>
        /// Retorna la velocidad tope del bus.
        /// </summary>
        /// <value>Un valor real entre 60 y 200.</value>
        public override double VelocidadMaxima => MaxVelocidad;

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.Autobuses.Intercity"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.Autobuses.Intercity"/>.</returns>
		public override string ToString()
		{
			return Id + base.ToString();
		}
	}
}
