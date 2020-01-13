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
	public partial class MostrarPortafolio : ContentPage
	{
        int IdPortafolio;
        public MostrarPortafolio (int id_portafolio, string nombre, string imagen_1, string imagen_2, string imagen_3, string imagen_4, string imagen_5, string imagen_6,
                                 string imagen_7, int id_profesional)
		{
			InitializeComponent ();
            IdPortafolio = id_portafolio;

            List<CustomData> GetDataSource()
            {
                List<CustomData> list = new List<CustomData>();
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_1));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_2));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_3));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_4));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_5));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_6));
                list.Add(new CustomData("http://dmrbolivia.online" + imagen_7));
                return list;
            }
            rotator.ItemsSource = GetDataSource();
            TituloTxt.Text = nombre;
        }
        private async void BtnBorrar_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("BORRAR PORTAFOLIO?", null, null, "SI", "NO");
            switch (action)
            {
                case "SI":
                    try
                    {
                        Portafolio_profesional portafolio_Profesional = new Portafolio_profesional()
                        {
                            id_portafolio_p = IdPortafolio
                        };

                        var json = JsonConvert.SerializeObject(portafolio_Profesional);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpClient client = new HttpClient();
                        var result = await client.PostAsync("http://dmrbolivia.online/api_contratistas/portafolios/borrarPortafolioProfesional.php", content);

                        if (result.StatusCode == HttpStatusCode.OK)
                        {
                            await DisplayAlert("BORRAR", "Se borro correctamente", "OK");
                            await Navigation.PopAsync(true);
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
                    break;
                case "NO":
                    break;
            }
        }
    }
}