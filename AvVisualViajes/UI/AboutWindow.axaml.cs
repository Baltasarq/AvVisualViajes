// AvVisualViajes (c) 2021/23 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.UI {
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Markup.Xaml;
    using System.Diagnostics;
    
    using AvVisualViajes.Core;


    public partial class AboutWindow : Window {
        public AboutWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            var btOk = this.GetControl<Button>( "BtOk" );
            var txtAbout = this.GetControl<TextBlock>( "TxtAbout" );
            
            Debug.Assert( btOk != null, "btOk no encontrado en XAML!" );
            Debug.Assert( txtAbout != null, "txtAbout no encontrado en XAML!" );

            btOk.Click += (_, _) => this.OnExit();
            txtAbout.Text = AppInfo.Name + " v" + AppInfo.Version
                            + "\n" + AppInfo.Email;
        }

        void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        void OnExit()
        {
            this.Close();
        }
    }
}
