namespace espacioCadeteria{

public class Program
{
    public static void Main()
    {
        //CREAR LISTA CON DATOS DE CADETERIAS
        AccesoADatos datosCadeterias = new AccesoADatos("cadeterias.csv");
        List<Cadeteria> cadeterias = datosCadeterias.cargarCadeterias();
        
        //CREAR LISTA CON DATOS DE CADETES
        AccesoADatos datosCadetes = new AccesoADatos("cadetes.csv");
        List<Cadete> cadetes = datosCadetes.cargarCadetes();

        //CREAR LISTA CON DATOS DE CLIENTES
        AccesoADatos datosClientes = new AccesoADatos("clientes.csv");
        List<Cliente> clientes = datosClientes.cargarClientes();

        List<Pedido> pedidos = new List<Pedido>();
        
        Pedido pedido1 = new Pedido("obs", Estado.aceptado, 1050, clientes[0]);
        Pedido pedido2 = new Pedido("obs", Estado.aceptado, 1050, clientes[0]);
        Pedido pedido3 = new Pedido("obs", Estado.aceptado, 1050, clientes[0]);
        Pedido pedido4 = new Pedido("obs", Estado.aceptado, 1050, clientes[0]);
        Pedido pedido5 = new Pedido("obs", Estado.aceptado, 1050, clientes[1]);

        pedidos.Add(pedido1);
        pedidos.Add(pedido2);
        pedidos.Add(pedido3);
        pedidos.Add(pedido4);

        Cadete cadete1 = new Cadete(cadetes[0].Nombre, cadetes[0].Direccion, cadetes[0].Telefono, pedidos);
        Cadete cadete2 = new Cadete(cadetes[1].Nombre, cadetes[1].Direccion, cadetes[1].Telefono, [pedido2, pedido4]);
        cadete1.cargarPedido(pedido5);
        //cadete1.eliminarPedido(5);

        /*
        Console.WriteLine(cadete1.Nombre);
        Console.WriteLine(cadete1.Direccion);
        Console.WriteLine(cadete1.Telefono);
        Console.WriteLine(cadete1.ListadoPedidos[0].Numero);*/

        Cadeteria cadeteria1 = new Cadeteria(cadeterias[0], [cadete1,cadete2]);
        cadeteria1.GenerarInforme();

        /*
        foreach (var pedido in pedidos)
        {
            Console.WriteLine(pedido.Numero);
            Console.WriteLine(pedido.Observacion);
            Console.WriteLine(pedido.Estado);
            Console.WriteLine(pedido.Monto);
            Console.WriteLine(pedido.verDatosCliente());
            Console.WriteLine(pedido.verDireccionCliente());   
        }*/
    }
}
}

/* El sistema posee una interfaz de consola para gestión de pedidos para realizar las siguientes operaciones:
a) dar de alta pedidos
b) asignarlos a cadetes
c) cambiarlos de estado
d) reasignar el pedido a otro cadete.*/