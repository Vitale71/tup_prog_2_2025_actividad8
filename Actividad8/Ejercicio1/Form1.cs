using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        List<Vehiculo> listaVehiculo = new List<Vehiculo>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos CSV|*.csv|Todos los archivos|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string name = ofd.FileName;
                //forma correcta de hacerlo
                FileStream fs = null;
                StreamReader sr = null;
                try
                {
                    fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string cadena = sr.ReadLine().Trim();//lee cada linea y quita los espacios en blanco
                        string[] separator = cadena.Split(';');

                        string patente = separator[0];
                        double importer = Convert.ToDouble(separator[1]);
                        Vehiculo auto = new Vehiculo(patente, importer);

                        listaVehiculo.Add(auto);

                        /*Mediante el metodo importar mas facil
                        string cadena = sr.ReadLine().Trim(); 
                        Vehiculo auto = new Vehiculo();
                        auto.Importar(cadena);
                        listaVehiculo.Add(auto);*/
                    }
                }
                catch (PatenteException pe)
                {
                    MessageBox.Show("ERROR", pe.Message);
                }

                catch (Exception ex) //Exepcion generalizada
                {
                    MessageBox.Show("ERROR", ex.Message);
                }
                finally
                {
                    if (fs != null) fs.Close();
                    if (sr != null) sr.Close();
                }

                foreach (Vehiculo s in listaVehiculo)
                {
                    tbMostrar.Text += s.ToString() + "\t\n";
                }

                /* Otra forma de hacerlo
                FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                sr.ReadLine();
                while (!sr.EndOfStream)
                    {
                        string cadena = sr.ReadLine().Trim();
                        string[] separator = cadena.Split(';');

                        string patente = separator[0];
                        double importer = Convert.ToDouble(separator[1]);
                        Vehiculo auto = new Vehiculo(patente, importer);

                        listaVehiculo.Add(auto);
                    }
                 
                */

                /*
                FileStream fs = null;
                StreamReader sr = null;
                try
                {
                    fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                    sr = new StreamReader(fs);
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string cadena = sr.ReadLine().Trim();
                        string[] separator = cadena.Split(';');

                        string patente = separator[0];
                        double importer = Convert.ToDouble(separator[1]);
                        Vehiculo auto = new Vehiculo(patente, importer);

                        listaVehiculo.Add(auto);
                    }
                }
                catch (PatenteException pe)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }
                    
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", ex.Message);
                }
                finally
                {
                    if (fs != null) fs.Close();
                    if (sr != null) sr.Close();
                }*/
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "Vehiculo.csv"; // path es la ruta del archivo, si el mismo esta dentro de otras carpetas hay que expecificar mas la ruta
            string [] lineas = File.ReadAllLines(path);

            foreach (string line in lineas)
            {
                string[] s = line.Split(';');
                tbMostrar.Text += s[0] + " " + s[1] + "\r\n";
            }
        }
    }
}
