namespace espacioDeLaCadeteria;

//EL CADETE TIENE O NO UNA LISTA DE PEDIDOS
//AGREGACIÓN PEDIDO-CADETE: 
//EL PEDIDO SE CREA FUERA DEL CADETE Y SE LO PASA POR PARÁMETRO AL CONTRUCTOR (O NO)
public class Cadete{
    private int pagoPorPedido = 500;
    private int id;
    private string? nombre;
    private string? direccion;
    private string? telefono;
    private List<Pedido> listadoPedidos;

    public int PagoPorPedido { get => pagoPorPedido; set => pagoPorPedido = value; }
    public int Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadete(){}
    //CADETES SIN PEDIDOS
    public Cadete(int id, string nombre, string direccion, string telefono){
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListadoPedidos = new List<Pedido>(); //LISTA DE PEDIDOS VACÍA
    }

    //CADETES CON PEDIDOS
    public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> listadoPedidos){
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListadoPedidos = listadoPedidos; //LISTA DE PEDIDOS VACÍA
    }

    public int JornalACobrar(){
        int jornal = 0;
        foreach (var pedido in listadoPedidos)
        {
            if (pedido.Estado == Estado.entregado)
            {
                jornal += PagoPorPedido;
            }
        }
        return jornal;
    }
}