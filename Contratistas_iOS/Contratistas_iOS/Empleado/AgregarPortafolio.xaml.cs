﻿using Contratistas_iOS.Datos;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratistas_iOS.Empleado
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgregarPortafolio : ContentPage
	{
        private MediaFile _mediaFile;
        private string ruta;
        private MediaFile _mediaFile2;
        private string ruta2;
        private MediaFile _mediaFile3;
        private string ruta3;
        private MediaFile _mediaFile4;
        private string ruta4;
        private MediaFile _mediaFile5;
        private string ruta5;
        private MediaFile _mediaFile6;
        private string ruta6;
        private MediaFile _mediaFile7;
        private string ruta7;

        private string NombreValidar;
        private int IdProfesionalValidar;

        private int IdProfesional;
        private string nombre_profesional;
        static Random _random = new Random();
        private int NumRand;
        public AgregarPortafolio (int idProfesional, string nombre_profesionales)
		{
			InitializeComponent ();
            IdProfesional = idProfesional;
            nombre_profesional = nombre_profesionales;
            NumRand = _random.Next();
        }
        private async void AgregarImg1_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
                    try
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("Error", "Camara no disponible", "OK");
                            return;
                        }

                        _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            PhotoSize = PhotoSize.Small,
                            Name = NumRand + nombre_profesional + IdProfesional + "_1.jpg"
                        });

                        if (_mediaFile == null)
                            return;

                        imagen1Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile.GetStream();
                        });
                        ruta = "/api_contratistas/images/" + NumRand + nombre_profesional + IdProfesional + "_1.jpg";
                        nombreimg1.Text = NumRand + nombre_profesional + IdProfesional + "_1.jpg";
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
                    try
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                            return;
                        }
                        _mediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            SaveMetaData = true,
                            PhotoSize = PhotoSize.Small
                        });
                        if (_mediaFile == null)
                            return;

                        imagen1Entry.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
                        string value = _mediaFile.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreimg1.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta = "/api_contratistas/images/" + nombreimg1.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void AgregarImg2_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
                    try
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("Error", "Camara no disponible", "OK");
                            return;
                        }

                        _mediaFile2 = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            PhotoSize = PhotoSize.Small,
                            Name = NumRand + nombre_profesional + IdProfesional + "_2.jpg"
                        });

                        if (_mediaFile2 == null)
                            return;

                        this.imagen2Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile2.GetStream();
                        });
                        ruta2 = "/api_contratistas/images/" + NumRand + nombre_profesional + IdProfesional + "_2.jpg";
                        nombreImg2.Text = NumRand + nombre_profesional + IdProfesional + "_2.jpg";

                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
                    try
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                            return;
                        }
                        _mediaFile2 = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            SaveMetaData = true,
                            PhotoSize = PhotoSize.Small
                        });
                        if (_mediaFile2 == null)
                            return;

                        imagen2Entry.Source = ImageSource.FromStream(() => _mediaFile2.GetStream());
                        string value = _mediaFile2.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreImg2.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta2 = "/api_contratistas/images/" + nombreImg2.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void AgregarImg3_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
                    try
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("Error", "Camara no disponible", "OK");
                            return;
                        }

                        _mediaFile3 = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            PhotoSize = PhotoSize.Small,
                            Name = NumRand + nombre_profesional + IdProfesional + "_3.jpg"
                        });

                        if (_mediaFile3 == null)
                            return;

                        this.imagen3Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile3.GetStream();
                        });
                        ruta3 = "/api_contratistas/images/" + NumRand + nombre_profesional + IdProfesional + "_3.jpg";
                        nombreImg3.Text = NumRand + nombre_profesional + IdProfesional + "_3.jpg";

                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
                    try
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                            return;
                        }
                        _mediaFile3 = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            SaveMetaData = true,
                            PhotoSize = PhotoSize.Small
                        });
                        if (_mediaFile3 == null)
                            return;

                        imagen3Entry.Source = ImageSource.FromStream(() => _mediaFile3.GetStream());

                        string value = _mediaFile3.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreImg3.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta3 = "/api_contratistas/images/" + nombreImg3.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void AgregarImg4_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
                    try
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("Error", "Camara no disponible", "OK");
                            return;
                        }

                        _mediaFile4 = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            PhotoSize = PhotoSize.Small,
                            Name = NumRand + nombre_profesional + IdProfesional + "_4.jpg"
                        });

                        if (_mediaFile4 == null)
                            return;

                        this.imagen4Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile4.GetStream();
                        });
                        ruta4 = "/api_contratistas/images/" + NumRand + nombre_profesional + IdProfesional + "_4.jpg";
                        nombreImg4.Text = NumRand + nombre_profesional + IdProfesional + "_4.jpg";
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
                    try
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                            return;
                        }
                        _mediaFile5 = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            SaveMetaData = true,
                            PhotoSize = PhotoSize.Small
                        });
                        if (_mediaFile4 == null)
                            return;

                        imagen4Entry.Source = ImageSource.FromStream(() => _mediaFile4.GetStream());

                        string value = _mediaFile4.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreImg4.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta4 = "/api_contratistas/images/" + nombreImg4.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void AgregarImg5_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
                    try
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("Error", "Camara no disponible", "OK");
                            return;
                        }

                        _mediaFile5 = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            PhotoSize = PhotoSize.Small,
                            Name = NumRand + nombre_profesional + IdProfesional + "_5.jpg"
                        });

                        if (_mediaFile5 == null)
                            return;

                        this.imagen5Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile5.GetStream();
                        });
                        ruta5 = "/api_contratistas/images/" + NumRand + nombre_profesional + IdProfesional + "_5.jpg";
                        nombreImg5.Text = NumRand + nombre_profesional + IdProfesional + "_5.jpg";

                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
                    try
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                            return;
                        }
                        _mediaFile5 = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            SaveMetaData = true,
                            PhotoSize = PhotoSize.Small
                        });
                        if (_mediaFile5 == null)
                            return;

                        imagen5Entry.Source = ImageSource.FromStream(() => _mediaFile5.GetStream());

                        string value = _mediaFile5.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreImg5.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta5 = "/api_contratistas/images/" + nombreImg5.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void AgregarImg6_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
                    try
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("Error", "Camara no disponible", "OK");
                            return;
                        }

                        _mediaFile6 = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            PhotoSize = PhotoSize.Small,
                            Name = NumRand + nombre_profesional + IdProfesional + "_6.jpg"
                        });

                        if (_mediaFile6 == null)
                            return;

                        this.imagen6Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile6.GetStream();
                        });

                        ruta6 = "/api_contratistas/images/" + NumRand + nombre_profesional + IdProfesional + "_6.jpg";
                        nombreImg6.Text = NumRand + nombre_profesional + IdProfesional + "_6.jpg";

                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
                    try
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                            return;
                        }
                        _mediaFile6 = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            SaveMetaData = true,
                            PhotoSize = PhotoSize.Small
                        });
                        if (_mediaFile6 == null)
                            return;

                        imagen6Entry.Source = ImageSource.FromStream(() => _mediaFile6.GetStream());

                        string value = _mediaFile6.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreImg6.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta6 = "/api_contratistas/images/" + nombreImg6.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void AgregarImg7_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Agregar imagenes", "Cancel", null, "SACAR FOTO", "ELEGIR DE LA GALERIA");
            switch (action)
            {
                case "SACAR FOTO":
                    try
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("Error", "Camara no disponible", "OK");
                            return;
                        }

                        _mediaFile7 = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            SaveToAlbum = true,
                            PhotoSize = PhotoSize.Small,
                            Name = NumRand + nombre_profesional + IdProfesional + "_7.jpg"
                        });

                        if (_mediaFile7 == null)
                            return;

                        this.imagen7Entry.Source = ImageSource.FromStream(() =>
                        {
                            return _mediaFile7.GetStream();
                        });
                        ruta7 = "/api_contratistas/images/" + NumRand + nombre_profesional + IdProfesional + "_7.jpg";
                        nombreImg7.Text = NumRand + nombre_profesional + IdProfesional + "_7.jpg";
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
                case "ELEGIR DE LA GALERIA":
                    try
                    {
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            await DisplayAlert("Error", "No se puede acceder a las imagenes", "OK");
                            return;
                        }
                        _mediaFile7 = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            SaveMetaData = true,
                            PhotoSize = PhotoSize.Small
                        });
                        if (_mediaFile7 == null)
                            return;

                        imagen7Entry.Source = ImageSource.FromStream(() => _mediaFile7.GetStream());

                        string value = _mediaFile7.Path.ToString();
                        char[] delimeters = new char[] { '/' };
                        String[] parts = value.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < parts.Length; i++)
                        {
                            nombreImg7.Text = parts[parts.Length - 1].ToString();
                        }

                        ruta7 = "/api_contratistas/images/" + nombreImg7.Text;
                    }
                    catch (Exception err)
                    {
                        await DisplayAlert("Error", err.ToString(), "OK");
                    }
                    break;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            NombreValidar = nombreEntry.Text;
            IdProfesionalValidar = IdProfesional;

            cargando.IsVisible = true;
            try
            {
                if (IdProfesionalValidar != 0)
                {
                    if (NombreValidar != null)
                    {
                        if (_mediaFile != null || _mediaFile2 != null)
                        {

                            HttpClient client = new HttpClient();
                            var content = new MultipartFormDataContent();
                            content.Add(new StreamContent(_mediaFile.GetStream()),
                                "\"file\"",
                                $"\"{_mediaFile.Path}\"");
                            var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content);

                            var content2 = new MultipartFormDataContent();
                            content2.Add(new StreamContent(_mediaFile2.GetStream()),
                                "\"file\"",
                                $"\"{_mediaFile2.Path}\"");
                            var result2 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content2);

                            var content3 = new MultipartFormDataContent();
                            if (_mediaFile3 != null)
                                content3.Add(new StreamContent(_mediaFile3.GetStream()),
                                    "\"file\"",
                                    $"\"{_mediaFile3.Path}\"");
                            var result3 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content3);

                            var content4 = new MultipartFormDataContent();
                            if (_mediaFile4 != null)
                                content4.Add(new StreamContent(_mediaFile4.GetStream()),
                                    "\"file\"",
                                    $"\"{_mediaFile4.Path}\"");
                            var result4 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content4);

                            var content5 = new MultipartFormDataContent();
                            if (_mediaFile5 != null)
                                content5.Add(new StreamContent(_mediaFile5.GetStream()),
                                    "\"file\"",
                                    $"\"{_mediaFile5.Path}\"");
                            var result5 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content5);

                            var content6 = new MultipartFormDataContent();
                            if (_mediaFile6 != null)
                                content6.Add(new StreamContent(_mediaFile6.GetStream()),
                                    "\"file\"",
                                    $"\"{_mediaFile6.Path}\"");
                            var result6 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content6);

                            var content7 = new MultipartFormDataContent();
                            if (_mediaFile7 != null)
                                content7.Add(new StreamContent(_mediaFile7.GetStream()),
                                    "\"file\"",
                                    $"\"{_mediaFile7.Path}\"");
                            var result7 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/subirImagen.php", content7);

                            Portafolio_profesional portafolio_Profesional = new Portafolio_profesional()
                            {
                                nombre = nombreEntry.Text,
                                imagen_1 = ruta,
                                imagen_2 = ruta2,
                                imagen_3 = ruta3,
                                imagen_4 = ruta4,
                                imagen_5 = ruta5,
                                imagen_6 = ruta6,
                                imagen_7 = ruta7,
                                id_profesional = IdProfesional
                            };

                            var json = JsonConvert.SerializeObject(portafolio_Profesional);
                            var content1 = new StringContent(json, Encoding.UTF8, "application/json");
                            var result1 = await client.PostAsync("http://dmrbolivia.online/api_contratistas/portafolios/agregarPortafolio_profesional.php", content1);

                            if (result1.StatusCode == HttpStatusCode.OK)
                            {
                                await DisplayAlert("GUARDAR", "El portafolio se agrego correctamente", "OK");
                                cargando.IsVisible = false;
                                await Navigation.PopAsync();
                            }
                            else
                            {
                                await DisplayAlert("ERROR", result.StatusCode.ToString(), "OK");
                                cargando.IsVisible = false;
                                await Navigation.PopAsync();
                            }

                        }
                        else
                        {
                            await DisplayAlert("ERROR", "Se requiere cargar 2 fotos como minimo", "OK");
                            cargando.IsVisible = false;
                        }
                    }
                    else
                    {
                        await DisplayAlert("ERROR", "Es necesario introducir un Nombre", "OK");
                        cargando.IsVisible = false;
                    }
                }
                else
                {
                    await DisplayAlert("ERROR", "Algo salio mal, intentelo nuevamente", "OK");
                    cargando.IsVisible = false;
                    await Navigation.PopAsync();
                }
            }
            catch (Exception err)
            {
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = err.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
                cargando.IsVisible = false;
            }
        }
    }
}