namespace espacioDeLaCadeteria;

//CADETE ES PARTE DE UNA CADETERIA
//PEDIDO ES PARTE DE UNA CADETERIA
//COMPOSICIÓN CADETE-CADETERIA: EL CADETE SE CREA DENTRO DE LA CADETERIA
//COMPOSICIÓN PEDIDO-CADETERIA: EL PEDIDO SE CREA DENTRO DE LA CADETERIA

public class Cadeteria{
    string? nombre;
    string? telefono;
    List<Cadete> listadoCadetes;
    List<Pedido> listadoPedidos = new List<Pedido>();
    int pagoPorPedido = 500;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria(string nombre, string telefono){
        Nombre = nombre;
        Telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }

    //CREAR Y AGREGAR CADETE A LA LISTA DE CADETES
    public void AgregarCadete(int id, string nombre, string direccion, string telefono){
        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
        listadoCadetes.Add(cadete);
    }
  
    //CREAR PEDIDO (por defecto noAsignado -> cadete = null)
    public void CrearPedido(string observacion, string nombreC, string direccionC, string telefonoC, string referenciasC){
        Pedido pedido = new Pedido(observacion, nombreC, direccionC, telefonoC, referenciasC);
        listadoPedidos.Add(pedido); 
    }
    public int JornalACobrar(int idCadete){
        int jornal = 0;

        if (listadoCadetes.FirstOrDefault(c => c.Id == idCadete) != null)
        {
            foreach (var pedido in listadoPedidos)
            {
                if (pedido.Cadete.Id == idCadete)
                {
                    jornal += pagoPorPedido;
                }
            }
        } else {
            Console.WriteLine("El cadete no existe.");
        }

        return jornal;
    }

    public bool ExistenciaPedido(int numPedido){
        if (listadoPedidos.FirstOrDefault(p => p.Numero == numPedido) != null)
        {
            return true;
        } else {
            return false;
        }
    }
    
    public Pedido ObtenerPedidoPorNumero(int numPedido){
        return listadoPedidos.FirstOrDefault(p => p.Numero == numPedido);
    }
    
    public Cadete ObtenerCadetePorId(int idCadete){
        return ListadoCadetes.FirstOrDefault(c => c.Id == idCadete); //retorna un cadete o un null
    }
    
    public Cadete ObtenerCadeteConElPedido(int numPedido){
        Cadete cadeteConPedido = null;
        Pedido pedidoDelCadete = ObtenerPedidoPorNumero(numPedido); //si hay pedido con ese número

        if (pedidoDelCadete != null && pedidoDelCadete.Estado == Estado.asignado)
        {
            cadeteConPedido = pedidoDelCadete.Cadete;
        }

        return cadeteConPedido;
    }

    public void AsignarCadeteAPedido(int idCadete, int numPedido){
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
        } else {
            pedidoAAsignar.Cadete = cadeteAAsignar;
            pedidoAAsignar.Estado = Estado.asignado;
        }
    }

    public void CambiarEstadoDePedido(int numPedido, string estado){

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
        } else {
            Console.WriteLine("El pedido ya fue entregado, cancelado o aún no se asignó a un cadete. No se puede cambiar su estado");
        }
    }

    public void ReasignarPedidoAOtroCadete(int numPedido, int idCadete){

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

    public int TotalEnviosEnElDia(){ //OK (en teoría)
        
        int totalEnvios = (from pedido in ListadoPedidos where pedido.Estado == Estado.entregado select pedido).Count();

        return totalEnvios;
    }

    public int MontoGanadoEnElDia(){ //OK (en teoría)

        int monto = TotalEnviosEnElDia()*pagoPorPedido;

        return monto;
    }

    public List<List<int>> EnviosPorCadete(){
        List<List<int>> enviosPorCadete = new List<List<int>>();
        List<int> envioDefault;

        foreach (var cadete in listadoCadetes)
        {
            envioDefault = [cadete.Id, 0];
            enviosPorCadete.Add(envioDefault);
        }

        foreach (var pedido in listadoPedidos)
        {
            if (pedido.Estado == Estado.entregado)
            {
                foreach (var envio in enviosPorCadete)
                {        
                    if (envio[0] == pedido.Cadete.Id)
                    {
                        envio[1] ++;
                    }
                }
            }
        }

        return enviosPorCadete;
    }

    public List<List<int>> PromedioEnviosPorCadete(){
        List<List<int>> promedioEnviosPorCadete = new List<List<int>>();
        
        if (TotalEnviosEnElDia() != 0)
        {
            foreach (var envio in EnviosPorCadete())
            {
                promedioEnviosPorCadete.Add([envio[0], envio[1]*100/TotalEnviosEnElDia()]);
            }    
        } else {
            foreach (var envio in EnviosPorCadete())
            {
                promedioEnviosPorCadete.Add([envio[0], 0]);
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

    // MÉTODOS AGREGADOS

/*    public Pedido ObtenerPedidoSinAsignarPorNum(int numPedido){
        return listadoPedidos.FirstOrDefault(p => p.Numero == numPedido); //retorna un pediod o un null
    }

    public Pedido ObtenerPedidoYaAsignado(int numPedido){
        Pedido pedidoAsignado = null;

        foreach (var pedido in listadoPedidos)
        {
            if (pedido.Estado == Estado.entregado)
            {
                pedidoAsignado = pedido;
            }
            if (pedido != null)
            {
                break;
            }
        }

        return pedidoAsignado;
    }
*/
    

    /*public void AsignarPedidoACadete(Pedido pedido, int idCadete){

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
        listadoPedidos.Remove(pedido);
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
        listadoPedidos.Remove(pedidoAAsignar);
        Console.WriteLine("Pedido asignado al cadete con éxito.");

    }
    */