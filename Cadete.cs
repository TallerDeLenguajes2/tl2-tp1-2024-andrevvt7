namespace espacioCadeteria{
public class Cadete{
    private int id;
    private string? nombre;
    private string? direccion;
    private string? telefono;
    private List<Pedido>? listadoPedidos;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }

        public Cadete(){}
//Si ya existe una lista de pedidos
        public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> pedidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listadoPedidos = pedidos;
        }
//Si no existe una lista de pedidos
        public Cadete(int id, string nombre, string telefono, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            listadoPedidos = new List<Pedido>();
        }
        public float jornalACobrar(){
        float monto = 0;
            foreach (var pedido in listadoPedidos)
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
            if (!listadoPedidos.Contains(pedido))
            {
                listadoPedidos.Add(pedido);
            } else {
                Console.WriteLine("\nEl pedido ya estaba cargado");
            }
            return;
        }

        public void eliminarPedido(int numeroPedido)
        {
            foreach (var pedido in listadoPedidos)
            {
                if (pedido.Num == numeroPedido)
                {
                    listadoPedidos.Remove(pedido);
                    return;
                }
            }
            Console.WriteLine("\nError: El cadete no posee ese pedido");
        }

        public float montoTotal(){
            float montoTotal = 0;

            foreach (var pedido in listadoPedidos)
            {
                montoTotal += pedido.Monto;
            } 
            return montoTotal;
        }

        public int cantidadEnvios(){
            int totalEnvios = 0;

            foreach (var pedido in listadoPedidos)
            {
                totalEnvios += 1;
            } 
            return totalEnvios;
        }
}
}