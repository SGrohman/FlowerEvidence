using FlowerEvidence.Interfaces;
using FlowerEvidence.Managers;
using FlowerEvidence.Repositores;
using FlowerEvidence.Database;
using FlowerEvidence.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace FlowerEvidence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IFlowerManager Manager { get; set; }
        public MainWindow()
        {
            IFlowerRepository repository = new FlowerRepository(new FlowerContext());
            Manager = new FlowerManager(repository);
            InitializeComponent();

            LV.ItemsSource = new ObservableCollection<Flower>(Manager.GetAll());
        }
    }
}