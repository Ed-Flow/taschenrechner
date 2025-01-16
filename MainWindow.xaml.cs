using System;
using System.Data; // Für die Berechnung der Zeichenkette
using System.Windows;
using System.Windows.Controls;

namespace Taschenrechner
{
    public partial class MainWindow : Window
    {
        private string input = ""; // Globale Variable für die Eingaben

        public MainWindow()
        {
            InitializeComponent();
        }

        // Button für Zahlen und Operatoren
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string value = button.Content.ToString();

            // Füge die Eingabe zur globalen Zeichenkette hinzu
            input += value;

            // Aktualisiere das Display
            Display.Text = input;
        }

        // Berechnung durchführen
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Verwende DataTable, um den Ausdruck zu berechnen
                DataTable dt = new DataTable();
                var result = dt.Compute(input, ""); // Berechnung der Zeichenkette

                // Zeige das Ergebnis im Display
                Display.Text = $"{input} = {result}"; // das $ ist String-Interpolation

                // Nach der Berechnung die Eingabe zurücksetzen
                input = "";
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung bei ungültigen Eingaben
                Display.Text = "Fehler!";
                input = "";
            }
        }

        // Clear-Button
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Eingaben zurücksetzen
            input = "";
            Display.Text = "0";
        }
    }
}
