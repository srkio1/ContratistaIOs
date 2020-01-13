﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contratistas_iOS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaContratista : ContentPage
	{
        private string queryrubro;
        public ListaContratista (string rubro)
		{
			InitializeComponent ();
            queryrubro = rubro;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            HttpClient client = new HttpClient();
            if (queryrubro == "Albañil" || queryrubro == "Albanil")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaAlbanil.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Plomero")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaPlomero.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Soldador")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaSoldador.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Electricista")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaElectricista.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Carpintero")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaCarpintero.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Pintor")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaPintor.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Aire acondicionado")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaAireAcondicionado.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Cerrajero")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaCerrajero.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Jardinero")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaJardinero.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Vidriero")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaVidriero.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
            else if (queryrubro == "Operador")
            {
                var url_contratista = new Uri("http://dmrbolivia.online/api_contratistas/contratistas/querys/listaOperador.php");
                string result = await client.GetStringAsync(url_contratista);
                var usuarios = JsonConvert.DeserializeObject<List<Datos.Contratista>>(result);
                listaContratistas.ItemsSource = usuarios;
            }
        }

        private async void ListaContratistas_ItemTapped_1(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Datos.Contratista;
            await Navigation.PushAsync(new PerfilContratista(detalles.id_contratista, detalles.nombre,
                                                         detalles.apellido_paterno, detalles.apellido_materno,
                                                         detalles.telefono, detalles.foto, detalles.rubro,
                                                         detalles.calificacion, detalles.descripcion));
        }
    }
}