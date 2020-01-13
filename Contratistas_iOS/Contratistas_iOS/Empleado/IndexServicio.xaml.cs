﻿using Contratistas_iOS.Datos;
using Contratistas_iOS.FeedBack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratistas_iOS.Empleado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndexServicio : TabbedPage
    {
        private int IdServicio;
        private string Nombre_servicio;
        private int Telefono;
        private string Email;
        private string Direccion;
        private string Ubicacion_lat;
        private string Ubicacion_long;
        private string Foto;
        private string Estado;
        private int Nit;
        private string Rubro;
        private decimal Calififacion;
        private int Prioridad;
        private string Descripcion;
        private string Usuario;
        private string Contrasena;
        ObservableCollection<Catalogo> catalogos = new ObservableCollection<Catalogo>();
        public ObservableCollection<Catalogo> Catalogos { get { return catalogos; } }
        public IndexServicio (int id_servicio, string nombre, int telefono, string email, string direccion, string ubicacion_lat,
            string ubicacion_long, string foto, string estado, int nit, string rubro, decimal calificacion, int prioridad,
                               string descripcion, string usuario, string contrasena)
        {
            InitializeComponent();
            IdServicio = id_servicio;
            Nombre_servicio = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            Ubicacion_lat = ubicacion_lat;
            Ubicacion_long = ubicacion_long;
            Foto = foto;
            Estado = estado;
            Nit = nit;
            Rubro = rubro;
            Calififacion = calificacion;
            Prioridad = prioridad;
            Descripcion = descripcion;
            Usuario = usuario;
            Contrasena = contrasena;
            IdServicio = id_servicio;
            Nombre_servicio = nombre;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetPerfil();
            stkPromoActiva.Children.Clear();
            stkPromoInactiva.Children.Clear();
            GetCatalogo();
            GetPromo();
        }

        private async void ListPortafolios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Catalogo;
            await Navigation.PushAsync(new VercatalogoServicio(detalles.id_catalogo, detalles.nombre, detalles.imagen_1, detalles.imagen_2, detalles.descripcion, detalles.id_servicio));
        }
        private async void GetPerfil()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/servicios/listaServicio.php");
            var servicios = JsonConvert.DeserializeObject<List<Servicio>>(response);
            try
            {
                foreach (var item in servicios.Distinct())
                {
                    if (item.id_servicio == IdServicio)
                    {
                        txtNombre.Text = item.nombre;
                        txtTelefono.Text = item.telefono.ToString();
                        txtEmail.Text = item.email;
                        txtRubro.Text = item.rubro;
                        txtEstado.Text = item.estado;
                        txtPrioridad.Text = item.prioridad.ToString();
                        txtNit.Text = item.nit.ToString();
                        txtDescripcion.Text = item.descripcion;
                        img_perfil.Source = "http://dmrbolivia.online" + item.foto;
                    }
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
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
        }
        private async void GetCatalogo()
        {

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/catalogos/listaCatalogo.php");
            var catalogosss = JsonConvert.DeserializeObject<List<Catalogo>>(response);
            try
            {
                foreach (var item in catalogosss.Distinct())
                {
                    if (item.id_servicio == IdServicio)
                    {
                        catalogos.Add(new Catalogo

                        {
                            id_catalogo = item.id_catalogo,
                            nombre = item.nombre,
                            imagen_1 = item.imagen_1,
                            imagen_2 = item.imagen_2,
                            descripcion = item.descripcion
                        });
                    }
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
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
            listPortafolios.ItemsSource = catalogosss.Distinct();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarCatalogo(IdServicio, Nombre_servicio));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPromoServicio(IdServicio, Nombre_servicio));
        }
        private async void GetPromo()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/promociones/listaPromocionServicio.php");
                var listpromo = JsonConvert.DeserializeObject<List<Promocion_servicios>>(response);

                foreach (var item in listpromo.Distinct())
                {
                    if (item.id_servicio == IdServicio)
                    {
                        StackLayout stk1 = new StackLayout();
                        stkPromoActiva.Children.Add(stk1);

                        Label txtNombre = new Label();
                        txtNombre.Text = item.nombre;
                        txtNombre.TextColor = Color.Black;
                        txtNombre.FontSize = 30;
                        stk1.Children.Add(txtNombre);

                        Image img = new Image();
                        img.Source = "http://dmrbolivia.online" + item.imagen;
                        img.HeightRequest = 200;
                        img.Aspect = Aspect.AspectFit;
                        img.HorizontalOptions = LayoutOptions.CenterAndExpand;
                        stk1.Children.Add(img);

                        Label txtDesc = new Label();
                        txtDesc.Text = item.descripcion;
                        txtDesc.FontSize = 15;
                        txtDesc.TextColor = Color.Black;
                        stk1.Children.Add(txtDesc);

                        Button btnEditar = new Button();
                        btnEditar.Text = "EDITAR PROMOCION";
                        btnEditar.HorizontalOptions = LayoutOptions.FillAndExpand;
                        btnEditar.BackgroundColor = Color.Yellow;
                        btnEditar.TextColor = Color.Black;
                        btnEditar.Clicked += async (sender, args) => await Navigation.PushAsync(new EditarPromocionServicio(item.id_servicio, item.nombre, item.estado, item.descripcion, item.imagen, item.id_promocion_s));
                        stk1.Children.Add(btnEditar);

                        BoxView bv = new BoxView();
                        bv.HeightRequest = 5;
                        bv.Color = Color.Black;
                        stk1.Children.Add(bv);
                    }
                }

                var response2 = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/promociones/listaPromocionServicioInactiva.php");
                var listpromo2 = JsonConvert.DeserializeObject<List<Promocion_servicios>>(response2);

                foreach (var item in listpromo2.Distinct())
                {
                    if (item.id_servicio == IdServicio)
                    {
                        StackLayout stk2 = new StackLayout();
                        stkPromoInactiva.Children.Add(stk2);

                        Label txtNombre = new Label();
                        txtNombre.Text = item.nombre;
                        txtNombre.TextColor = Color.Black;
                        txtNombre.FontSize = 20;
                        stk2.Children.Add(txtNombre);

                        Image img = new Image();
                        img.Source = "http://dmrbolivia.online" + item.imagen;
                        img.HeightRequest = 200;
                        img.Aspect = Aspect.AspectFit;
                        img.HorizontalOptions = LayoutOptions.CenterAndExpand;
                        stk2.Children.Add(img);

                        Label txtDesc = new Label();
                        txtDesc.Text = item.descripcion;
                        txtDesc.FontSize = 15;
                        txtDesc.TextColor = Color.Black;
                        stk2.Children.Add(txtDesc);

                        Button btnEditar = new Button();
                        btnEditar.Text = "EDITAR PROMOCION";
                        btnEditar.HorizontalOptions = LayoutOptions.FillAndExpand;
                        btnEditar.BackgroundColor = Color.Yellow;
                        btnEditar.TextColor = Color.Black;
                        btnEditar.Clicked += async (sender, args) => await Navigation.PushAsync(new EditarPromocionServicio(item.id_servicio, item.nombre, item.estado, item.descripcion, item.imagen, item.id_promocion_s));
                        stk2.Children.Add(btnEditar);

                        BoxView bv = new BoxView();
                        bv.HeightRequest = 5;
                        bv.Color = Color.Black;
                        stk2.Children.Add(bv);
                    }
                }
            }

            catch (Exception erro)
            {
                await DisplayAlert("Error", "Algo salio mal, intentalo de nuevo", "OK");
                ReportesLogs reportesLogs = new ReportesLogs()
                {
                    descripcion = erro.ToString(),
                    fecha = DateTime.Now.ToLocalTime()
                };
                var json = JsonConvert.SerializeObject(reportesLogs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
        }

        private void Modiicar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModificarServicio(IdServicio, Nombre_servicio, Telefono, Email, Direccion, Ubicacion_lat, Ubicacion_long, Foto,
                         Estado, Nit, Rubro, Calififacion, Prioridad, Descripcion, Usuario, Contrasena));
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alerta", "Quiere Cerrar Sesion?", "Si", "No");
                if (result) await this.Navigation.PushAsync(new Index());
            });
            return true;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarFeedBackServicio(IdServicio));
        }
    }
}