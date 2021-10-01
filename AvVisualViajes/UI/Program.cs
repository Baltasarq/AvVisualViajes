// AvVisualViajes (c) 2021 Baltasar MIT License <jbgarcia@uvigo.es>


namespace AvVisualViajes.UI {
    using Avalonia;
    
    class Program {
        public static void Main(string[] args)
        {
            if ( args.Length > 0
                 && args[ 0 ] == "--gui" )
            {
                BuildAvaloniaApp()
                    .StartWithClassicDesktopLifetime( args );
            } else {
                ConsoleUI.MainLoop( args );
            }

            return;
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}
