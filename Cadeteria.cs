namespace espacioDeLaCadeteria;

//CADETE ES PARTE DE UNA CADETERIA
//COMPOSICIÓN CADETE-CADETERIA: EL CADETE SE CREA DENTRO DE LA CADETERIA

public class Cadeteria{
    string? nombre;
    string? telefono;
    List<Cadete> listadoCadetes;
    List<Pedido> pedidosSinAsignar = new List<Pedido>();

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> PedidosSinAsignar { get => pedidosSinAsignar; set => pedidosSinAsignar = value; }

    public Cadeteria(string nombre, string telefono){
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }


    // MÉTODOS AGREGADOS

    //CREAR Y AGREGAR CADETE A LA LISTA DE CADETES
    public void AgregarCadete(int id, string nombre, string direccion, string telefono){
        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
        listadoCadetes.Add(cadete);
    }
  

    // MÉTODOS SOLICITADOS PARA LA GESTIÓN DE PEDIDOS

    //CREAR PEDIDO Y AGREGARLO A LA LISTA DE PEDIDOS NO ASIGNADOS AÚN
    public void CrearPedido(string observacion, string nombreC, string direccionC, string telefonoC, string referenciasC){
        Pedido pedido = new Pedido(observacion, nombreC, direccionC, telefonoC, referenciasC);
        pedidosSinAsignar.Add(pedido); 
    }

    public Cadete ObtenerCadetePorId(int idCadete){
        return ListadoCadetes.FirstOrDefault(c => c.Id == idCadete); //retorna un cadete o un null
    }

    public Pedido ObtenerPedidoSinAsignarPorNum(int numPedido){
        return pedidosSinAsignar.FirstOrDefault(p => p.Numero == numPedido); //retorna un pediod o un null
    }

    public Pedido ObtenerPedidoYaAsignado(int numPedido){
        Pedido pedido = null;

        foreach (var cadete in listadoCadetes)
        {
            pedido = cadete.ListadoPedidos.FirstOrDefault(p => p.Numero == numPedido);
            if (pedido != null)
            {
                break;
            }
        }

        return pedido;
    }

    public bool ExistenciaPedido(int numPedido){
        if (ObtenerPedidoSinAsignarPorNum(numPedido) != null || ObtenerPedidoYaAsignado(numPedido) != null)
        {
            return true;
        } else {
            return false;
        }
    }

    public Cadete ObtenerCadeteConElPedido(int numPedido){
        Cadete cadeteConPedido = null;
        Pedido pedido;

        foreach (var cadete in listadoCadetes)
        {
            pedido = cadete.ListadoPedidos.FirstOrDefault(p => p.Numero == numPedido);
            if (pedido != null)
            {
                cadeteConPedido = cadete;
                break;
            }
        }

        if (cadeteConPedido == null)
        {
            Console.WriteLine("No hay cadete con ese pedido asignado");
        }

        return cadeteConPedido;
    }

    public void AsignarPedidoACadete(Pedido pedido, int idCadete){

        //AVERIGUAR SI EL PEDIDO EXISTE
        if (!ExistenciaPedido(pedido.Numero))
        {
            Console.WriteLine("El pedido no existe.");
            return;
        }

        //AVERIGUAR SI EL CADETE EXISTE
        Cadete cadeteParaElPedido = ObtenerCadetePorId(idCadete); // CONSEGUIR EL CADETE CON EL ID INGRESADO
        if (cadeteParaElPedido == null)
        {
            Console.WriteLine("El cadete no forma parte de la lista de cadetes.");
            return;
        }

        //AVERIGUAR SI EL PEDIDO ESTÁ EN LA LISTA DE PEDIDOS SIN ASIGNAR
        Pedido pedidoAAsignar = ObtenerPedidoSinAsignarPorNum(pedido.Numero); //para saber si el pedido está asignado o no

        if (pedidoAAsignar == null)
        {
            Console.WriteLine("El pedido ya está asignado a algún cadete.");
            return;
        }

        cadeteParaElPedido.ListadoPedidos.Add(pedido);
        pedidosSinAsignar.Remove(pedido);
        Console.WriteLine("Pedido asignado al cadete con éxito.");
    }

    // ASIGNACION CON PROBLEMAS
    public void AsignarPedidoACadete(int numPedido, int idCadete){
        //AVERIGUAR SI EL PEDIDO EXISTE
        if (!ExistenciaPedido(numPedido))
        {
            Console.WriteLine("El pedido no existe.");
            return;
        }

        //AVERIGUAR SI EL CADETE EXISTE
        Cadete cadeteParaElPedido = ObtenerCadetePorId(idCadete); // CONSEGUIR EL CADETE CON EL ID INGRESADO
        if (cadeteParaElPedido == null)
        {
            Console.WriteLine("El cadete no forma parte de la lista de cadetes.");
            return;
        }

        //AVERIGUAR SI EL PEDIDO ESTÁ EN LA LISTA DE PEDIDOS SIN ASIGNAR
        Pedido pedidoAAsignar = ObtenerPedidoSinAsignarPorNum(numPedido); //para saber si el pedido está asignado o no

        if (pedidoAAsignar == null)
        {
            Console.WriteLine("El pedido ya está asignado a algún cadete.");
            return;
        }

        cadeteParaElPedido.ListadoPedidos.Add(pedidoAAsignar);
        pedidosSinAsignar.Remove(pedidoAAsignar);
        Console.WriteLine("Pedido asignado al cadete con éxito.");

    }

