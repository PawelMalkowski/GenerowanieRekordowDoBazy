using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GenerowanieRekordówDoBazy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        volatile PreperAllListForRandomize Lists;
        TextBox[] TextBoxs;
        ProgressBar[] progressBars;
        ValidationValue validationValue;
        volatile uint[] values;
        volatile uint Sum;
        DateTime start;
        private readonly System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private readonly System.Windows.Threading.DispatcherTimer dispatcherTimerClock = new System.Windows.Threading.DispatcherTimer();

        readonly PreperObjectsToInsert preperObjectsToInsert= new PreperObjectsToInsert();

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
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(Fillbutton.IsEnabled==false) e.Cancel = true;

        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            TextBoxs = new TextBox[15] { Adres, Akcesorie, Firma, Gatunek, Klient, Kraj, Podgatunek, Pokarm, PokarmGatunek, ProduktZamowienie, UzytkownikFirma, Pracownik, Uzytkownik, Zamowienie, Zwierze };
            progressBars = new ProgressBar[15] { ProgresAdres, ProgresAkcesorie, ProgresFirma, ProgresGatunek, ProgresKlient, ProgresKraj, ProgresPodgatunek, ProgresPokarm, ProgresPokarmGatunek, ProgresProduktZamowienie, ProgresUzytkownikFirma, ProgresPracownik, ProgresUzytkownik, ProgresZamowienie, ProgresZwierze };
            foreach (var textbox in TextBoxs)
            {
                textbox.PreviewTextInput += new TextCompositionEventHandler(TextBoxPasting);
                textbox.PreviewKeyDown += new KeyEventHandler(TextBox_KeyPress);
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
            bool isNumber = true;
            Dictionary<string, uint> ValuesToInsert = new Dictionary<string, uint>();
            foreach (var CurrentTextbox in TextBoxs)
            {
                if (CurrentTextbox.Text == "") CurrentTextbox.Text = "0";
            }
            
            if (!UInt32.TryParse(TextBoxs[0].Text, out uint temporary)) isNumber = false;
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
                foreach (var textbox in TextBoxs)
                {
                    textbox.Visibility = Visibility.Hidden;
                }
                foreach (var progresbar in progressBars)
                {
                    progresbar.Visibility = Visibility.Visible;
                }
                Fillbutton.IsEnabled = false;
                ClearDb.IsEnabled = false;
                LabelStatus.Visibility = Visibility.Visible;
                values = ValuesToInsert.Values.ToArray();
                values[1] *= 2;
                values[7] *= 2;
                values[14] *= 2;
                GeneralProgress.Visibility = Visibility.Visible;
                foreach (uint value in values) Sum += value;
                for(int i=0; i< values.Length; ++i)
                {
                    if (values[i] == 0)
                    {
                        progressBars[i].IsEnabled = false;
                        progressBars[i].Value = 100;
                        progressBars[i].Foreground =Brushes.Gray;
                    }
                }
                Task.Run(() => InsertDb(ValuesToInsert, clear ,Lists));
                start = DateTime.Now;
                dispatcherTimer.Tick += (sender, e) => DispatcherTimer_Tick(sender, e);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                dispatcherTimer.Start();
                dispatcherTimerClock.Tick += (sender, e) => DispatcherTimer_TickClock(sender, e, start);
                dispatcherTimerClock.Interval = new TimeSpan(0, 0, 0, 0, 10);
                dispatcherTimerClock.Start();
            }
            else
            {
                string errors = "";
                foreach (string error in validationValue.Errors)
                {
                    errors += error + Environment.NewLine;
                }
                MessageBox.Show(errors, "Eroor");
            }
            
        }
        private void  InsertDb(Dictionary<string, uint> ValuesToInsert, bool clearDb, PreperAllListForRandomize Lists)
        {
           preperObjectsToInsert.StartInsert(Lists, clearDb, ValuesToInsert);
            
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {

            if (!preperObjectsToInsert.clearDbisFinish)
            {
                GeneralProgress.Value = (double)preperObjectsToInsert.cleanStatus / Lists.ScriptList.Count() * 100.0;
                
            }
            else
            {
                LabelStatus.Content = "Wypełnianie tabel";
                GeneralProgress.Value = (double)preperObjectsToInsert.insertObjectToDatabase.recordsIsdone / Sum * 100.0;
                for (int i = 0; i < progressBars.Length; ++i)
                {
                    if(progressBars[i].IsEnabled)
                    progressBars[i].Value = (double)preperObjectsToInsert.insertObjectToDatabase.progress[i] / values[i] * 100;
                }
            }

            
             ((MainWindow)Application.Current.MainWindow).UpdateLayout();
            if (preperObjectsToInsert.isFinish)
            {
                TimeSpan time = start - DateTime.Now;
                var endWindow = new OknoKońcowe(preperObjectsToInsert.insertObjectToDatabase.inserts, time);
                endWindow.Show();
                dispatcherTimer.Stop();
                dispatcherTimerClock.Stop();
                Fillbutton.IsEnabled = true;
                ((MainWindow)Application.Current.MainWindow).Close();
            }

               
        }
        private void DispatcherTimer_TickClock(object sender,EventArgs e,DateTime start)
        {
            var time = DateTime.Now - start;
            timeLabel.Content = time.Minutes + ":" + time.Seconds;
        }

        private void CheckData(Dictionary<string, uint> ValuesToInsert)
        {
            validationValue = new ValidationValue(ValuesToInsert, ClearDb.IsChecked == true, Lists);
        }
    }
}
