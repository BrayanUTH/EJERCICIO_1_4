using EJERCICIO_1_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO_1_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        Employee selectedEmployee;
        public ListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (await App.DBase.GetAllEmployee() != null)
            {
                listEmple.ItemsSource = await App.DBase.GetAllEmployee();
            }
            else
            {
                await DisplayAlert("Advertencia", "No hay empleados agregados", "Ok");
            }
        }

        private async void listEmple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                selectedEmployee = (e.CurrentSelection.FirstOrDefault() as Employee);
                
        }

        private async void BtnViewEmployees_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Confirmacion", "¿Esta seguro de visualiar el empleado?", "Si", "No");
            if (result)
            {
                ViewPhotoPage photoPage = new ViewPhotoPage();
                photoPage.BindingContext = selectedEmployee;
                await Navigation.PushAsync(photoPage);
            }
        }
    }
}