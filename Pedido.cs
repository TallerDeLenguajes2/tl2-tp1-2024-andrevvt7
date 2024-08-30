namespace espacioCadeteria{

public enum Estado
    {
        aceptado,
        cancelado,
        recibido
    }

public class Pedido{
    public static int num = 0;
    private int numero;
    private string? observacion;
    private Estado estado;
    private float monto;
    private Cliente? cliente;
        public int Numero { get => numero; set => numero = value; }
        public string? Observacion { get => observacion; set => observacion = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public float Monto { get => monto; set => monto = value; }
        public Cliente? Cliente { get => cliente; set => cliente = value; }

        public Pedido(string observacion, Estado estado, float monto, Cliente cliente)
        {
            num += 1;
            this.numero = num;
            this.observacion = observacion; 
            this.estado = estado;
            this.monto = monto;
            this.cliente = cliente;
        }
        public Pedido(string observacion, Estado estado, float monto, string nombre, string direccion, string telefono, string datosDireccion)
        {
            num += 1;
            this.numero = num;
            this.observacion = observacion; 
            this.estado = estado;
            this.monto = monto;
            this.cliente = new Cliente(nombre, direccion, telefono, datosDireccion);
        }
    public string verDireccionCliente(){
        return "Dirección: " + cliente.Direccion + " - " + cliente.DatosReferenciaDireccion;
    }
    public string verDatosCliente(){
        return "Nombre del cliente: " + cliente.Nombre + " - Teléfono: " + cliente.Telefono;
    }
}
}