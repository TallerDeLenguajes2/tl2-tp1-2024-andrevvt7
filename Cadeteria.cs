using System.Security.Cryptography;

namespace espacioCadeteria{
public class Cadeteria{
    private string? nombre;
    private string? telefono;
    private List<Cadete>? listadoCadetes;
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public List<Cadete>? ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria(){}
        public Cadeteria(Cadeteria cadeteria, List<Cadete> cadetes){
            this.nombre = cadeteria.nombre;
            this.telefono = cadeteria.telefono;
            this.listadoCadetes = cadetes;
        }
        public Cadeteria(Cadeteria cadeteria){
            this.nombre = cadeteria.nombre;
            this.telefono = cadeteria.telefono;
            this.listadoCadetes = new List<Cadete>();
        }
        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes){
            this.nombre = nombre;
            this.telefono = telefono;
            this.ListadoCadetes = cadetes;
        }
        public Cadeteria(string nombre, string telefono){
            this.nombre = nombre;
            this.telefono = telefono;
            this.listadoCadetes = new List<Cadete>();
        }

    //Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado y la cantidad de envíos de cada cadete y el total. 
    //Muestre también la cantidad de envíos promedio por cadete.
        public void GenerarInforme()
        {
            float totalRecaudadoDelDia = (from cadete in listadoCadetes select cadete.montoTotal()).Sum();
            int enviosTotalesDelDia = (from cadete in listadoCadetes select cadete.cantidadEnvios()).Sum();

            Console.WriteLine("Monto ganado: $" + totalRecaudadoDelDia);
            Console.WriteLine("Cantidad de envíos de cada cadete: ");
            foreach (var cadete in listadoCadetes)
            {
                Console.WriteLine("            Cadete " + cadete.Id + " - Envíos: " + cadete.cantidadEnvios());
            }
            Console.WriteLine("Total de envíos: " + enviosTotalesDelDia);
            Console.WriteLine("Cantidad de envíos promedio por cadete: ");
            foreach (var cadete in listadoCadetes)
            {
                Console.WriteLine("            Cadete " + cadete.Id + " - Promedio de envíos: " + cadete.cantidadEnvios()*100/enviosTotalesDelDia + "%");
            }
        }
}
}