namespace espacioCadeteria{

public enum Estado
    {
        Aceptado,
        Cancelado,
        Recibido
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

    public void verDireccionCliente(){

    }
    public void verDatosCliente(){

    }
}
}