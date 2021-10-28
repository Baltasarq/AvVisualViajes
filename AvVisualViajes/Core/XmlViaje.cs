// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core {
    using System;
    using System.Xml.Linq;
    using System.Globalization;
    
    
    /// <summary>Crea y recupera XML para un objeto <see cref="Viaje"/> dado.</summary>
    public class XmlViaje {
        /// <summary>Etiqueta XML principal para un viaje</summary>
        public const string EtqViaje = "viaje";
        const string EtqInicio = "inicio";
        const string EtqDestino = "destino";
        const string EtqKms = "kms";
        
        /// <summary>Crea un XMLViaje para un <see cref="Viaje"/> dado por parámetro.</summary>
        /// <param name="v">El <see cref="Viaje"/> del que crear el XML.</param>
        public XmlViaje(Viaje v)
        {
            this.Viaje = v;
        }

        /// <summary>Crea un objeto XML con la información del viaje.</summary>
        /// <returns>Un <see cref="XElement"/> con la infor del <see cref="Viaje"/>.</returns>
        public XElement ToXml()
        {
            return new XElement( EtqViaje,
                new XAttribute( EtqInicio, this.Viaje.Inicio ),
                new XAttribute( EtqDestino, this.Viaje.Destino ),
                new XElement( EtqKms, this.Viaje.Kms.ToString( CultureInfo.InvariantCulture ) ) );
        }
        
        /// <summary>El <see cref="Viaje"/> sobre el que actuar.</summary>
        public Viaje Viaje { get; }

        /// <summary>Recupera un <see cref="Viaje"/> desde un <see cref="XElement"/>.</summary>
        /// <param name="node">Un objeto <see cref="XElement"> del que extraer la info.</param>
        /// <returns>Un <see cref="Viaje"/> con los datos obtenidos.</returns>
        /// <seealso cref="ToXml"/>
        public static Viaje FromXml(XElement node)
        {
            string inicio = (string?) node.Attribute( EtqInicio ) ?? "ORG";
            string dest = (string?) node.Attribute( EtqDestino ) ?? "DEST";
            double km = Convert.ToDouble(
                            (string?) node.Element( EtqKms ) ?? "0",
                            CultureInfo.InvariantCulture );
	                    
            return new Viaje( inicio, dest, km );
        }
    }
}
