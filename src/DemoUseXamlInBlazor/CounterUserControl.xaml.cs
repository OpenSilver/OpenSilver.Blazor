using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoUseXamlInBlazor
{
    public partial class CounterUserControl : UserControl, INotifyPropertyChanged
    {
        public CounterUserControl()
        {
            this.InitializeComponent();

            this.DataContext = this; // Learn more about how XAML binding works at: https://odetocode.com/articles/740.aspx
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        private int currentCount;
        public int CurrentCount
        {
            get => currentCount;
            set { currentCount = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentCount")); }
        }

        private void ButtonIncrementCount_Click(object sender, RoutedEventArgs e)
        {
            //ListBox1.ItemsSource = new HashSet<string>( new[] { "one", "two", "three"});
            CurrentCount++;
        }
    }
}
