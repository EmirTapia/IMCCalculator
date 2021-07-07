using System;
using Xamarin.Forms;

namespace CalculadoraIMC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Altura.Text) && !string.IsNullOrEmpty(Peso.Text))
            {
                double altura = double.Parse(Altura.Text);
                double peso = double.Parse(Peso.Text);
                if (EsAlturaCorrecta(altura) && EsPesoCorreco(peso))
                {
                    string resultado = CalcularIMC(altura, peso);
                    DisplayAlert("Resultado", resultado, "Ok");
                }
                else
                {
                    DisplayAlert("Datos erróneos", "Favor de ingresar valores reales de altura y peso.", "Ok");
                }
            }
            else
            {
                DisplayAlert("Datos erróneos", "Favor de ingresar los valores solicitados.", "Ok");
            }
        }
        private string CalcularIMC(double altura, double peso)
        {
            double imc = peso / (altura * altura);
            IMC.Text = Math.Round(imc, 2).ToString();
            if (imc < 18.5) { return "Tienes bajo peso."; }
            if (imc >= 18.5 && imc <= 24.9) { return "Tienes un peso normal."; }
            if (imc >= 25 && imc <= 29.9) { return "Tienes sobrepeso."; }
            else { return "Tiene obesidad"; }
        }

        private bool EsAlturaCorrecta(double altura)
        {
            if (altura < 1.40 || altura >= 2.30)
            {
                return false;
            }
            return true;
        }

        private bool EsPesoCorreco(double peso)
        {
            if (peso < 20 || peso >= 150)
            {
                return false;
            }
            return true;
        }
    }
}
