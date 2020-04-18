using System.Windows;

namespace LearningDataStorage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var startup = new Startup();
            startup.Start();
        }
    }
}
