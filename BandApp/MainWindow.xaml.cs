using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BandApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //Link To GitHub Repo
    //https://github.com/S00197638/OODWeek7Labsheet5

    public partial class MainWindow : Window
    {
        Model1Container db;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Model1Container();

            var query = db.Bands
                .Select(b => b);

            lbxBands.ItemsSource = query.ToList();
        }

        private void lbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selectedBand = lbxBands.SelectedItem as Band;

            if(selectedBand != null)
            {
                var query = db.Albums
                    .Where(a => a.BandId == selectedBand.Id)
                    .Select(a => a);

                lbxAlbums.ItemsSource = query.ToList();
            }
        }
    }
}
