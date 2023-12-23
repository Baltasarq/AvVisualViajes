// AvVisualViajes (c) 2021/23 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core.Recorridos {
	public class Urbano: Recorrido {
        /// <summary>Tiempo transporte va a máxima velocidad.</summary>
        public const double PorcentajeMaxVelocidad = 0.1;
        /// <summary>Nombre de este recorrido.</summary>
		public const string Id = "Urbano";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Viajes.Urbano"/> class.
        /// </summary>
        /// <param name="kms">Distancia total.</param>
		public Urbano(double kms)
				: base( kms )
		{
		}
        
        /// <summary>
        /// Retorna el porcentaje de tiempo que el bus puede ir a tope.
        /// </summary>
        /// <value>Un valor real entre 0 y 1.</value>
        public override double PorcentajeVMaxima => PorcentajeMaxVelocidad;

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Urbano"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Urbano"/>.</returns>
		public override string ToString()
		{
			return Id + "\n\t" + base.ToString();
		}
	}
}
