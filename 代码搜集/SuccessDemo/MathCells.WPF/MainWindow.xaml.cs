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
using System.Windows.Threading;

namespace MathCells.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static Cell[,] _cells;
        private static double _cellSize = 0;
        private static int _cellCount = 0;
        private int loopCount = 0;
        private DispatcherTimer timer;
        private void InitCells()
        {
            var x = _cells.GetLength(0);
            var y = _cells.GetLength(1);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (_cells[i, j] == null)
                    {
                        _cells[i, j] = new Cell();
                        _cells[i, j].Rectangle = new Rectangle()
                        {
                            Margin = new Thickness(i * _cellSize, j * _cellSize, 0, 0),
                            Width = _cellSize,
                            Height = _cellSize
                        };
                        this.canvas.Children.Add(_cells[i, j].Rectangle);
                    }
                    _cells[i, j].CurrLive = CellLive.Died;
                    _cells[i, j].NextLive = CellLive.Died;
                    _cells[i, j].Rectangle.Fill = Brushes.Gray;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void btnInit_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(this.cmpSize.SelectionBoxItem.ToString(), out _cellCount);
            if (_cellCount <= 0)
            {
                this.lblResult.Content = "初始化失败！";
                return;
            }
            _cellSize = this.canvas.ActualWidth / _cellCount;
            if (_cells == null || _cells.GetLength(0) != _cellCount)
            {
                _cells = new Cell[_cellCount, _cellCount];
            }
            loopCount = 0;
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Tick += Timer_Tick;
            }
            double interval;
            if (!double.TryParse(this.txtInter.Text, out interval)) {
                interval = 500;
            }
            timer.Interval = TimeSpan.FromMilliseconds(interval);

            InitCells();
            this.lblResult.Content = "初始化成功！";
            this.btnInit.IsEnabled = false;
            this.btnStart.IsEnabled = true;
            this.btnParse.IsEnabled = false;
            this.btnOver.IsEnabled = false;
            this.cmpSize.IsEnabled = false;
            this.txtInter.IsEnabled = false;

            this.canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
            this.canvas.MouseLeftButtonUp += Canvas_MouseLeftButtonUp;
            this.canvas.MouseLeave += Canvas_MouseLeave;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoopForever();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(this.canvas);
            var x = (int)(point.X / _cellSize);
            var y = (int)(point.Y / _cellSize);
            _cells[x, y].Rectangle.Fill = Brushes.White;
            _cells[x, y].CurrLive = CellLive.Live;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.canvas.MouseMove += Canvas_MouseMove;
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.canvas.MouseMove -= Canvas_MouseMove;
        }

        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            this.canvas.MouseMove -= Canvas_MouseMove;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            this.btnInit.IsEnabled = false;
            this.btnStart.IsEnabled = false;
            this.btnParse.IsEnabled = true;
            this.btnOver.IsEnabled = true;
            this.cmpSize.IsEnabled = false;
            this.txtInter.IsEnabled = false;
            this.canvas.MouseLeftButtonDown -= Canvas_MouseLeftButtonDown;
            this.canvas.PreviewMouseLeftButtonUp -= Canvas_MouseLeftButtonUp;
            this.canvas.MouseLeave -= Canvas_MouseLeave;

            this.timer.Start();
        }

        private void LoopForever()
        {
            this.timer.Stop();

            var x = _cells.GetLength(0);
            var y = _cells.GetLength(1);
            //第一步、判断生死
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (_cells[i, j] == null || _cells[i, j].Rectangle == null) continue;

                    CheckedCellLive(i, j, x, y);
                }
            }
            //第二步、渲染生死
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (_cells[i, j] == null || _cells[i, j].Rectangle == null) continue;
                    _cells[i, j].CurrLive = _cells[i, j].NextLive;

                    _cells[i, j].Rectangle.Fill = _cells[i, j].CurrLive == CellLive.Live ? Brushes.White : Brushes.Gray;
                }
            }


            loopCount++;
            this.lblResult.Content = $"迭代{loopCount}次";

            this.timer.Start();
        }
        private void CheckedCellLive(int x, int y, int xLength, int yLength)
        {
            var liveCount = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y) continue;
                    int currX = i; int currY = j;
                    if (currX < 0) currX = xLength - 1;
                    if (currY < 0) currY = yLength - 1;
                    if (currX >= xLength) currX = 0;
                    if (currY >= yLength) currY = 0;

                    if (_cells[currX, currY].CurrLive == CellLive.Live)
                        liveCount++;

                    if (liveCount > 3) break;
                }
                if (liveCount > 3) break;
            }
            if (liveCount == 2) _cells[x, y].NextLive = _cells[x, y].CurrLive;
            else if (liveCount == 3) _cells[x, y].NextLive = CellLive.Live;
            else _cells[x, y].NextLive = CellLive.Died;
        }

        private void btnParse_Click(object sender, RoutedEventArgs e)
        {
            this.btnInit.IsEnabled = false;
            this.btnStart.IsEnabled = true;
            this.btnParse.IsEnabled = false;
            this.btnOver.IsEnabled = true;
            this.cmpSize.IsEnabled = false;
            this.txtInter.IsEnabled = false;

            this.timer.Stop();
        }

        private void btnOver_Click(object sender, RoutedEventArgs e)
        {
            this.btnInit.IsEnabled = true;
            this.btnStart.IsEnabled = false;
            this.btnParse.IsEnabled = false;
            this.btnOver.IsEnabled = false;
            this.cmpSize.IsEnabled = true;
            this.txtInter.IsEnabled = true;

            this.timer.Stop();
            _cellCount = 0;
            _cellSize = 0;
            loopCount = 0;
        }
    }

    class Cell
    {
        public CellLive CurrLive { get; set; }
        public CellLive NextLive { get; set; }
        public Rectangle Rectangle { get; set; }
    }
    enum CellLive
    {
        Died,
        Live
    }
}
