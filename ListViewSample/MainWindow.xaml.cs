using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListViewSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<MyItem> MyItemCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            // Initialize and populate YourCollection with MyItem instances
            MyItemCollection = new ObservableCollection<MyItem>
            {
                new MyItem { Name = "Item1" , Type = "A"  },
                new MyItem { Name = "Item2" , Type = "B" },
                new MyItem { Name = "Item3" , Type = "A" , IsVisible = false },
                new MyItem { Name = "Item4" , Type = "A" ,IsVisible = false },
                new MyItem { Name = "Item5" , Type = "A" },
                new MyItem { Name = "Item6" , Type = "A" },
                new MyItem { Name = "Item7" , Type = "A" },
                new MyItem { Name = "Item8" , Type = "A" ,IsVisible = false},

            };

            // Set the DataContext to enable data binding
            DataContext = this;
            
        }

        private void UpdatePositionInSet(object sender, RoutedEventArgs e)
        {
            int position = 1;
            int size = 0;
            foreach (var item in MyItemCollection)
            {
                if (item.IsVisible)
                {
                    var container = myListView.ItemContainerGenerator.ContainerFromItem(item);
                    AutomationProperties.SetPositionInSet(myListView.ItemContainerGenerator.ContainerFromItem(item) as UIElement, position++);
                    size++;
                }
            }
            foreach (var item in MyItemCollection)
            {
                AutomationProperties.SetSizeOfSet(myListView.ItemContainerGenerator.ContainerFromItem(item) as UIElement, size);
            }
                
        }



        
    }
    public class MyItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}