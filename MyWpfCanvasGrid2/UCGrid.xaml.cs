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

namespace MyWpfCanvasGrid2
{
    /// <summary>
    /// Interaction logic for UCGrid.xaml
    /// </summary>
    public partial class UCGrid : UserControl
    {

        #region DependencyProperty
        public double ColumnWidth
        {
            get { return (double)GetValue(DPColumnWidth); }
            set { SetValue(DPColumnWidth, value); }
        }
        public static readonly DependencyProperty DPColumnWidth = DependencyProperty.Register("ColumnWidth", typeof(double), typeof(UCGrid));
        public double RowHeight
        {
            get { return (double)GetValue(DPRowHeight); }
            set { SetValue(DPRowHeight, value); }
        }
        public static readonly DependencyProperty DPRowHeight = DependencyProperty.Register("RowHeight", typeof(double), typeof(UCGrid));
        public double UCGridWidth
        {
            get { return (double)GetValue(DPUCGridWidth); }
            set { SetValue(DPUCGridWidth, value); }
        }
        public static readonly DependencyProperty DPUCGridWidth = DependencyProperty.Register("UCGridWidth", typeof(double), typeof(UCGrid));
        public double UCGridHeight
        {
            get { return (double)GetValue(DPUCGridHeight); }
            set { SetValue(DPUCGridHeight, value); }
        }
        public static readonly DependencyProperty DPUCGridHeight = DependencyProperty.Register("UCGridHeight", typeof(double), typeof(UCGrid));
        public int UCGridColumnCount
        {
            get { return (int)GetValue(DPUCGridColumnCount); }
            set { SetValue(DPUCGridColumnCount, value); }
        }
        public static readonly DependencyProperty DPUCGridColumnCount = DependencyProperty.Register("UCGridColumnCount", typeof(int), typeof(UCGrid));
        public int UCGridRowCount
        {
            get { return (int)GetValue(DPUCGridRowCount); }
            set { SetValue(DPUCGridRowCount, value); }
        }
        public static readonly DependencyProperty DPUCGridRowCount = DependencyProperty.Register("UCGridRowCount", typeof(int), typeof(UCGrid));
        public double LineThickness
        {
            get { return (double)GetValue(DPLineThickness); }
            set { SetValue(DPLineThickness, value); }
        }
        public static readonly DependencyProperty DPLineThickness = DependencyProperty.Register("LineThickness", typeof(double), typeof(UCGrid));
        public Brush LineBrush
        {
            get { return (Brush)GetValue(DPLineBrush); }
            set { SetValue(DPLineBrush, value); }
        }
        public static readonly DependencyProperty DPLineBrush = DependencyProperty.Register("LineBrush", typeof(Brush), typeof(UCGrid));
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public UCGrid()
        {
            InitializeComponent();
            ColumnWidth = 30.0;
            RowHeight = 30.0;
            LineThickness = 1.0;
            LineBrush = Brushes.Black;
        }

        /// <summary>
        /// UCCanvas_SizeChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UCCanvasRedraw();
        }

        /// <summary>
        /// UCCanvasRedraw
        /// draw/redraw the grid 
        /// in to the Canvas
        /// </summary>
        public void UCCanvasRedraw()
        {
            UCGridWidth = UCCanvas.ActualWidth;
            UCGridHeight = UCCanvas.ActualHeight;
            UCGridColumnCount = (int)(UCGridWidth / ColumnWidth);
            UCGridRowCount = (int)(UCGridHeight / RowHeight);

            UCCanvas.Children.Clear();

            for (int j = 0; j <= UCGridRowCount; j++)
            {
                Line myLine = new Line();
                myLine.Stroke = LineBrush;
                myLine.StrokeThickness = LineThickness;
                myLine.SnapsToDevicePixels = true;
                myLine.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                myLine.X1 = 0;
                myLine.X2 = UCGridColumnCount * ColumnWidth;
                myLine.Y1 = j * RowHeight;
                myLine.Y2 = j * RowHeight;
                UCCanvas.Children.Add(myLine);
            }

            for (int i = 0; i <= UCGridColumnCount; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = LineBrush;
                myLine.StrokeThickness = LineThickness;
                myLine.SnapsToDevicePixels = true;
                myLine.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
                myLine.X1 = i * ColumnWidth;
                myLine.X2 = i * ColumnWidth;
                myLine.Y1 = 0;
                myLine.Y2 = UCGridRowCount * RowHeight;
                UCCanvas.Children.Add(myLine);
            }
        }
    }
}
