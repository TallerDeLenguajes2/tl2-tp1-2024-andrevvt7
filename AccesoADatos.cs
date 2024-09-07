using System.Text.Json;

namespace espacioDeLaCadeteria;
public abstract class AccesoADatos
{
    public abstract List<Cadete>? ObtenerDatosCadetes(string nombreArchivo);
    public abstract List<Cadeteria>? ObtenerDatosCadeterias(string nombreArchivo);
}

public class AccesoCSV : AccesoADatos
{
    public override List<Cadete>? ObtenerDatosCadetes(string nombreArchivo)
    {
        var cadetes = new List<Cadete>();

        string[] lineas = File.ReadAllLines(nombreArchivo);

        foreach (var linea in lineas)
        {
            var lineaDato = linea.Split(',');
            cadetes.Add(new Cadete(int.Parse(lineaDato[0]), lineaDato[1], lineaDato[2], lineaDato[3]));
        }

        return cadetes;
    }
    public override List<Cadeteria>? ObtenerDatosCadeterias(string nombreArchivo)
    {
        var cadeterias = new List<Cadeteria>();

        string[] lineas = File.ReadAllLines(nombreArchivo);

        foreach (var linea in lineas)
        {
            var lineaDato = linea.Split(',');
            cadeterias.Add(new Cadeteria(lineaDato[0], lineaDato[1]));

        }

        return cadeterias;
    }
}
public class AccesoJSON : AccesoADatos
{
    public override List<Cadete>? ObtenerDatosCadetes(string nombreArchivo)
    {

        var cadetes = new List<Cadete>();

        using (StreamReader sr = File.OpenText(nombreArchivo))
        {
            string contenidoJson = sr.ReadToEnd();
            cadetes = JsonSerializer.Deserialize<List<Cadete>>(contenidoJson);
        }

        return cadetes;
    }
    public override List<Cadeteria>? ObtenerDatosCadeterias(string nombreArchivo)
    {
        var cadeterias = new List<Cadeteria>();

        using (StreamReader sr = File.OpenText(nombreArchivo))
        {
            string contenidoJson = sr.ReadToEnd();
            cadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(contenidoJson);
        }

        return cadeterias;
    }
}