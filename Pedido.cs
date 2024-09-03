namespace espacioDeLaCadeteria;


//AGREGACIÓN PEDIDO-CADETE
//CLIENTE ES PARTE DE UN PEDIDO
//COMPOSICIÓN PEDIDO-CLIENTE: EL CLIENTE SE CREA DENTRO DEL PEDIDO
public enum Estado{
    asignado,
    noAsignado,
    entregado,
    cancelado
}

public class Pedido{
    private static int num = 0; //para enumerar automáticamente los pedidos
    private int numero;
    private string? observacion;
    private Cliente? cliente;
    private Estado estado = Estado.noAsignado;
    private Cadete? cadete = null;

    public int Numero { get => numero; set => numero = value; }
    public string? Observacion { get => observacion; set => observacion = value; }
    public Cliente? Cliente { get => cliente; set => cliente = value; }
    internal Estado Estado { get => estado; set => estado = value; }
    public Cadete? Cadete { get => cadete; set => cadete = value; }

    public Pedido(){}
    //SOLO SE PUEDE CREAR UN PEDIDO SI SE SABEN TODOS LOS DATOS DEL CLIENTE
    public Pedido(string observacion, string nombreC, string direccionC, string telefonoC, string referenciasC){
        num++;
        Numero = num;
        Observacion = observacion;
        Cliente = new Cliente(nombreC, direccionC, telefonoC, referenciasC);
    }

    public string VerDireccionCliente(){
        return "Dirección del cliente: " + Cliente.Direccion + " " + Cliente.DatosReferenciaDireccion;
    }
    
    public string VerDatosCliente(){
        return $"Datos del cliente -> Nombre: {Cliente.Nombre} | Teléfono: {Cliente.Telefono}";
    }
}