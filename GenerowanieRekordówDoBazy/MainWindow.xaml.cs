using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GenerowanieRekordówDoBazy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        PreperAllListForRandomize Lists;
        TextBox[] TextBoxs;
        ProgressBar[] progressBars;
        ValidationValue validationValue;
        volatile PreperObjectsToInsert preperObjectsToInsert= new PreperObjectsToInsert();
        volatile bool[] clearDbIsFinish = new bool[1];

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
            if (e.Key == Key.Space)
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
            progressBars = new ProgressBar[15] { ProgresAdres, ProgresAkcesorie, ProgresFirma, ProgresGatunek, ProgresKlient, ProgresKraj, ProgresPodgatunek, ProgresPokarm, ProgresPokarmGatunek, ProgresProduktZamowienie, ProgresUzytkownikFirma, ProgresPracownik, ProgresUzytkownik, ProgresZamowienie, ProgresZwierze };
            for (int i = 0; i < TextBoxs.Length; i++)
            {
                TextBoxs[i].PreviewTextInput += new TextCompositionEventHandler(TextBoxPasting);
                TextBoxs[i].PreviewKeyDown += new KeyEventHandler(TextBox_KeyPress);
            }


            Calculate_Click(sender, e);
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
            uint temporary = 0;
            bool isNumber = true; ;
            foreach (var CurrentTextbox in TextBoxs)
            {
                if (CurrentTextbox.Text == "") CurrentTextbox.Text = "0";
            }
            Dictionary<string, uint> ValuesToInsert = new Dictionary<string, uint>();
            if (!UInt32.TryParse(TextBoxs[0].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Adres", temporary);
            if (!UInt32.TryParse(TextBoxs[1].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Akcesorie", temporary);
            if (!UInt32.TryParse(TextBoxs[2].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Firma", temporary);
            if (!UInt32.TryParse(TextBoxs[3].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Gatunek", temporary);
            if (!UInt32.TryParse(TextBoxs[4].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Klient", temporary);
            if (!UInt32.TryParse(TextBoxs[5].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Kraj", temporary);
            if (!UInt32.TryParse(TextBoxs[6].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Podgatunek", temporary);
            if (!UInt32.TryParse(TextBoxs[7].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Pokarm", temporary);
            if (!UInt32.TryParse(TextBoxs[8].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("PokarmGatunek", temporary);
            if (!UInt32.TryParse(TextBoxs[9].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("ProduktZamowienie", temporary);
            if (!UInt32.TryParse(TextBoxs[10].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("UzytkownikFirma", temporary);
            if (!UInt32.TryParse(TextBoxs[11].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Pracownik", temporary);
            if (!UInt32.TryParse(TextBoxs[12].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Uzytkownik", temporary);
            if (!UInt32.TryParse(TextBoxs[13].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Zamowienie", temporary);
            if (!UInt32.TryParse(TextBoxs[14].Text, out temporary)) isNumber = false;
            ValuesToInsert.Add("Zwierze", temporary);

            if (isNumber) CheckData(ValuesToInsert);
            else MessageBox.Show("Dopuszczelne są tylko dodatnie liczby", "Eroor");
            if (validationValue.Errors.Count == 0)
            {
                bool clear = ClearDb.IsChecked == true;
                Task.Run(() => InsertDb(ValuesToInsert, clear ,Lists));
                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += (sender, e) => dispatcherTimer_Tick(sender, e);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 20, 0);
                dispatcherTimer.Start();

            }
            else
            {
                string errors = "";
                foreach (string error in validationValue.Errors)
                {
                    errors += error + System.Environment.NewLine;
                }
                MessageBox.Show(errors, "Eroor");
            }
            
        }
        private void  InsertDb(Dictionary<string, uint> ValuesToInsert, bool clearDb, PreperAllListForRandomize Lists)
        {
           preperObjectsToInsert.StartInsert(Lists, clearDb, ValuesToInsert);
            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            if (preperObjectsToInsert.isFinish) MessageBox.Show("Dopuszczelne są tylko dodatnie liczby", "Eroor");
            
        }

        private void CheckData(Dictionary<string, uint> ValuesToInsert)
        {
            validationValue = new ValidationValue(ValuesToInsert, ClearDb.IsChecked == true, Lists);
        }
    }
}
