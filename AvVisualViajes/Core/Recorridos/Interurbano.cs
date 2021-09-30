// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core.Recorridos {
	public class Interurbano: Recorrido {
        /// <summary>Tiempo transporte va a máxima velocidad.</summary>
        public const double PorcentajeMaxVelocidad = 0.8;
        // <summary>El nombre del recorrido.</summary>
		public const string Id = "Interurbano";

		public Interurbano(double kms)
				: base( kms )
		{
		}
        
        /// <summary>
        /// Retorna el porcentaje de tiempo que el bus puede ir a tope.
        /// </summary>
        /// <value>Un valor real entre 0 y 1.</value>
        public override double PorcentajeVMaxima => PorcentajeMaxVelocidad;

		public override string ToString ()
		{
			return Id + "\n\t" + base.ToString();
		}
	}
}
