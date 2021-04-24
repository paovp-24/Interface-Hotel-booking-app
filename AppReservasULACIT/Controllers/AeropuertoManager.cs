﻿using AppReservasULACIT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppReservasULACIT.Controllers
{
    public class AeropuertoManager
    {

        string Url = "http://localhost:49220/api/aeropuerto/";

        HttpClient GetClient(string token)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<IEnumerable<Aeropuerto>> ObtenerHoteles(string token)
        {
            HttpClient httpClient = GetClient(token);

            string resultado = await httpClient.GetStringAsync(Url);

            return JsonConvert.DeserializeObject<IEnumerable<Aeropuerto>>(resultado);
        }

        public async Task<Aeropuerto> ObtenerAeropuertol(string token, string codigo)
        {
            HttpClient httpClient = GetClient(token);

            string resultado = await httpClient.GetStringAsync(string.Concat(Url, codigo));

            return JsonConvert.DeserializeObject<Aeropuerto>(resultado);
        }

        public async Task<Aeropuerto> Ingresar(Aeropuerto aeropuerto, string token)
        {
            HttpClient httpClient = GetClient(token);

            var response = await httpClient.PostAsync(Url,
                new StringContent(JsonConvert.SerializeObject(aeropuerto),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Aeropuerto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Aeropuerto> Actualizar(Aeropuerto aeropuerto, string token)
        {
            HttpClient httpClient = GetClient(token);

            var response = await httpClient.PutAsync(Url,
                new StringContent(JsonConvert.SerializeObject(aeropuerto),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Aeropuerto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Eliminar(string codigo, string token)
        {
            HttpClient httpClient = GetClient(token);

            var response = await httpClient.DeleteAsync(string.Concat(Url, codigo));

            return JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
        }



    }
}