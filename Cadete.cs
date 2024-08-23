using System.Text;
namespace espacioCadeteria{
public class Cadete{
    private int id;
    private string? nombre;
    private string? direccion;
    private string? telefono;
    private List<Pedido>? listadoPedidos;

    public float jornalACobrar(){
        return 0;
    }
}
}