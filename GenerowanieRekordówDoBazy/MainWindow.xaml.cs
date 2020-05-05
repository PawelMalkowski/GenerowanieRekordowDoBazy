using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace GenerowanieRekordówDoBazy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
  
    public partial class MainWindow : Window
    {
        PreperAllListForRandomize Lists;
        Button button;
        TextBox[] TextBoxs;
        private static readonly Regex _regex = new Regex("[^0-9]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void TextBoxPasting(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextAllowed(e.Text))
                e.Handled = true;
        }
        private void TextBox_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Space)
            {
                e.Handled = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
       
  
        private void Window_Initialized(object sender, EventArgs e)
        {
            TextBoxs = new TextBox[15] { Adres, Akcesorie, Firma, Gatunek, Klient, Kraj, Podgatunek, Pokarm, PokarmGatunek, ProduktZamowienie, UzytkownikFirma, Pracownik, Uzytkownik, Zamowienie, Zwierze };
            for (int i = 0; i < TextBoxs.Length; i++)
            {
                TextBoxs[i].PreviewTextInput += new TextCompositionEventHandler(TextBoxPasting);
                TextBoxs[i].PreviewKeyDown += new KeyEventHandler(TextBox_KeyPress);
            }

            
            Calculate_Click(sender,e);
        }
        private async void Calculate_Click(object sender, EventArgs e)
        {

            Fillbutton.IsEnabled = false;
            await Task.Run(() => Startconnecting());
            Fillbutton.Content = "Wypelnij";
            Fillbutton.IsEnabled = true;
        }

        public void Startconnecting()
        {
            Lists = new PreperAllListForRandomize();
        }

        private void Fillbutton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var CurrentTextbox in TextBoxs)
            {
                if (CurrentTextbox.Text == "") CurrentTextbox.Text = "0";
            }
            Dictionary<string, int> ValuesToInsert = new Dictionary<string, int>();
            ValuesToInsert.Add("Adres", Int32.Parse(TextBoxs[0].Text));
            ValuesToInsert.Add("Akcesorie", Int32.Parse(TextBoxs[1].Text));
            ValuesToInsert.Add("Firma", Int32.Parse(TextBoxs[2].Text));
            ValuesToInsert.Add("Gatunek", Int32.Parse(TextBoxs[3].Text));
            ValuesToInsert.Add("Klient", Int32.Parse(TextBoxs[4].Text));
            ValuesToInsert.Add("Kraj", Int32.Parse(TextBoxs[5].Text));
            ValuesToInsert.Add("Podgatunek", Int32.Parse(TextBoxs[6].Text));
            ValuesToInsert.Add("Pokarm", Int32.Parse(TextBoxs[7].Text));
            ValuesToInsert.Add("PokarmGatunek", Int32.Parse(TextBoxs[8].Text));
            ValuesToInsert.Add("ProduktZamowienie", Int32.Parse(TextBoxs[9].Text));
            ValuesToInsert.Add("UzytkownikFirma", Int32.Parse(TextBoxs[10].Text));
            ValuesToInsert.Add("Pracownik", Int32.Parse(TextBoxs[11].Text));
            ValuesToInsert.Add("Uzytkownik", Int32.Parse(TextBoxs[12].Text));
            ValuesToInsert.Add("Zamowienie", Int32.Parse(TextBoxs[13].Text));
            ValuesToInsert.Add("Zwierze", Int32.Parse(TextBoxs[14].Text));
            ValidationValue validation = new ValidationValue(ValuesToInsert, ClearDb.IsChecked == true, Lists);
        }
    }
}
