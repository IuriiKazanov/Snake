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
using System.Windows.Shapes;
using SnakeClassLibrary;

namespace MyWPFSnakeGame
{
    /// <summary>
    /// Логика взаимодействия для SaveScoreWindow.xaml
    /// </summary>
    public partial class SaveScoreWindow : Window
    {
        public SaveScoreWindow()
        {
            InitializeComponent();
        }

        public bool flagSave = false; 
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            flagSave = true;
            DialogResult = true;
        }

    }
}
