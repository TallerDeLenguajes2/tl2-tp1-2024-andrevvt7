namespace espacioCadeteria{

public enum Estado
    {
        aceptado,
        cancelado,
        recibido
    }

public class Pedido{
    private int num;
    private string? observacion;
    private Cliente? cliente;
    private Estado estado;

        public int Num { get => num; set => num = value; }
        public string? Observacion { get => observacion; set => observacion = value; }
        public Cliente? Cliente { get => cliente; set => cliente = value; }
        public Estado Estado { get => estado; set => estado = value; }

    public Pedido(int num, string observacion, Estado estado, Cliente cliente)
        {
            this.num = num;
            this.observacion = observacion; 
            this.estado = estado;
            this.cliente = new Cliente();
        }

    public string verDireccionCliente(){
        return "Dirección: " + cliente.Direccion + " - " + cliente.DatosReferenciaDireccion;
    }
    public string verDatosCliente(){
        return "Nombre: " + cliente.Nombre + " - Teléfono: " + cliente.Telefono;
    }
}
}