using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appCliente_ConsumerSW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44343/api/alumno/lista";
            HttpClient cliente = new HttpClient();
            var request = cliente.GetAsync(url).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultado = request.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<List<Alumno>>(resultado);
                foreach ( var item in response )
                {
                    MessageBox.Show("Documento : " + item.Documento + "- Nombre: " + item.Nombre);
                }

            }
        }
    }
}
