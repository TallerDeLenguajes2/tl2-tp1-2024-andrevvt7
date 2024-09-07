namespace espacioDeLaCadeteria;

//CADETE ES PARTE DE UNA CADETERIA
//PEDIDO ES PARTE DE UNA CADETERIA
//COMPOSICIÓN CADETE-CADETERIA: EL CADETE SE CREA DENTRO DE LA CADETERIA
//COMPOSICIÓN PEDIDO-CADETERIA: EL PEDIDO SE CREA DENTRO DE LA CADETERIA

public class Cadeteria
{
    string? nombre;
    string? telefono;
    List<Cadete> listadoCadetes;
    List<Pedido> listadoPedidos = new List<Pedido>();
    int pagoPorPedido = 500;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }

    //CREAR Y AGREGAR CADETE A LA LISTA DE CADETES
    public void AgregarCadete(int id, string nombre, string direccion, string telefono)
    {
        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
        listadoCadetes.Add(cadete);
    }

    //CREAR PEDIDO (por defecto noAsignado -> cadete = null)
    public void CrearPedido(string observacion, string nombreC, string direccionC, string telefonoC, string referenciasC)
    {
        Pedido pedido = new Pedido(observacion, nombreC, direccionC, telefonoC, referenciasC);
        listadoPedidos.Add(pedido);
    }
    public int JornalACobrar(int idCadete)
    {
        int jornal = 0;

        if (ExistenciaCadete(idCadete))
        {
            jornal = (from pedido in listadoPedidos where pedido.Cadete != null && pedido.Estado == Estado.entregado && pedido.Cadete.Id == idCadete select pedido).Count() * pagoPorPedido;
        }
        else
        {
            Console.WriteLine("El cadete no existe.");
        }

        return jornal;
    }

    public bool ExistenciaPedido(int numPedido)
    {
        return listadoPedidos.Any(p => p.Numero == numPedido);
    }
    public bool ExistenciaCadete(int idCadete)
    {
        return listadoCadetes.Any(c => c.Id == idCadete);
    }

    public Pedido ObtenerPedidoPorNumero(int numPedido)
    {
        return listadoPedidos.FirstOrDefault(p => p.Numero == numPedido);
    }

    public Cadete ObtenerCadetePorId(int idCadete)
    {
        return ListadoCadetes.FirstOrDefault(c => c.Id == idCadete); //retorna un cadete o un null
    }

    public Cadete ObtenerCadeteConElPedido(int numPedido)
    {
        Cadete cadeteConPedido = null;
        Pedido pedidoDelCadete = ObtenerPedidoPorNumero(numPedido); //si hay pedido con ese número

        if (pedidoDelCadete != null && pedidoDelCadete.Estado == Estado.asignado)
        {
            if (pedidoDelCadete.Cadete != null)
            {
                cadeteConPedido = pedidoDelCadete.Cadete;
            }
        }

        return cadeteConPedido;
    }

    public void AsignarCadeteAPedido(int idCadete, int numPedido)
    {
        Cadete cadeteAAsignar = ObtenerCadetePorId(idCadete);
        Pedido pedidoAAsignar = ObtenerPedidoPorNumero(numPedido);

        if (cadeteAAsignar == null) //si no existe el cadete o el pedido ingresado o ambos
        {
            Console.WriteLine("El cadete no existe.");
            return;
        }

        if (pedidoAAsignar == null)
        {
            Console.WriteLine("El pedido no existe.");
            return;
        }

        //CASOS
        //QUE EL PEDIDO YA TENGA ASIGNADO ALGÚN CADETE
        //NO HACER NADA

        //QUE NO TENGA ASIGNADO NINGÚN CADETE
        //HACER LA ASIGNACIÓN

        if (pedidoAAsignar.Estado != Estado.noAsignado)
        {
            Console.WriteLine("El pedido ya fue asignado.");
            return;
        }
        else
        {
            pedidoAAsignar.Cadete = cadeteAAsignar;
            pedidoAAsignar.Estado = Estado.asignado;
        }
    }

    public void CambiarEstadoDePedido(int numPedido, string estado)
    {

        Pedido pedido = ObtenerPedidoPorNumero(numPedido); //si el pedido aún no fue entregado o cancelado

        if (pedido == null)
        {
            Console.WriteLine("El pedido no existe.");
            return;
        }

        if (pedido.Estado == Estado.asignado)
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
        }
        else
        {
            Console.WriteLine("El pedido ya fue entregado, cancelado o aún no se asignó a un cadete. No se puede cambiar su estado");
        }
    }

    public void ReasignarPedidoAOtroCadete(int numPedido, int idCadete)
    {

        //OBTENER EL PEDIDO QUE SE QUIERE REASIGNAR
        Pedido pedidoAReasignar = ObtenerPedidoPorNumero(numPedido);
        //BUSCAR EL CADETE
        Cadete cadeteParaElPedido = ObtenerCadetePorId(idCadete);
        // BUSCAR EL CADETE QUE TIENE EL PEDIDO
        Cadete cadeteConElPedido = ObtenerCadeteConElPedido(numPedido);

        if (pedidoAReasignar == null)
        {
            Console.WriteLine("El pedido no existe.");
            return;
        }

        if (cadeteParaElPedido == null)
        {
            Console.WriteLine("El cadete no forma parte de la lista de cadetes.");
            return;
        }

        if (pedidoAReasignar.Estado == Estado.noAsignado)
        {
            Console.WriteLine("El pedido aún no fue asignado a ningún cadete.");
            return;
        }

        if (pedidoAReasignar.Estado != Estado.asignado)
        {
            Console.WriteLine("El pedido ya fue cancelado o entregado. No puede reasignarse");
        }
        else
        {
            pedidoAReasignar.Cadete = cadeteParaElPedido;
            Console.WriteLine("Pedido asignado al cadete con éxito.");
        }
    }

    // MÉTODO PARA EL INFORME
    /*Mostrar un informe de pedidos al finalizar la jornada que incluya:
    - monto ganado
    - cantidad de envíos de cada cadete
    - total de envíos
    - cantidad de envíos promedio por cadete.*/

    public int TotalEnviosEnElDia()
    {

        int totalEnvios = (from pedido in ListadoPedidos where pedido.Estado == Estado.entregado select pedido).Count();

        return totalEnvios;
    }

    public int MontoGanadoEnElDia()
    {
        //int monto = (from cadete in ListadoCadetes select JornalACobrar(cadete.Id)).Sum();
        int monto = TotalEnviosEnElDia() * pagoPorPedido;

        return monto;
    }

    public List<List<int>> EnviosPorCadete()
    {
        List<List<int>> enviosPorCadete = new List<List<int>>();
        List<int> envio;

        foreach (var cadete in listadoCadetes)
        {
            envio = [cadete.Id, ((from pedido in ListadoPedidos where pedido.Cadete != null && pedido.Cadete.Id == cadete.Id && pedido.Estado == Estado.entregado select pedido).Count())];
            enviosPorCadete.Add(envio);
        }

        return enviosPorCadete;
    }

    public List<List<int>> PromedioEnviosPorCadete()
    {
        List<List<int>> promedioEnviosPorCadete = new List<List<int>>();
        List<int> envioPromedio;

        foreach (var cadete in listadoCadetes)
        {
            envioPromedio = [cadete.Id, TotalEnviosEnElDia() == 0 ? 0 : ((from pedido in ListadoPedidos where pedido.Cadete != null && pedido.Cadete.Id == cadete.Id && pedido.Estado == Estado.entregado select pedido).Count() * 100 / TotalEnviosEnElDia())];
            promedioEnviosPorCadete.Add(envioPromedio);
        }

        return promedioEnviosPorCadete;
    }
}