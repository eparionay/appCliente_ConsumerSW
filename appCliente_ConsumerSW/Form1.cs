using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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

            string url = "https://localhost:44343/api/alumno/registrar";
            HttpClient cliente = new HttpClient();
            Alumno objAlumno = new Alumno();
            objAlumno.Codigo = 0; //
            objAlumno.Nombre = "Cesar";
            objAlumno.ApellidoPaterno = "Gamar";
            objAlumno.ApellidoMaterno = "Geu";
            objAlumno.Genero = "M";
            objAlumno.Documento = "78978978";
            objAlumno.Estado = 1;//
            var solicitud = cliente.PostAsync(
                url, objAlumno, new JsonMediaTypeFormatter()).Result;
                
            if (solicitud.IsSuccessStatusCode)
            {
                var result = solicitud.Content.ReadAsStringAsync().Result;
                var respuesta = JsonConvert.DeserializeObject<RespuestaServicio>(result);
                MessageBox.Show(respuesta.codigo + "-"+ respuesta.mensaje);
            }
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
