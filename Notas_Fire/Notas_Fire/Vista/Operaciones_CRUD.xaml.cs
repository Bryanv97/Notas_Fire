using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notas_Fire.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notas_Fire.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Operaciones_CRUD : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public Operaciones_CRUD()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToInt32(txtID.Text), txttitle.Text,txtcontend.Text);
            txtID.Text = string.Empty;
            txttitle.Text = string.Empty;
            txtcontend.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            await Navigation.PopAsync();
        }

        private void ButtonEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private void ButtonActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private  void ButtonCancelar_Clicked(object sender, EventArgs e)
        {

        }

        private void Slider_DragCompleted(object sender, EventArgs e)
        {
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double sli = slider.Value;
            int valor = Convert.ToInt32(sli);
            lblvalue.Text = valor.ToString();

        }
    }
}