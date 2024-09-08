namespace espacioDeLaCadeteria;

public class Cadete{
    private int id;
    private string? nombre;
    private string? direccion;
    private string? telefono;

    public int Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? Telefono { get => telefono; set => telefono = value; }

    public Cadete(){}
    public Cadete(int id, string nombre, string direccion, string telefono){
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }
}