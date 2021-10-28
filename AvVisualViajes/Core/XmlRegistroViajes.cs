// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.Core {
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Collections.Generic;
    
    
    public class XmlRegistroViajes {
        public const string ArchivoXml = "viajes.xml";
        const string EtqViajes = "viajes";

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
            var root = new XElement( EtqViajes );
            
            foreach(Viaje viaje in this.RegistroViajes) {
                root.Add( new XmlViaje( viaje ).ToXml() );
            }
            
            root.Save( nf );
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
                var viajes = doc.Element( EtqViajes )?
                                                    .Elements( XmlViaje.EtqViaje );

                new List<XElement>( viajes ).ForEach(
                    node => toret.Add( XmlViaje.FromXml( node ) ) );
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
