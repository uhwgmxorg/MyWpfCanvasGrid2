using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace MyWpfCanvasGrid2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region OnPropertyChanged Properties
        private double columnWidth;
        public double ColumnWidth
        {
            get { return columnWidth; }
            set
            {
                SetField(ref columnWidth, value, nameof(ColumnWidth));
                UCGrid.UCCanvasRedraw();
                GetUserContolValues();
            }
        }
        private double rowHeight;
        public double RowHeight
        {
            get { return rowHeight; }
            set
            {
                SetField(ref rowHeight, value, nameof(RowHeight));
                UCGrid.UCCanvasRedraw();
                GetUserContolValues();
            }
        }
        private string uCGridWidth;
        public string UCGridWidth
        {
            get { return uCGridWidth; }
            set { SetField(ref uCGridWidth, value, nameof(UCGridWidth)); }
        }
        private string uCGridHeight;
        public string UCGridHeight
        {
            get { return uCGridHeight; }
            set { SetField(ref uCGridHeight, value, nameof(UCGridHeight)); }
        }
        private string uCGridColumnCount;
        public string UCGridColumnCount
        {
            get { return uCGridColumnCount; }
            set { SetField(ref uCGridColumnCount, value, nameof(UCGridColumnCount)); }
        }
        private string uCGridRowCount;
        public string UCGridRowCount
        {
            get { return uCGridRowCount; }
            set { SetField(ref uCGridRowCount, value, nameof(UCGridRowCount)); }
        }

        // Template for a new INotify Changed Property
        // for using CTRL-R-R
        private string xxx;
        public string Xxx
        {
            get { return xxx; }
            set { SetField(ref xxx, value, nameof(Xxx)); }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// Button_Click_Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        /// <summary>
        /// Window_Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ColumnWidth = 20;
            RowHeight = 20;
        }

        /// <summary>
        /// Grid_SizeChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GetUserContolValues();
        }

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// GetUserContolValues
        /// </summary>
        private void GetUserContolValues()
        {
            UCGridWidth = UCGrid.UCGridWidth.ToString();
            UCGridHeight = UCGrid.UCGridHeight.ToString();
            UCGridColumnCount = UCGrid.UCGridColumnCount.ToString();
            UCGridRowCount = UCGrid.UCGridRowCount.ToString();
        }

        /// <summary>
        /// SetField
        /// for INotify Changed Properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        #endregion
    }
}
