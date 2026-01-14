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
using FlowerEvidence.Windows;


namespace FlowerEvidence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Flower> Data { get; set; }
        public IFlowerManager Manager { get; set; }
        public MainWindow()
        {
            IFlowerRepository repository = new FlowerRepository(new FlowerContext());
            Manager = new FlowerManager(repository);
            Data = new ObservableCollection<Flower>(Manager.GetAll());
            InitializeComponent();
            LV.ItemsSource = Data;
        }
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddNewFlowerWindow AddWindow = new(Manager);
            AddWindow.Closed += (s, e) => { Data.Add(AddWindow.NewFlower); };
            AddWindow.ShowDialog();
            
        }

        private void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            Flower toRemove = LV.SelectedItem as Flower;
            if (toRemove != null)
            {
                Manager.Remove(toRemove);
                Data.Remove(toRemove);
            }
            
        }

        
    }
}