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

namespace Homework_WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        private string wind;
        private int windSpeed;
        enum Precipitation
        {
            Sunny,
            Cloudy,
            Rain,
            Snow
        };
        Precipitation now;

        public string Wind
        {
            get => wind;
            set => wind = value;
        }
        public int WindSpeed
        {
            get => windSpeed;
            set => windSpeed = value;
        }
        public int Temp
        {
            get => (int) GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemp)));
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }

        public WeatherControl(int temp, string wind, int windSpeed)
        {
            this.Temp = temp;
            this.Wind = wind;
            this.WindSpeed = windSpeed;
            Precipitation now = Precipitation.Snow;
        }

        public string Print()
        {
            return $"{Temp} {Wind} {WindSpeed} {now}";
        }
    }
}
