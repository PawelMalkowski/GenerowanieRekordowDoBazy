using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GenerowanieRekordówDoBazy
{
    /// <summary>
    /// Logika interakcji dla klasy OknoKońcowe.xaml
    /// </summary>
    public partial class OknoKońcowe 
    {
        public OknoKońcowe(string insertsString)
        {
            InitializeComponent();
            inserts.Text = insertsString;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, inserts.Text);
            }
        }
    }
}
