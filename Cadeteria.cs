namespace espacioCadeteria{
public class Cadeteria{
    private string? nombre;
    private string? telefono;
    private List<Cadete>? listadoCadetes;

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public List<Cadete>? ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
}
}