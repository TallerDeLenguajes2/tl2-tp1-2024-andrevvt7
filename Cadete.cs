namespace espacioCadeteria{
public class Cadete{
    public static int identificador = 0;
    private int id;
    private string? nombre;
    private string? direccion;
    private string? telefono;
    private List<Pedido>? listadoPedidos;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public List<Pedido>? ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Cadete(){}
//Si ya existe una lista de pedidos
        public Cadete(string nombre, string direccion, string telefono, List<Pedido> pedidos)
        {
            identificador += 1;
            this.id = identificador;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.ListadoPedidos = pedidos;
        }
//Si no existe una lista de pedidos
        public Cadete(string nombre, string telefono, string direccion)
        {
            identificador += 1;
            this.id = identificador;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            ListadoPedidos = new List<Pedido>();
        }
        public float jornalACobrar(){
        float monto = 0;
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.Estado == Estado.recibido)
                {
                    monto += pedido.Monto;
                }
            }
            return monto;
        }

        public void cargarPedido(Pedido pedido)
        {
            if (!ListadoPedidos.Contains(pedido))
            {
                ListadoPedidos.Add(pedido);
            } else {
                Console.WriteLine("\nEl pedido ya estaba cargado");
            }
        }

        public void eliminarPedido(int numeroPedido)
        {
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.Numero == numeroPedido)
                {
                    ListadoPedidos.Remove(pedido);
                }
            }
            Console.WriteLine("\nError: El cadete no posee ese pedido");
        }

        public float montoTotal(){
            float montoTotal = 0;

            foreach (var pedido in ListadoPedidos)
            {
                montoTotal += pedido.Monto;
            } 
            return montoTotal;
        }

        public int cantidadEnvios(){
            int totalEnvios = 0;

            foreach (var pedido in ListadoPedidos)
            {
                totalEnvios += 1;
            } 
            return totalEnvios;
        }
}
}