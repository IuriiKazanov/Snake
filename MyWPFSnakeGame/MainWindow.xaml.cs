using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using SnakeClassLibrary;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using Panel = System.Windows.Controls.Panel;
using System.Configuration;

namespace MyWPFSnakeGame
{
    public partial class MainWindow : Window
    {
        private bool timerFlag = false;
        private SnakeGame game;
        private Timer stepTimer;
        private int Score;
        private UIElementCollection cells;

        private static string fileName = ConfigurationSettings.AppSettings.AllKeys[0];

        private Stream f;
        
        private Records myRecords = new Records();
        static XmlSerializer xmlFmt = new XmlSerializer(typeof(Records));
        
        
        public MainWindow()
        {
            
            InitializeComponent();
            cells = AreaGrid.Children;
            TextScore.Text = Score.ToString();

            int rows = 23;
            int columns = 51;

            AreaGrid.Rows = rows;
            AreaGrid.Columns = columns;
            SetBackground(AreaGrid, "LightGray");

            DrawRegion(rows, columns);

            game = new SnakeGame();
            
            game.Draw += this.Draw;

            
            stepTimer = new System.Windows.Forms.Timer();
            stepTimer.Interval = 100;
            stepTimer.Enabled = false;
            stepTimer.Tick += OnStepTimer;
        }

        private void DrawRegion(int rows, int columns)
        {
            for (int y = 0; y < rows; y++)
            for (int x = 0; x < columns; x++)
                AreaGrid.Children.Add(CreateSectionCanvas(y, x));
        }

        private Canvas CreateSectionCanvas(int y, int x)
        {

            Canvas section = new Canvas();
            section.Name = "Section_" + y.ToString() + "_" + x.ToString();
            section.Margin = new Thickness(1);
            SetBackground(section, "White");
            return section;
        }

        private void SetBackground(Panel control, string color)
        {
            control.Background = (SolidColorBrush) new BrushConverter().ConvertFromString(color);
        }

        private void OnStepTimer(object sender, EventArgs e)
        {
            game.Step();
            if (game.State == GameState.End)
            {
                stepTimer.Stop();
                SaveScoreWindow itemWindow = new SaveScoreWindow();
                itemWindow.TextBlockScore.Text = (Score - 1).ToString();
                itemWindow.ShowDialog();
                if (itemWindow.TextBoxName.Text == "")
                    itemWindow.TextBoxName.Text = "Player";
                Record itemRecord = new Record(itemWindow.TextBoxName.Text, Score - 1);
                myRecords.AddToRecords(itemRecord);

                if (DialogResult == true)
                    itemWindow.Close();
                if (itemWindow.flagSave)
                {
                    f = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    SaveAsXML(myRecords, fileName, f);
                }
            }
        }

        private void Draw(SnakeClassLibrary.Point point, Item item)
        {
            string color;
            switch (item)
            {
                case Item.Prize:
                    color = "blue";
                    TextScore.Text = Score.ToString();
                    Score++;
                    break;
                case Item.SnakeSegment:
                    color = "green";
                    break;
                case Item.Zero:
                    color = "white";
                    break;
                default:
                    color = "white";
                    break;
            }
            
            foreach (Canvas c in cells)
            {
                if (c.Name == ("Section_" + point.Y + "_" + point.X))
                {
                    SetBackground(c, color);
                }
            }
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    game.Instruction(Direction.Up);                    
                    break;
                case Key.Down:
                    game.Instruction(Direction.Down);
                    break;
                case Key.Left:
                    game.Instruction(Direction.Left);
                    break;
                case Key.Right:
                    game.Instruction(Direction.Right);
                    break;
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Score = 0;
            foreach (Canvas i in cells)
                SetBackground(i, "white");
            game.Initialization();
            game.Start();
            stepTimer.Start();
        }


        private void ButtonPausePlay_Click(object sender, RoutedEventArgs e)
        {
            if (timerFlag)
                stepTimer.Start();
            else
                stepTimer.Stop();

            timerFlag = !timerFlag;
        }

        private void ButtonRecords_Click(object sender, RoutedEventArgs e)
        {

            ReadFromXML(ref myRecords, fileName, f);
            string answer = myRecords.RecordsToString();

            MessageBox.Show(answer);
            
        }

        private static void SaveAsXML(object obj, string filename, Stream f)
        {
            xmlFmt.Serialize(f, obj);
            f.Close();
        }

        private static void ReadFromXML(ref Records pRead, string filename, Stream f)
        {
            f = File.OpenRead(filename);
            pRead = (Records) xmlFmt.Deserialize(f);
            f.Close();
        }

    }
}

