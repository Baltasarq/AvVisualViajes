// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core {
    using System;
    
    using Recorridos;
    
    
	public abstract class Recorrido {    
		protected Recorrido(double kms)
		{
            if ( kms < 1 ) {
                throw new ArgumentException( "Kms no debe ser inferior a 1" );
            }

			this.Kms = kms;
		}
        
        /// <summary>
        /// Crea el recorrido que mejor se adapta a los kms. dados.
        /// </summary>
        /// <returns>El <see cref="Recorrido"/> adecuado.</returns>
        /// <param name="kms">Los kms. del viaje.</param>
        public static Recorrido Crea(double kms)
        {
            Recorrido toret;

            if ( kms < 50 ) {
                toret = new Urbano( kms );
            }
            else
            if (kms < 100 ) {
                toret = new Interurbano( kms );
            }
            else
            if (kms < 200 ) {
                toret = new Provincial( kms );
            }
            else
            if (kms < 1000 ) {
                toret = new Nacional( kms );
            }
            else {
                toret = new Internacional( kms );
            }
            
            if ( toret == null ) {
                throw new System.ArgumentException( "Kms: "
                                + kms
                                + " no se adaptan a recorrido alguno" );
            }

            return toret;
        }        
        
        /// <summary>
        /// Retorna el porcentaje de tiempo que el bus puede ir a tope.
        /// </summary>
        /// <value>Un valor real entre 0 y 1.</value>
        public virtual double PorcentajeVMaxima => 0.1;
        
        /// <summary>
        /// Distancia total a recorrer.
        /// </summary>
        /// <value>Los kms, como num. real.</value>
        public double Kms {
            get;
        }

        /// <summary>
        /// Una cadena que resume la info resumida de un recorrido.
        /// </summary>
        /// <returns>La info como cadena de caracteres.</returns>
        public override string ToString()
        {
            return string.Format("Kms: {0:000.00}, Porcentaje VMax: {1}%",
                                    this.Kms, this.PorcentajeVMaxima * 100 );
        }
	}
}
