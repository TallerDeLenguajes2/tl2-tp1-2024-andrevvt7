using System.Security.Cryptography;

namespace espacioCadeteria{
public class Cadeteria{
    private string? nombre;
    private string? telefono;
    private List<Cadete>? listadoCadetes;
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public List<Cadete>? ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

         public Cadeteria()
        {
        }

    //Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado y la cantidad de envíos de cada cadete y el total. 
    //Muestre también la cantidad de envíos promedio por cadete.
        public void GenerarInforme(List<Cadete> listadoCadetes)
        {
            float totalRecaudadoDelDia = (from cadete in listadoCadetes select cadete.montoTotal()).Sum();
            int enviosTotalesDelDia = (from cadete in listadoCadetes select cadete.cantidadEnvios()).Sum();

            Console.WriteLine("Monto ganado: $" + totalRecaudadoDelDia);
            Console.WriteLine("Cantidad de envíos de cada cadete: \n");
            foreach (var cadete in listadoCadetes)
            {
                Console.WriteLine("Cadete " + cadete.Id + " - Envíos: " + cadete.cantidadEnvios() + "\n");
            }
            Console.WriteLine("Total de envíos: " + enviosTotalesDelDia + " \n");
            Console.WriteLine("Cantidad de envíos promedio por cadete: \n");
            foreach (var cadete in listadoCadetes)
            {
                Console.WriteLine("Cadete " + cadete.Id + " - Envíos: " + cadete.cantidadEnvios()/enviosTotalesDelDia + "\n");
            }
        }
}
}