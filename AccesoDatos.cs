namespace espacioCadeteria{
    public class AccesoADatos{
        private string ruta;
        public string Ruta { get => ruta; set => ruta = value; }
        public AccesoADatos(string ruta)
        {
           this.ruta = ruta;    
        }

        public List<Cadete> cargarCadetes(){
            List<Cadete> cadetes = new List<Cadete>();
            string carpeta = "CSV/";
            //ReadAllLines retorna un arreglo de strings (cada elemento es una línea del archivo)
            string[] lineas = File.ReadAllLines(carpeta + ruta); //obtiene todas las líneas del archivo (File es una clase)
            
            foreach (var linea in lineas) //por cada línea hacer un split con ; o , para separar los valores
            {
                Cadete cadete = new Cadete();
                var arregloCadete = linea.Split(';').ToList();
                cadete.Id = int.Parse(arregloCadete[0]);
                cadete.Nombre = arregloCadete[1];
                cadete.Direccion = arregloCadete[2];
                cadete.Telefono = arregloCadete[3];

                cadetes.Add(cadete);
            }

            return cadetes;
        }

        public List<Cadeteria> cargarCadeterias(){
            List<Cadeteria> cadeterias = new List<Cadeteria>();
            string carpeta = "CSV/";
            //ReadAllLines retorna un arreglo de strings (cada elemento es una línea del archivo)
            string[] lineas = File.ReadAllLines(carpeta + ruta); //obtiene todas las líneas del archivo (File es una clase)
            
            foreach (var linea in lineas) //por cada línea hacer un split con ; o , para separar los valores
            {
                Cadeteria cadeteria = new Cadeteria();
                var arregloCadeteria = linea.Split(';').ToList();
                cadeteria.Nombre = arregloCadeteria[0];
                cadeteria.Telefono = arregloCadeteria[1];

                cadeterias.Add(cadeteria);
            }

            return cadeterias;
        }

        public List<Cliente> cargarClientes(){
            List<Cliente> clientes = new List<Cliente>();
            string carpeta = "CSV/";
            //ReadAllLines retorna un arreglo de strings (cada elemento es una línea del archivo)
            string[] lineas = File.ReadAllLines(carpeta + ruta); //obtiene todas las líneas del archivo (File es una clase)
            
            foreach (var linea in lineas) //por cada línea hacer un split con ; o , para separar los valores
            {
                Cliente cliente = new Cliente();
                var arregloCliente = linea.Split(';').ToList();
                cliente.Nombre = arregloCliente[0];
                cliente.Direccion = arregloCliente[1];
                cliente.Telefono = arregloCliente[2];
                cliente.DatosReferenciaDireccion = arregloCliente[3];

                clientes.Add(cliente);
            }

            return clientes;
        }
    }   
}