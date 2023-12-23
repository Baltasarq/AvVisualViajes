// AvVisualViajes (c) 2021/23 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core.Autobuses {
	public class Metropolitano: Autobus {
        /// <summary>Asientos totales</summary>
        public const int NumAsientosTotal = 45;
        /// <summary>Velocidad tope del bus.</summary>
        public const double MaxVelocidad = 90;
        /// <summary>Nombre de este transporte.</summary>
		public const string Id = "Autocar metropolitano";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Viajes.Core.Autobuses.Metropolitano"/> class.
        /// </summary>
        public Metropolitano()
            :base( NumAsientosTotal )
        {
        }
        
        /// <summary>
        /// Retorna la velocidad tope del bus.
        /// </summary>
        /// <value>Un valor real entre 60 y 200.</value>
        public override double VelocidadMaxima => MaxVelocidad;

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.Autobuses.Metropolitano"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.Autobuses.Metropolitano"/>.</returns>
		public override string ToString()
		{
			return Id + base.ToString();
		}
	}
}

