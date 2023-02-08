using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoUseBlazorInOpenSilver
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            QuickGridDemo1.ComponentType = typeof(QuickGridDemo);
            Counter1.ComponentType = typeof(Counter);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((QuickGridDemo)QuickGridDemo1.Instance).People = new[]
            {
                new QuickGridDemo.Person(10895, "TEST", new DateOnly(1985, 3, 16)),
                new QuickGridDemo.Person(10944, "António Langa", new DateOnly(1991, 12, 1)),
                new QuickGridDemo.Person(11203, "Julie Smith", new DateOnly(1958, 10, 10)),
                new QuickGridDemo.Person(11205, "Nur Sari", new DateOnly(1922, 4, 27)),
                new QuickGridDemo.Person(11898, "Jose Hernandez", new DateOnly(2011, 5, 3)),
                new QuickGridDemo.Person(12130, "Kenji Sato", new DateOnly(2004, 1, 9)),
            }.AsQueryable();

            ((QuickGridDemo)QuickGridDemo1.Instance).Refresh();
        }
    }
}