    public void CambiarEstadoDePedido(int numPedido, string estado){
        //AVERIGUAR SI EL PEDIDO EXISTE
        if (!ExistenciaPedido(numPedido))
        {
            Console.WriteLine("El pedido no existe.");
            return;
        }

        Pedido pedido = ObtenerPedidoYaAsignado(numPedido);

        if (pedido != null)
        {
            switch (estado)
            {
                case "entregado":
                    pedido.Estado = Estado.entregado;
                    break;
                case "cancelado":
                    pedido.Estado = Estado.cancelado;
                    break;
                default:
                    break;
            }
        } else {
            Console.WriteLine("El pedido aún no fue asignado a ningún cadete. No se puede cambiar su estado");
        }
    }

    public void ReasignarPedidoAOtroCadete(int numPedido, int idCadete){
        //AVERIGUAR SI EL PEDIDO EXISTE
        if (!ExistenciaPedido(numPedido))
        {
            Console.WriteLine("El pedido no existe.");
            return;
        }
        //OBTENER EL PEDIDO QUE SE QUIERE REASIGNAR
        Pedido pedidoAReasignar = ObtenerPedidoYaAsignado(numPedido);
        //BUSCAR EL CADETE
        Cadete cadeteParaElPedido = ObtenerCadetePorId(idCadete);
        // BUSCAR EL CADETE QUE TIENE EL PEDIDO
        Cadete cadeteConElPedido = ObtenerCadeteConElPedido(numPedido);

        if (cadeteParaElPedido == null)
        {
            Console.WriteLine("El cadete no forma parte de la lista de cadetes.");
            return;
        }
        if (pedidoAReasignar == null)
        {
            Console.WriteLine("El pedido aún no fue asignado a ningún cadete.");
            return;
        }

        if (cadeteParaElPedido.ListadoPedidos.Contains(pedidoAReasignar))
        {
            Console.WriteLine("El pedido ya está asignado a este cadete.");
        }
        else
        {
            cadeteParaElPedido.ListadoPedidos.Add(pedidoAReasignar);
            cadeteConElPedido.ListadoPedidos.Remove(pedidoAReasignar);
            Console.WriteLine("Pedido asignado al cadete con éxito.");
        }
    }

    // MÉTODO PARA EL INFORME
    /*Mostrar un informe de pedidos al finalizar la jornada que incluya:
    - monto ganado
    - cantidad de envíos de cada cadete
    - total de envíos
    - cantidad de envíos promedio por cadete.*/

    public int TotalEnviosEnElDia(){ //está OK
        
        int totalEnvios = (from pedidos in EnviosPorCadete() select pedidos[1]).Sum();

        return totalEnvios;
    }

    public int MontoGanadoEnElDia(){

        int monto = (from cadete in listadoCadetes select cadete.JornalACobrar()).Sum();

        return monto;
    }

    public List<List<int>> EnviosPorCadete(){
        List<List<int>> enviosPorCadete = new List<List<int>>();

        foreach (var cadete in listadoCadetes)
        {
            enviosPorCadete.Add([cadete.Id, (from pedido in cadete.ListadoPedidos where pedido.Estado == Estado.entregado select pedido).Count()]);
        }

        return enviosPorCadete;
    }

    public List<List<int>> PromedioEnviosPorCadete(){
        
        List<List<int>> promedioEnviosPorCadete = new List<List<int>>();

        if (TotalEnviosEnElDia() != 0)
        {
            foreach (var cadete in listadoCadetes)
            {
                promedioEnviosPorCadete.Add([cadete.Id, (from pedido in cadete.ListadoPedidos where pedido.Estado == Estado.entregado select pedido).Count()*100/TotalEnviosEnElDia()]);
            }    
        } else {
            foreach (var cadete in listadoCadetes)
            {
                promedioEnviosPorCadete.Add([cadete.Id, 0]);
            }
        }
        
        return promedioEnviosPorCadete;
    }

    public void Informe(){
        Console.WriteLine($"Monto ganado en el día: ${MontoGanadoEnElDia()}");
        Console.WriteLine($"Total de envíos entregados en el día: {TotalEnviosEnElDia()}");
        Console.WriteLine("Total de envíos entregados en el día por cada cadete: ");
        foreach (var enviosPorCadete in EnviosPorCadete())
        {
            Console.WriteLine($"Cadete {enviosPorCadete[0]} | Envíos: {enviosPorCadete[1]}");
        }
        Console.WriteLine("Envíos promedio en el día por cada cadete: ");
        foreach (var promedioEnviosPorCadete in PromedioEnviosPorCadete())
        {
            Console.WriteLine($"Cadete {promedioEnviosPorCadete[0]} | Promedio de envíos: {promedioEnviosPorCadete[1]}%");
        }
    }
}