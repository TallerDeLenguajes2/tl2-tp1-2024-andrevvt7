using espacioDeLaCadeteria;

public class Gestion{
    Cadeteria cadeteria;

    public Gestion(Cadeteria cadeteria){
        this.cadeteria = cadeteria;
    }

    public void ContinuarGestion(){
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    public void MostrarMenu(){
        Console.WriteLine("____________________________________________________");
        Console.WriteLine($"GESTIÓN DE CADETERÍA '{cadeteria.Nombre}'");
        Console.WriteLine($"(Tenga en cuenta que la cadetería tiene {cadeteria.ListadoCadetes.Count()} cadete/s)\n");
        Console.WriteLine("Elija una opción");
        Console.WriteLine("1. Generar pedido");
        Console.WriteLine("2. Asignar pedido a un cadete");
        Console.WriteLine("3. Cambiar estado de un pedido");
        Console.WriteLine("4. Reasignar pedido a otro cadete");
        Console.WriteLine("5. Mostrar informe del día");
        Console.WriteLine("6. Salir");
        Console.WriteLine("____________________________________________________");
    }
    public void GenerarPedido(){
        string obs, nombre, direccion, tel, refDireccion;
            Console.WriteLine("GENERAR PEDIDO NUEVO.");
            Console.WriteLine("INGRESE LOS SIGUIENTES DATOS:");
            Console.WriteLine("Observación del pedido: ");
            obs = Console.ReadLine();
            Console.WriteLine("Datos del cliente: ");
            Console.WriteLine("Nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Dirección: ");
            direccion = Console.ReadLine();
            Console.WriteLine("Teléfono: ");
            tel = Console.ReadLine();
            Console.WriteLine("Referencias de dirección: ");
            refDireccion = Console.ReadLine();

            if (obs != null && nombre != null && direccion != null && tel != null && refDireccion != null)
            {
                cadeteria.CrearPedido(obs,nombre,direccion,tel,refDireccion);
            } else {
                Console.WriteLine("Debe ingresar todos los datos que se piden");
            }

            ContinuarGestion();
    }

    public void AsignarPedido(){
        int numPedido, idCadete;
            Console.WriteLine("ASIGNAR PEDIDO A UN CADETE");
            Console.WriteLine("INGRESE LOS SIGUIENTES DATOS:");
            Console.WriteLine("Número de pedido: ");
            numPedido = int.Parse(Console.ReadLine());
            Console.WriteLine("Id de cadete: ");
            idCadete = int.Parse(Console.ReadLine());

            if (numPedido != null && idCadete != null)
            {
                cadeteria.AsignarPedidoACadete(numPedido,idCadete);
            } else {
                Console.WriteLine("Debe ingresar todos los datos que se piden");
            }

            ContinuarGestion();
    }

    public void CambiarEstado(){
        int numeroPedido;
            string estado;
            Console.WriteLine("CAMBIAR ESTADO DE UN PEDIDO");
            Console.WriteLine("INGRESE LOS SIGUIENTES DATOS:");
            Console.WriteLine("Número de pedido: ");
            numeroPedido = int.Parse(Console.ReadLine());
            Console.WriteLine("Esado nuevo (entregado - cancelado): ");
            estado = Console.ReadLine();

            if (numeroPedido != null && estado != null)
            {
                cadeteria.CambiarEstadoDePedido(numeroPedido,estado);
            } else {
                Console.WriteLine("Debe ingresar todos los datos que se piden");
            }

            ContinuarGestion();
    }

    public void ReasignarPedido(){
        int numP, idC;
            Console.WriteLine("REASIGNAR PEDIDO A OTRO CADETE");
            Console.WriteLine("INGRESE LOS SIGUIENTES DATOS:");
            Console.WriteLine("Número de pedido: ");
            numP = int.Parse(Console.ReadLine());
            Console.WriteLine("Id de cadete: ");
            idC = int.Parse(Console.ReadLine());

            if (numP != null && idC != null)
            {
                cadeteria.ReasignarPedidoAOtroCadete(numP,idC);
            } else {
                Console.WriteLine("Debe ingresar todos los datos que se piden");
            }

            ContinuarGestion();
    }

    public void MostrarInforme(){
        Console.WriteLine("INFORME DEL DÍA");
        cadeteria.Informe();

        ContinuarGestion();
    }


}