using Contratistas_iOS.Datos;
using Newtonsoft.Json;
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
	public partial class ModificarEmpresa : ContentPage
	{
        private int IdEmpresa1;
        private string Nombre_empresa1;
        private int Telefono1;
        private string Email1;
        private string Direccion1;
        private string Ubicacion_lat1;
        private string Ubicacion_long1;
        private string Foto1;
        private int Nit1;
        private string Rubro1;
        private decimal Calififacion1;
        private int Prioridad1;
        private string Descripcion1;
        private string Fundaempresa1;
        private string Usuario1;
        private string Contrasena1;
        public ModificarEmpresa (int IdEmpresa, string Nombre_empresa, int Telefono, string Email, string Direccion,
           string Ubicacion_lat, string Ubicacion_long, string Foto, int Nit, string Rubro, decimal Calififacion, int Prioridad, string Descripcion, string Fundaempresa,
           string Usuario, string Contrasena)
		{
			InitializeComponent ();
            IdEmpresa1 = IdEmpresa;
            Nombre_empresa1 = Nombre_empresa;
            Telefono1 = Telefono;
            Email1 = Email;
            Direccion1 = Direccion;
            Ubicacion_lat1 = Ubicacion_lat;
            Ubicacion_long1 = Ubicacion_long;
            Foto1 = Foto;
            Nit1 = Nit;
            Rubro1 = Rubro;
            Calififacion1 = Calififacion;
            Prioridad1 = Prioridad;
            Descripcion1 = Descripcion;
            Fundaempresa1 = Fundaempresa;
            Usuario1 = Usuario;
            Contrasena1 = Contrasena;
            nombreEntry.Text = Nombre_empresa;
            telefonoentry.Text = Telefono.ToString();
            emailentry.Text = Email;
            descripcionentry.Text = Descripcion;
            nitentry.Text = Nit.ToString();
        }
        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (IdEmpresa1 > 0)
            {
                if (telefonoentry.Text.Length > 7 || 9 < telefonoentry.Text.Length)
                {
                    if (emailentry.Text.Length > 0)
                    {
                        if (Rubro1.Length > 0)
                        {
                            if (descripcionentry.Text.Length > 0)
                            {
                                try
                                {
                                    Empresa empresa = new Empresa()
                                    {
                                        id_empresa = IdEmpresa1,
                                        nombre = nombreEntry.Text,
                                        telefono = Convert.ToInt32(telefonoentry.Text),
                                        email = emailentry.Text,
                                        direccion = Direccion1,
                                        ubicacion_lat = Ubicacion_lat1,
                                        ubicacion_long = Ubicacion_long1,
                                        foto = Foto1,
                                        nit = Convert.ToInt32(nitentry.Text),
                                        rubro = Rubro1,
                                        calificacion = Calififacion1,
                                        prioridad = Prioridad1,
                                        descripcion = descripcionentry.Text,
                                        fundaempresa = Fundaempresa1,
                                        usuario = Usuario1,
                                        contrasena = Contrasena1
                                    };

                                    var json = JsonConvert.SerializeObject(empresa);

                                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                                    HttpClient client = new HttpClient();

                                    var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/empresas/editarEmpresa.php", content);

                                    if (result.StatusCode == HttpStatusCode.OK)
                                    {
                                        await DisplayAlert("EDITAR", "Se edito correctamente", "OK");
                                        await Navigation.PopAsync();
                                    }
                                    else
                                    {
                                        await DisplayAlert("ERROR", result.StatusCode.ToString(), "OK");
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
                                }
                            }
                            else
                            {
                                await DisplayAlert("ERROR", "El campo de Descripcion es necesario", "OK");
                            }
                        }
                        else
                        {
                            await DisplayAlert("ERROR", "El campo de Rubro es necesario", "OK");
                        }
                    }
                    else
                    {
                        await DisplayAlert("ERROR", "El campo de Email es necesario", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("ERROR", "El campo de telefono es necesario", "OK");
                }
            }
            else
            {
                await DisplayAlert("ERROR", "Algo salio mal, intentelo de nuevo", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}