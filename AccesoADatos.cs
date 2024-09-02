namespace espacioDeLaCadeteria{
    public class AccesoADatos
    {
        public List<string[]>? ObtenerDatos(string rutaConNombreArchivo){
            var datos = new List<string[]>(); //SE DEVOLVERÁ UNA LISTA DE ARRAYS DE STRING

            //ReadAllLines retorna un arreglo de strings (cada elemento es una línea del archivo)
            string[] lineas = File.ReadAllLines(rutaConNombreArchivo); //obtiene todas las líneas del archivo (File es una clase)
            
            foreach (var linea in lineas) //por cada línea hacer un split con , para separar los valores
            {
                var lineaDato = linea.Split(',');
                datos.Add(lineaDato);
            }

            return datos;
        }
    }   
}