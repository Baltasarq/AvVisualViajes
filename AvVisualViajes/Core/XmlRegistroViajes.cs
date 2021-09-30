// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core {
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    
    
    public class XmlRegistroViajes {
        public const string ArchivoXml = "viajes.xml";
        const string EtqViajes = "viajes";
        const string EtqViaje = "viaje";
        const string EtqInicio = "inicio";
        const string EtqDestino = "destino";
        const string EtqKms = "kms";

        public XmlRegistroViajes(RegistroViajes rv)
        {
            this.RegistroViajes = rv;
        }

        /// <summary>
        /// Guarda la lista de viajes como xml.
        /// </summary>
        public void GuardaXml()
        {
            this.GuardaXml( ArchivoXml );
        }
        
        /// <summary>
        /// Guarda la lista de viajes como XML.
        /// <param name="nf">El nombre del archivo.</param>
        /// </summary>
        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement( EtqViajes );
            
            foreach(Viaje viaje in this.RegistroViajes) {
                root.Add(
                    new XElement( EtqViaje,
                            new XAttribute( EtqInicio, viaje.Inicio ),
                            new XAttribute( EtqDestino, viaje.Destino ),
                            new XElement( EtqKms, viaje.Kms.ToString() ) ) );
            }
            
            doc.Add( root );
            doc.Save( nf );
        }

        public RegistroViajes RegistroViajes {
            get;
        }

        /// <summary>
        /// Recupera los viajes desde un archivo XML.
        /// </summary>
        /// <returns>Un <see cref="RegistroViajes"/> con los
        /// <see cref="Viaje"/>'s.</returns>
        /// <param name="f">El nombre del archivo.</param>
		public static RegistroViajes RecuperaXml(string f)
		{
			var toret = new RegistroViajes();
            
            try {
                var doc = XDocument.Load( f );
				string rootTag = doc?.Root?.Name.ToString() ?? ""; 
                
                if ( doc?.Root != null
                  && rootTag == EtqViajes )
                {
                    var viajes = doc.Root.Elements( EtqViaje );
                    
                    foreach(XElement viajeXml in viajes) {
	                    string inicio =
		                    (string?) viajeXml.Attribute( EtqInicio ) ?? "ORG";
	                    string dest =
		                    (string?) viajeXml.Attribute( EtqDestino ) ?? "DEST";
	                    double km = 
		                    Convert.ToDouble(
			                    (string?) viajeXml.Element( EtqKms ) ?? "0" );
	                    
                        toret.Add( new Viaje( inicio, dest, km ) );
                    }
                }
            }
            catch(XmlException)
            {
                toret.Clear();
            }
            catch(IOException)
            {
                toret.Clear();
            }
                
            return toret;
        }

        /// <summary>
        /// Crea un registro de viajes con la lista de viajes recuperada
        /// del archivo por defecto.
        /// </summary>
        /// <returns>Un <see cref="RegistroViajes"/>.</returns>
		public static RegistroViajes RecuperaXml()
		{
			return RecuperaXml( ArchivoXml );
		}
    }
}
