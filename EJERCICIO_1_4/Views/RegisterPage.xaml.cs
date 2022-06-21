using EJERCICIO_1_4.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO_1_4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        MediaFile FileFoto = null;

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void btnTakePhoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                FileFoto = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "MisFotos",
                    Name = "foto.jpg",
                    SaveToAlbum = true,
                });

                if (FileFoto != null)
                {
                    photoImage.Source = ImageSource.FromStream(() => {
                        return FileFoto.GetStream();
                    });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error: ", ex.Message, "Ok");
            }              
            
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (FileFoto == null)
            {
                await DisplayAlert("Advertencia", "No ha tomado una fotografia", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                await DisplayAlert("Advertencia", "Debes ingresar tu nombre completo", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                await DisplayAlert("Advertencia", "Debes ingresar tu descripcion", "Ok");
                return;
            }

            
            try
            {
                var employee = new Employee
                {
                    id = 0,
                    name = txtName.Text,
                    description = txtDescription.Text,
                    photo = ConvertImageToByteArray(),
                };
                var result = await App.DBase.CreateOrUpdateEmployee(employee);

                if (result > 0)
                {
                    await DisplayAlert("Aviso", "Empleado Guardado Correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Aviso", "Se produjo un error al guardar el empleado", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Aviso", "ERROR_SAVE_EMPLOYEE: "+ex.Message, "OK");
            }

            
        }

        private Byte[] ConvertImageToByteArray()
        {

            if (FileFoto != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = FileFoto.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }

            return null;
        }
    }
}