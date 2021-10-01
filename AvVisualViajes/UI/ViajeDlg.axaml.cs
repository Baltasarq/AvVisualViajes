// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.UI {
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Markup.Xaml;
    
    
    public partial class ViajeDlg : Window
    {
        public ViajeDlg()
            : this( DefaultOrg, DefaultDst, DefaultKms )
        {
        }
        
        public ViajeDlg(string org = DefaultOrg, string dest = DefaultDst, double kms = DefaultKms)
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            var btOk = this.FindControl<Button>( "BtOk" );
            var btCancel = this.FindControl<Button>( "BtCancel" );
            var edOrg = this.FindControl<TextBox>( "EdOrg" );
            var edDest = this.FindControl<TextBox>( "EdDst" );
            var edKms = this.FindControl<NumericUpDown>( "EdKms" );

            btOk.Click += (_, _) => this.OnExit();
            btCancel.Click += (_, _) => this.OnCancelClicked();

            edOrg.Text = org;
            edDest.Text = dest;
            edKms.Value = kms;
            this.IsCancelled = false;
        }

        void InitializeComponent()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            AvaloniaXamlLoader.Load(this);
        }

        void OnCancelClicked()
        {
            this.IsCancelled = true;
            this.OnExit();
        }

        void OnExit()
        {
            this.Close();
        }

        public string Org {
            get => this.FindControl<TextBox>( "EdOrg" ).Text.Trim();
        }
        
        public string Dst {
            get => this.FindControl<TextBox>( "EdDst" ).Text.Trim();
        }
        
        public double Kms {
            get => this.FindControl<NumericUpDown>( "EdKms" ).Value;
        }
        
        public bool IsCancelled {
            get;
            private set;
        }
        
        const string DefaultOrg = "Ourense";
        const string DefaultDst = "Madrid";
        const double DefaultKms = 500;
    }
}
