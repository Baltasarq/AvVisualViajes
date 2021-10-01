// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.UI {
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Markup.Xaml;

    using Core;

    
    public partial class MainWindow : Window {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            var opExit = this.FindControl<MenuItem>( "OpExit" );
            var opAbout = this.FindControl<MenuItem>( "OpAbout" );
            var opInsert = this.FindControl<MenuItem>( "OpInsert" );
            var btInsert = this.FindControl<Button>( "BtInsert" );
            var dtTrips = this.FindControl<DataGrid>( "DtTrips" );

            opExit.Click += (_, _) => this.OnExit();
            opAbout.Click += (_, _) => this.OnAbout();
            btInsert.Click += (_, _) => this.OnInsert(); 
            opInsert.Click += (_, _) => this.OnInsert();
            this.Closed += (_, _) => this.OnClose();
            dtTrips.SelectionChanged += (_, _) => this.OnTripSelected();

            this.RegistroViajes = XmlRegistroViajes.RecuperaXml();
            dtTrips.Items = this.RegistroViajes;
        }

        void InitializeComponent()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AvaloniaXamlLoader.Load(this);
        }
        
        void OnTripSelected()
        {
            var dtTrips = this.FindControl<DataGrid>( "DtTrips" );
            var lblDesc = this.FindControl<Label>( "LblDesc" );
            Viaje? viaje = (Viaje) dtTrips.SelectedItem;

            if ( viaje != null )
            {
                lblDesc.Content = viaje.Autobus
                                  + string.Format(
                                      ": {0:00.0} horas", viaje.Duracion );
            }
        }
        
        void OnClose()
        {
            new XmlRegistroViajes( this.RegistroViajes ).GuardaXml();
        }

        void OnExit()
        {
            this.OnClose();
            this.Close();
        }

        void OnAbout()
        {
            new AboutWindow().ShowDialog( this );
        }

        async void OnInsert()
        {
            var dtTrips = this.FindControl<DataGrid>( "DtTrips" );
            var viajeDlg = new ViajeDlg();
            await viajeDlg.ShowDialog( this );

            if ( !viajeDlg.IsCancelled ) {
                this.RegistroViajes.Add(
                    new Viaje( viajeDlg.Org, viajeDlg.Dst, viajeDlg.Kms ) );
            }

            return;
        }

        public RegistroViajes RegistroViajes {
            get;
        }
    }
}
