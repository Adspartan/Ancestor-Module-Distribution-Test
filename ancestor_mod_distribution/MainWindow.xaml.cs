using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ancestor_mod_distribution
{
  public struct module_data
  {
    public string descendant { get; private set; }
    public int count { get; private set; }

    public module_data(string descendant, int count)
    {
      this.descendant = descendant;
      this.count = count;
    }
  }

  public partial class MainWindow : Window
  {
    public static List<string> descendants = new List<string>()
    {
      "Ajax",
      "Blair",
      "Bunny",
      "Enzo",
      "Esiemo",
      "Freyna",
      "Gley",
      "Hailey",
      "Harris",
      "Ines",
      "Jayber",
      "Keelan",
      "Kyle",
      "Lepic",
      "Luna",
      "Nell",
      "Serena",
      "Sharen",
      "Valby",
      "Viessa",
      "Yujin"
    };

    ObservableCollection<module_data> _modules = new ObservableCollection<module_data>();

    public MainWindow()
    {
      InitializeComponent();
    }

    private void module_count_tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      Regex filter = new Regex("[^0-9]+");

      // discard anything that isn't a digit
      e.Handled = filter.IsMatch(e.Text);
    }

    private void run_btn_Click(object sender, RoutedEventArgs e)
    {
      Dictionary<string, int> module_count_per_descendant = new Dictionary<string, int>();
      int module_count = int.Parse(module_count_tb.Text);

      foreach (string descendant in descendants)
      {
        module_count_per_descendant[descendant] = 0;
      }

      for(int i=0; i<module_count; ++i)
      {
        int index = Random.Shared.Next(0, descendants.Count);
        string descendant = descendants[index];

        module_count_per_descendant[descendant]++;
      }

      ObservableCollection<module_data> oc = new ObservableCollection<module_data>();

      foreach(var it in module_count_per_descendant)
      {
        oc.Add(new module_data(it.Key, it.Value));
      }

      result_datagrid.ItemsSource = oc;
    }
  }
}
