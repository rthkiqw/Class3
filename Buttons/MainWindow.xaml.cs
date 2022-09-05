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

namespace Buttons
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button button = new Button();
            button.Background = Brushes.GhostWhite;
            button.HorizontalContentAlignment = HorizontalAlignment.Center;
            button.Content = "Play";
            button.Width = 200;
            button.Height = 150;

            MainGrid.Children.Add(button);
            Grid.SetColumn(button, 1);

            button.Click += ButtonClick;
        }

        int x = 0;
        int y = 0;
        int counter = 1;

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = new Button();
            button.Width = 100;
            button.Height = 100;
            button.Content = counter;
            button.Click += ButtonRemove;

            if (IsEmpty(x, y) == true)
            {
                JunGrid.Children.Add(button);
                Grid.SetColumn(button, y);
                Grid.SetRow(button, x);
                counter++;
            }
            y++;
            if (y == 3)
            {
                x += 1;
                y = 0;
            }
            if (y == 3 || x == 3)
            {
                x = 0;
                y = 0;
            }
        }
        public void ButtonRemove(object sender, RoutedEventArgs e)
        {
            UIElement Click = (UIElement)sender;
            JunGrid.Children.Remove(Click);
        }
        public bool IsEmpty(int row, int column)
        {
            foreach (UIElement element in JunGrid.Children)
            {
                var elementRow = (int)element.GetValue(Grid.RowProperty);
                var elementColumn = (int)element.GetValue(Grid.ColumnProperty);

                if (row == elementRow && column == elementColumn)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
