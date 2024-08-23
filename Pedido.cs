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

    public void verDireccionCliente(){

    }
    public void verDatosCliente(){

    }
}
}