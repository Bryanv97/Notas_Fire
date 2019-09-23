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
    public partial class Lista_Contenido : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public Lista_Contenido()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            ListViewItems.ItemsSource = allPersons;
        }

        private async void ListViewItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var TodoItem = e.SelectedItem as Notas;
            if (TodoItem != null)
            {
                await Navigation.PushAsync(new Operaciones_CRUD { BindingContext = TodoItem });
            }
        }

        private async void Onitemadded_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Operaciones_CRUD
            { BindingContext = new Model.Notas() });
        }
    }
}