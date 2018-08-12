using SortedWord;
using System.Windows;
using Unity;

namespace SortWord.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUnityContainer _container;
        public MainWindow()
        {
            InitializeComponent();
            UnityRegister();
        }

        void UnityRegister()
        {
            _container = new UnityContainer();
            _container.RegisterType<ISortedFour<string>, SortedFour<string>>();

            this.DataContext = _container.Resolve<MainWindowViewModel>();
        }

        private void inputTxt_TextChanged(object sender,
            System.Windows.Controls.TextChangedEventArgs e)
        {
            inputTxt.Focus();
        }
    }
}
