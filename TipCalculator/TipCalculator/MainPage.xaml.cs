using System.Runtime.Intrinsics.Arm;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void SliderTipPercent_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            LabelPercentageValue.Text = $"{Math.Round(SliderTipPercent.Value).ToString()}%";
        }

        private void OnButton15PercentClicked(object sender, EventArgs e)
        {
            SliderTipPercent.Value = 15;
        }

        private void OnButton20PercentClicked(object sender, EventArgs e)
        {
            SliderTipPercent.Value = 20;
        }

        private void OnButtonRoundDownClicked(object sender, EventArgs e)
        {
            // calcular a gorjeta, arredondando para baixo
            double result = CalculateTip();
            double roundedResult = Math.Floor(result);
            double amount = Convert.ToDouble(ValueEntry.Text.ToString());
            double totalValue = roundedResult + amount;
            // exibir a gorjeta
            LabelTipValue.Text = roundedResult.ToString("C2");
            LabelTotalValue.Text = totalValue.ToString("C2");
            
        }

        private void OnButtonRoundUpClicked(object sender, EventArgs e)
        {
            // calcular a gorjeta, arredondando para cima
            double result = CalculateTip();
            double roundedResult = Math.Ceiling(result);
            double amount = Convert.ToDouble(ValueEntry.Text.ToString());
            double totalValue = roundedResult + amount;
            // exibir a gorjeta
            LabelTipValue.Text = roundedResult.ToString("C2");
            LabelTotalValue.Text = totalValue.ToString("C2");
        }

        private double CalculateTip()
        {
            
            double amount = Convert.ToDouble(ValueEntry.Text.ToString());
            double percent = SliderTipPercent.Value;

            // calculo da gorjeta
            double result = amount * (percent / 100);
            return result;
        }

    }


}
