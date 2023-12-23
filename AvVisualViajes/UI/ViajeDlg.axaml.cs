// AvVisualViajes (c) 2021/23 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.UI {
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Markup.Xaml;
    using System.Diagnostics;


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

            var btOk = this.GetControl<Button>( "BtOk" );
            var btCancel = this.GetControl<Button>( "BtCancel" );
            var edOrg = this.GetControl<TextBox>( "EdOrg" );
            var edDest = this.GetControl<TextBox>( "EdDst" );
            var edKms = this.GetControl<NumericUpDown>( "EdKms" );
            
            Debug.Assert( btOk != null, "btOk not found in XAML!" );
            Debug.Assert( btCancel != null, "btCancel not found in XAML!" );
            Debug.Assert( edOrg != null, "edOrg not found in XAML!" );
            Debug.Assert( edDest != null, "edDest not found in XAML!" );
            Debug.Assert( edKms != null, "edKms not found in XAML!" );

            btOk.Click += (_, _) => this.OnExit();
            btCancel.Click += (_, _) => this.OnCancelClicked();

            edOrg.Text = org;
            edDest.Text = dest;
            edKms.Value = (decimal) kms;
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
            get {
                var edOrg = this.GetControl<TextBox>( "EdOrg" );
                
                Debug.Assert( edOrg != null, "edOrg not found in XAML!" );
                return edOrg.Text!.Trim();
            }
        }

        public string Dst {
            get {
                var edDst = this.GetControl<TextBox>( "EdDst" );
                
                Debug.Assert( edDst != null, "edDst not found in XAML!" );
                return edDst.Text!.Trim();
            }
        }
        
        public double Kms {
            get
            {
                var edKms = this.GetControl<NumericUpDown>( "EdKms" );
                
                Debug.Assert( edKms != null, "edKms not found in XAML!" );
                return (double) edKms.Value!;
            }
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
