using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private double currentValue = 0;
        private string operation = string.Empty;
        private double previousValue = 0;
        private bool isNewEntry = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string value = button.Content.ToString(); // Der Wert des gedrückten Buttons (z. B. "7", "8")

            // Wenn das Display "0" enthält, überschreibe es mit der neuen Zahl
            if (Display.Text == "0" || (isNewEntry && string.IsNullOrEmpty(operation)))
            {
                Display.Text = value; // Setze die neue Zahl
                isNewEntry = false;   // Beende den Eingabemodus
            }
            else
            {
                // Hänge die Zahl an die bestehende Eingabe an
                Display.Text += value;
            }

            // Aktualisiere den aktuellen Wert basierend auf der letzten Zahl im Display
            if (double.TryParse(Display.Text.Split(' ')[^1], out double parsedValue))
            {
                currentValue = parsedValue; // Speichere den aktuellen Wert
            }
        }



        private void Info_Click(object sender, RoutedEventArgs e)
{
    MessageBox.Show("Diese App wurde von Edgar Loraj entwickelt.\n© 2025 Edgar Loraj", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
}






        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string operatorValue = button.Content.ToString();

            if (!string.IsNullOrEmpty(operation) && !isNewEntry)
            {
                // Berechne das Zwischenergebnis
                Equals_Click(sender, e);
            }

            // Speichere den aktuellen Wert als vorherigen Wert
            previousValue = currentValue;
            operation = operatorValue; // Speichere den Operator
            Display.Text += $" {operatorValue} "; // Zeige den Operator im Display
            isNewEntry = true; // Setze neuen Eingabemodus
        }





        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(operation)) return;

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = previousValue + currentValue;
                    break;
                case "-":
                    result = previousValue - currentValue;
                    break;
                case "*":
                    result = previousValue * currentValue;
                    break;
                case "/":
                    if (currentValue != 0)
                        result = previousValue / currentValue;
                    else
                    {
                        Display.Text = "Fehler: Division durch 0";
                        return;
                    }
                    break;
            }

            Display.Text = $"{previousValue} {operation} {currentValue} = {result}";
            currentValue = result; // Speichere das Ergebnis
            previousValue = 0;     // Setze den vorherigen Wert zurück
            operation = string.Empty; // Lösche den Operator
            isNewEntry = true;     // Vorbereitung für die nächste Eingabe
        }






        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0"; // Setze das Display auf 0
            currentValue = 0;   // Setze den aktuellen Wert zurück
            previousValue = 0;  // Setze den vorherigen Wert zurück
            operation = string.Empty; // Lösche den Operator
            isNewEntry = true;  // Bereite die nächste Eingabe vor
        }

    }
}
