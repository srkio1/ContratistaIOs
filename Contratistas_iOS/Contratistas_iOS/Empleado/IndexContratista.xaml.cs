using Contratistas_iOS.Datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contratistas_iOS.FeedBack;

namespace Contratistas_iOS.Empleado
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndexContratista : ContentPage
    {
        private int IdContratista;
        private string Nombre;
        private string Apellidop;
        private string Apellidom;
        private int Telefono;
        private string Direccion;
        private string Foto;
        private string Cedulaidentidad;
        private string Rubro;
        private decimal Calififacion;
        private string Estadoo;
        private int Prioridad;
        private string Descripcion;
        private int Nit;
        private string Usuario;
        private string Contrasena;
        public IndexContratista(int id_contratista, string nombre, string apellido_paterno, string apeliido_materno, int telefono, string direccion, string foto, string cedulaidentidad, string rubro,
                             decimal calificacion, string estado, int prioridad, string descripcion, int nit, string usuario, string contrasena)
        {
            InitializeComponent();
            IdContratista = id_contratista;
            Nombre = nombre;
            Apellidop = apellido_paterno;
            Apellidom = apeliido_materno;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            Cedulaidentidad = cedulaidentidad;
            Rubro = rubro;
            Calififacion = calificacion;
            Estadoo = estado;
            Prioridad = prioridad;
            Descripcion = descripcion;
            Nit = nit;
            Usuario = usuario;
            Contrasena = contrasena;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetInfo();
        }
        private async void GetInfo()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync("http://dmrbolivia.online/api_contratistas/contratistas/listaContratista.php");
                var contratistas = JsonConvert.DeserializeObject<List<Datos.Contratista>>(response);

                foreach (var item in contratistas.Distinct())
                {
                    if (item.id_contratista == IdContratista)
                    {
                        txtNombre.Text = item.nombre;
                        txtTelefono.Text = item.telefono.ToString();
                        txtRubro.Text = item.rubro;
                        txtDescripcion.Text = item.descripcion;
                        txtCalificacion.Text = item.calificacion.ToString();
                        txtEstado.Text = item.estado;
                        img_perfil.Source = "http://dmrbolivia.online" + item.foto;
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
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarFeedBackContratista(IdContratista));
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModificarEmpleado(IdContratista, Nombre, Apellidop, Apellidom, Telefono, Direccion, Foto, Cedulaidentidad, Rubro, Calififacion, Estadoo, Prioridad, Descripcion, Nit, Usuario, Contrasena));
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

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}