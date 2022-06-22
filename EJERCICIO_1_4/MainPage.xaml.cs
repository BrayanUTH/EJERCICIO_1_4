using EJERCICIO_1_4.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EJERCICIO_1_4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.DBase == null)
            {

            }
        }

        private void btnViewList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListPage());
        }

        private void btnViewRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
