// AvVisualViajes (c) 2021/23 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.UI {
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Markup.Xaml;
    using System.Diagnostics;

    using Core;

    
    public partial class MainWindow : Window {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            var opExit = this.GetControl<MenuItem>( "OpExit" );
            var opAbout = this.GetControl<MenuItem>( "OpAbout" );
            var opInsert = this.GetControl<MenuItem>( "OpInsert" );
            var btInsert = this.GetControl<Button>( "BtInsert" );
            var dtTrips = this.GetControl<DataGrid>( "DtTrips" );
            
            Debug.Assert( opExit != null, "opExit not found in XAML" );
            Debug.Assert( opAbout != null, "opAbout not found in XAML" );
            Debug.Assert( opInsert != null, "opInsert not found in XAML" );
            Debug.Assert( btInsert != null, "btInsert not found in XAML" );
            Debug.Assert( dtTrips != null, "btInsert not found in XAML" );

            opExit.Click += (_, _) => this.OnExit();
            opAbout.Click += (_, _) => this.OnAbout();
            btInsert.Click += (_, _) => this.OnInsert(); 
            opInsert.Click += (_, _) => this.OnInsert();
            this.Closed += (_, _) => this.OnClose();
            dtTrips.SelectionChanged += (_, _) => this.OnTripSelected();

            this.RegistroViajes = XmlRegistroViajes.RecuperaXml();
            dtTrips.ItemsSource = this.RegistroViajes;
        }

        void InitializeComponent()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AvaloniaXamlLoader.Load( this );
        }
        
        void OnTripSelected()
        {
            var dtTrips = this.GetControl<DataGrid>( "DtTrips" );
            var lblDesc = this.GetControl<Label>( "LblDesc" );

            Debug.Assert( dtTrips != null, "dtTrips not found in XAML!" );
            Debug.Assert( lblDesc != null, "lblDesc not found in XAML!" );
            
            Viaje? viaje = (Viaje) dtTrips.SelectedItem;

            if ( viaje != null ) {
                lblDesc.Content = $"{viaje.Autobus}: {viaje.Duracion:0:00.0}";
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
