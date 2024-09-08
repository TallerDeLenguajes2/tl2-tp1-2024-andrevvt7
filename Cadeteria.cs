namespace espacioDeLaCadeteria;

//CADETE ES PARTE DE UNA CADETERIA
//PEDIDO ES PARTE DE UNA CADETERIA
//COMPOSICIÓN CADETE-CADETERIA: EL CADETE SE CREA DENTRO DE LA CADETERIA
//COMPOSICIÓN PEDIDO-CADETERIA: EL PEDIDO SE CREA DENTRO DE LA CADETERIA

public class Cadeteria
{
    public int CantidadCadetes { get => listadoCadetes.Count; }
    string? nombre;
    string? telefono;
    List<Cadete> listadoCadetes;
    List<Pedido> listadoPedidos = new List<Pedido>();
    const int pagoPorPedido = 500;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Telefono { get => telefono; set => telefono = value; }

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }


//_________________________________________________________________________________________
//CREAR Y AGREGAR CADETE A LA LISTA DE CADETES
    public void AgregarCadete(int id, string nombre, string direccion, string telefono)
    {
        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
        listadoCadetes.Add(cadete);
    }

//CREAR PEDIDO Y AGREGARLO A LA LISTA DE PEDIDOS (por defecto noAsignado -> cadete = null)
    public void CrearPedido(string observacion, string nombreC, string direccionC, string telefonoC, string referenciasC)
    {
        Pedido pedido = new Pedido(observacion, nombreC, direccionC, telefonoC, referenciasC);
        listadoPedidos.Add(pedido);
    }

//_________________________________________________________________________________________

    public int JornalACobrar(int idCadete)
    {
        int jornal = 0;

        if (ExistenciaCadete(idCadete))
        {
            jornal = (from pedido in listadoPedidos where pedido.Cadete != null && pedido.Estado == Estado.entregado && pedido.Cadete.Id == idCadete select pedido).Count() * pagoPorPedido;
        }

        return jornal;
    }

//_________________________________________________________________________________________
//AUXILIARES
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
        return listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
    }

//_________________________________________________________________________________________
//PARA ASIGNACION, REASIGNACION Y CAMBIO DE ESTADO
    public void AsignarCadeteAPedido(int idCadete, int numPedido)
    {
        Cadete cadeteAAsignar;
        Pedido pedidoAAsignar;

        if (!ExistenciaCadete(idCadete) || !ExistenciaPedido(numPedido))
        {
            return;
        }

        cadeteAAsignar = ObtenerCadetePorId(idCadete);
        pedidoAAsignar = ObtenerPedidoPorNumero(numPedido);

        if (pedidoAAsignar.Estado != Estado.noAsignado)
        {
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
        Pedido pedido;

        if (!ExistenciaPedido(numPedido))
        {
            return;
        }

        pedido = ObtenerPedidoPorNumero(numPedido);

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
    }

    public void ReasignarPedidoAOtroCadete(int numPedido, int idCadete)
    {

        Cadete cadeteParaElPedido;
        Pedido pedidoAReasignar;

        if (!ExistenciaCadete(idCadete) || !ExistenciaPedido(numPedido))
        {
            return;
        }

        cadeteParaElPedido = ObtenerCadetePorId(idCadete);
        pedidoAReasignar = ObtenerPedidoPorNumero(numPedido);

        if (pedidoAReasignar.Estado == Estado.noAsignado)
        {
            return;
        }

        if (pedidoAReasignar.Estado != Estado.asignado)
        {
            return;
        }
        else
        {
            pedidoAReasignar.Cadete = cadeteParaElPedido;
        }
    }


//_________________________________________________________________________________________
//PARA EL INFORME DEL DÍA
    public int TotalEnviosEnElDia()
    {

        int totalEnvios = (from pedido in listadoPedidos where pedido.Estado == Estado.entregado select pedido).Count();

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
            envio = [cadete.Id, ((from pedido in listadoPedidos where pedido.Cadete != null && pedido.Cadete.Id == cadete.Id && pedido.Estado == Estado.entregado select pedido).Count())];
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
            envioPromedio = [cadete.Id, TotalEnviosEnElDia() == 0 ? 0 : ((from pedido in listadoPedidos where pedido.Cadete != null && pedido.Cadete.Id == cadete.Id && pedido.Estado == Estado.entregado select pedido).Count() * 100 / TotalEnviosEnElDia())];
            promedioEnviosPorCadete.Add(envioPromedio);
        }

        return promedioEnviosPorCadete;
    }
}