// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core {
    using System;
    
    public class Viaje {
        ///<summary>Horas disponibles en una jornada de viaje.</summary>
        const int NumHorasPorJornada = 6;
    
        public Viaje(string inicio, string destino, double kms)
        {
            if ( string.IsNullOrWhiteSpace( inicio ) ) {
                throw new ArgumentException( "Inicio incorrecto, sin datos" );
            }
            
            if ( string.IsNullOrWhiteSpace( destino ) ) {
                throw new ArgumentException( "Destino incorrecto, sin datos" );
            }
            
            this.Inicio = inicio.Trim();
            this.Destino = destino.Trim();
            this.Recorrido = Recorrido.Crea( kms );
            this.Autobus = Autobus.Crea( kms );
        }
        
        /// <summary>
        /// Calcula la hora de llegada.
        /// </summary>
        /// <returns>La hora de llegada, como <see cref="DateTime"/></returns>
        /// <param name="partida">
        /// La hora de partida, como <see cref="DateTime"/>.
        /// Si no se incluye, se asume que es este justo momento.
        /// </param>
        public DateTime CalculaHoraLlegada(DateTime? partida = null)
        {
            // Calcula, 1 jornada = 6 horas
            DateTime toret = partida ?? DateTime.Now;
            double duracion = this.Duracion;
            int numDias = (int) duracion / NumHorasPorJornada;
            int numHoras;
            int numMinutos;
            
            duracion = duracion % NumHorasPorJornada;
            numHoras = (int) duracion;
            numMinutos = (int) ( 60.0 * ( duracion - ( (int) duracion ) ) );

            // Ajustar fecha y hora
            toret = toret.AddDays( numDias );
            toret = toret.AddHours( numHoras );
            toret = toret.AddMinutes( numMinutos );
            
            return toret;
        }

        public override bool Equals(object? otro)
        {
            bool toret = false;
            
            if ( otro is Viaje otroViaje ) {
                toret = ( this.Inicio == otroViaje.Inicio
                          && this.Destino == otroViaje.Destino
                          && this.Kms == otroViaje.Kms );
            }

            return toret;
        }

        public override int GetHashCode()
        {
            return 11 * this.Inicio.GetHashCode()
                 + 13 * this.Destino.GetHashCode()
                 + 17 * this.Kms.GetHashCode();
        }
        
        /// <summary>Obtiene el kilometraje del recorrido</summary>
        /// <value>El kilometraje, como num. real.</value>
        public double Kms => this.Recorrido.Kms;
        
        /// <summary>
        /// El inicio del viaje.
        /// </summary>
        /// <value>El inicio, como cadena.</value>
        public string Inicio {
            get; private set;
        }
        
        /// <summary>
        /// El destino del viaje.
        /// </summary>
        /// <value>El destino, como cadena.</value>
        public string Destino {
            get; private set;
        }
        
        /// <summary>
        /// El recorrido correspondiente a los kilómetros con ese inicio y final.
        /// </summary>
        /// <value>El objeto <see cref="Recorrido"/>.</value>
        public Recorrido Recorrido {
            get; private set;
        }
        
        /// <summary>El transporte a emplear en el recorrido.</summary>
        /// <value>El objeto <see cref="Autobus"/>.</value>
        public Autobus Autobus {
            get; private set;
        }
        
        /// <summary>
        /// Obtiene el num. de horas del viaje.
        /// </summary>
        /// <value>El num. de horas como real.</value>
        public double Duracion {
            get {
                double porcentajeVMin = 1.0 - this.Recorrido.PorcentajeVMaxima;
                double distanciaVMin = this.Kms * porcentajeVMin;
                double distanciaVMax = this.Kms * this.Recorrido.PorcentajeVMaxima;

                return ( distanciaVMin / Autobus.VelocidadMinima )
                       + ( distanciaVMax / this.Autobus.VelocidadMaxima );
            }
        }

        /// <summary>
        /// La llegada desde este mismo momento.
        /// </summary>
        /// <seealso cref="CalculaHoraLlegada"/>
        public DateTime LlegadaDesdeAhora {
            get {
                return this.CalculaHoraLlegada();
            }
        }
        
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.Viaje"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Viajes.Core.Viaje"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "Recorrido: de {0} a {1}, {2}\n\tAutobus: {3}\n\tHoras: {4:00.00}",
                this.Inicio, this.Destino,
                this.Recorrido, this.Autobus, this.Duracion );
        }
    }
}
