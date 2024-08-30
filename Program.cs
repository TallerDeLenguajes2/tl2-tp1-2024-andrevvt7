namespace espacioCadeteria{

public class Program
{
    public static void Main()
    {
        AccesoADatos datosCadeterias = new AccesoADatos("cadeterias.csv");
        List<Cadeteria> cadeterias = datosCadeterias.cargarCadeterias();

        foreach (var cadeteria in cadeterias)
        {
            Console.WriteLine(cadeteria.Nombre);
        }
    }
}
}