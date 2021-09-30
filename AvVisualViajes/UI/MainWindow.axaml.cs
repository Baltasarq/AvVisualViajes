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

           /* var opExit = this.FindControl<MenuItem>( "OpExit" );
            var opAbout = this.FindControl<MenuItem>( "OpAbout" );
            var opInsert = this.FindControl<MenuItem>( "OpInsert" );
            var btInsert = this.FindControl<Button>( "BtInsert" );

            opExit.Click += (_, _) => this.OnExit();
            opAbout.Click += (_, _) => this.OnAbout();
            btInsert.Click += (_, _) => this.OnInsert(); 
            opInsert.Click += (_, _) => this.OnInsert();
            this.Closed += (_, _) => this.OnClose();
            */
            this.RegistroViajes = XmlRegistroViajes.RecuperaXml();
            this.BuildDataGrid();
        }

        void InitializeComponent()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AvaloniaXamlLoader.Load(this);
        }

        void BuildDataGrid()
        {
            var tbDesc = this.FindControl<TextBlock>( "TbDesc" );
            //var dtTrips = this.FindControl<DataGrid>( "DtTrips" );

            //dtTrips.Items = this.RegistroViajes;
            tbDesc.Text = this.RegistroViajes.ToString();
            
            this.RegistroViajes.Add( new Viaje("Ourense", "Madrid", 500 ) );
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
