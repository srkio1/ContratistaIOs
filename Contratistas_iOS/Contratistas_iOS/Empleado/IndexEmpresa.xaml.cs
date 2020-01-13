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
    public partial class IndexEmpresa : TabbedPage
    {
        private int IdEmpresa;
        private string Nombre_empresa;
        private int Telefono;
        private string Email;
        private string Direccion;
        private string Ubicacion_lat;
        private string Ubicacion_long;
        private string Foto;
        private int Nit;
        private string Rubro;
        private decimal Calififacion;
        private int Prioridad;
        private string Descripcion;
        private string Fundaempresa;
        private string Usuario;
        private string Contrasena;
        ObservableCollection<Portafolio_empresa> portafolio_Empresas = new ObservableCollection<Portafolio_empresa>();
        public ObservableCollection<Portafolio_empresa> Portafolios { get { return portafolio_Empresas; } }
        public IndexEmpresa (int id_empresa, string nombre, int telefono, string email, string direccion, string ubicacion_lat, string ubicacion_long, string foto, int nit,
            string rubro, decimal calificacion, int prioridad, string descripcion, string fundaempresa, string usuario, string contrasena)
        {
            InitializeComponent();
            IdEmpresa = id_empresa;
            Nombre_empresa = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            Ubicacion_lat = ubicacion_lat;
            Ubicacion_long = ubicacion_long;
            Foto = foto;
            Nit = nit;
            Rubro = rubro;
            Calififacion = calificacion;
            Prioridad = prioridad;
            Descripcion = descripcion;
            Fundaempresa = fundaempresa;
            Usuario = usuario;
            Contrasena = contrasena;
            TraerPerfil();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            portafolio_Empresas.Clear();
            GetInfo();
            TraerPerfil();
        }

        private async void TraerPerfil()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/empresas/listaEmpresa.php");
                var empresas = JsonConvert.DeserializeObject<List<Empresa>>(response);

                foreach (var item in empresas.Distinct())
                {
                    if (item.id_empresa == IdEmpresa)

                    {
                        img_perfil.Source = "http://dmrbolivia.online" + item.foto;
                        txtNombre.Text = item.nombre;
                        txtTelefono.Text = item.telefono.ToString();
                        txtEmail.Text = item.email;
                        txtRubro.Text = item.rubro;
                        txtPrioridad.Text = item.prioridad.ToString();

                        txtNit.Text = item.nit.ToString();
                        txtDescripcion.Text = item.descripcion;
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
                HttpClient client = new HttpClient();
                var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/agregarReporteLog.php", content);
            }
        }
        private async void GetInfo()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/portafolios/listaPortafolio_empresa.php");
                var portafolios = JsonConvert.DeserializeObject<List<Portafolio_empresa>>(response);

                foreach (var item in portafolios.Distinct())
                {
                    if (item.id_empresa == IdEmpresa)
                    {
                        portafolio_Empresas.Add(new Portafolio_empresa
                        {
                            nombre = item.nombre,
                            id_portafolio_e = item.id_portafolio_e,
                            imagen_1 = item.imagen_1,
                            imagen_2 = item.imagen_2,
                            imagen_3 = item.imagen_3,
                            imagen_4 = item.imagen_4,
                            imagen_5 = item.imagen_5,
                            imagen_6 = item.imagen_6,
                            imagen_7 = item.imagen_7,
                            id_empresa = item.id_empresa
                        });
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
            listPortafolios.ItemsSource = portafolio_Empresas.Distinct();
        }

        private async void ListPortafolios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Portafolio_empresa;
            await Navigation.PushAsync(new VerportafolioEmpresaE(detalles.id_portafolio_e, detalles.nombre, detalles.imagen_1, detalles.imagen_2, detalles.imagen_3,
                                                            detalles.imagen_4, detalles.imagen_5, detalles.imagen_6, detalles.imagen_7, detalles.id_empresa));


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarPortafolioEmpresa(IdEmpresa, Nombre_empresa));
        }

        private void Modificar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModificarEmpresa(IdEmpresa, Nombre_empresa, Telefono, Email, Direccion, Ubicacion_lat, Ubicacion_long, Foto, Nit, Rubro, Calififacion, Prioridad, Descripcion, Fundaempresa, Usuario, Contrasena));
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alert", "Quiere Cerrar Sesion", "Si", "No");
                if (result) await this.Navigation.PushAsync(new Index());
            });
            return true;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarFeedBackEmpresa(IdEmpresa));
        }
    }
}