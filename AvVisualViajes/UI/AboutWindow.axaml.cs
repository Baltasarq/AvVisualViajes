// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.UI {
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Markup.Xaml;
    using AvVisualViajes.Core;
    
    
    public partial class AboutWindow : Window {
        public AboutWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            var btOk = this.FindControl<Button>( "BtOk" );
            var txtAbout = this.FindControl<TextBlock>( "TxtAbout" );

            btOk.Click += (sender, args) => this.OnExit();
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
