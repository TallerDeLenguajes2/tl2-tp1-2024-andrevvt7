using espacioDeLaCadeteria;

public class Gestion
{
    public static string? bufferString;
    public static Random random = new Random();
    public static int aleatorio;

    static AccesoADatos accesoADatosCSV = new AccesoCSV();
    static AccesoADatos accesoADatosJSON = new AccesoJSON();
    Cadeteria cadeteria;
    public Gestion(Cadeteria cadeteria)
    {
        this.cadeteria = cadeteria;
    }

    //__________________________________________________________________________________________
    //       LA CARGA DE INFO ALEATORIA Y UNA CANTIDAD ALEATORIA DE CADETES A LA CADETERÍA
    //__________________________________________________________________________________________

    public static int ElegirTipoDeAccesoADatos()
    {
        int tipoAcceso;
        Console.Clear();
        Console.WriteLine("Elija el tipo de acceso a datos que prefiere:");
        Console.WriteLine("1. Acceso a CSV");
        Console.WriteLine("2. Acceso a JSON");
        bufferString = Console.ReadLine();
        tipoAcceso = bufferString != "" && bufferString != null ? int.Parse(bufferString) : -1;

        return tipoAcceso;
    }

    public static Cadeteria CargarCadeteria(int tipoAcceso)
    {
        // Obtener todos las cadeterias y cadetes de los archivos
        List<Cadeteria>? cadeterias = ListaCadeteriasPorAcceso(tipoAcceso);
        List<Cadete>? cadetes = ListaCadetesPorAcceso(tipoAcceso);

        //cargar info (nombre y teléfono) a la cadeteria
        Cadeteria cadeteria = CargarInfoACadeteria(cadeterias);

        //cargar cantidad aleatoria de cadetes a la cadeteria
        CargarCadetesACadeteria(cadeteria, cadetes);

        return cadeteria;
    }

    public static List<Cadete> ListaCadetesPorAcceso(int tipoAcceso)
    {
        List<Cadete>? cadetes = null;

        switch (tipoAcceso)
        {
            case 1:
                cadetes = accesoADatosCSV.ObtenerDatosCadetes("cadetes.csv");
                break;
            case 2:
                cadetes = accesoADatosJSON.ObtenerDatosCadetes("cadetes.json");
                break;
            default:
            break;
        }

        return cadetes;
    }
    public static List<Cadeteria> ListaCadeteriasPorAcceso(int tipoAcceso)
    {
        List<Cadeteria>? cadeterias = null;

        switch (tipoAcceso)
        {
            case 1:
                cadeterias = accesoADatosCSV.ObtenerDatosCadeterias("cadeterias.csv");
                break;
            case 2:
                cadeterias = accesoADatosJSON.ObtenerDatosCadeterias("cadeterias.json");
                break;
            default:
            break;
        }

        return cadeterias;
    }


    public static Cadeteria CargarInfoACadeteria(List<Cadeteria> cadeterias)
    {
        aleatorio = random.Next(0, 10);
        Cadeteria cadeteria = new Cadeteria(cadeterias[aleatorio].Nombre, cadeterias[aleatorio].Telefono);

        return cadeteria;
    }

    public static void CargarCadetesACadeteria(Cadeteria cadeteria, List<Cadete> cadetes)
    {
        //cargar cantidad aleatoria de cadetes a la cadeteria
        aleatorio = random.Next(1, 11);

        for (int i = 0; i < aleatorio; i++)
        {
            cadeteria.AgregarCadete(cadetes[i].Id, cadetes[i].Nombre, cadetes[i].Direccion, cadetes[i].Telefono);
        }
    }


    //__________________________________________________________________________________________
    //                                 EL MENÚ Y SUS OPICONES
    //__________________________________________________________________________________________
    public void MostrarMenu()
    {
        Console.WriteLine("____________________________________________________");
        Console.WriteLine($"GESTIÓN DE CADETERÍA '{cadeteria.Nombre}'");
        Console.WriteLine($"(Tenga en cuenta que la cadetería tiene {cadeteria.CantidadCadetes} cadete/s)\n");
        Console.WriteLine("Elija una opción");
        Console.WriteLine("1. Generar pedido");
        Console.WriteLine("2. Asignar pedido a un cadete");
        Console.WriteLine("3. Cambiar estado de un pedido");
        Console.WriteLine("4. Reasignar pedido a otro cadete");
        Console.WriteLine("5. Mostrar informe del día");
        Console.WriteLine("6. Salir");
        Console.WriteLine("____________________________________________________");
    }
    public void MenuOpcionGenerarPedido()
    {
        string? obs, nombre, direccion, tel, refDireccion;
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

        if (obs != null && nombre != null && direccion != null && tel != null && refDireccion != null && obs.Length != 0 && nombre.Length != 0 && direccion.Length != 0 && refDireccion.Length != 0)
        {
            cadeteria.CrearPedido(obs, nombre, direccion, tel, refDireccion);
        }
        else
        {
            Console.WriteLine("Debe ingresar todos los datos que se piden");
        }

        ContinuarGestion();
    }

    public void MenuOpcionAsignarPedido()
    {
        int numPedido, idCadete;
        Console.WriteLine("ASIGNAR PEDIDO A UN CADETE");
        Console.WriteLine("INGRESE LOS SIGUIENTES DATOS:");
        Console.WriteLine("Número de pedido: ");
        bufferString = Console.ReadLine();
        numPedido = bufferString != "" && bufferString != null ? int.Parse(bufferString) : -1;
        Console.WriteLine("Id de cadete: ");
        bufferString = Console.ReadLine();
        idCadete = bufferString != "" && bufferString != null ? int.Parse(bufferString) : -1;

        if (numPedido >= 1 && idCadete >= 1)
        {
            cadeteria.AsignarCadeteAPedido(idCadete, numPedido);
        }
        else
        {
            Console.WriteLine("Debe ingresar todos los datos que se piden");
        }

        ContinuarGestion();
    }

    public void MenuOpcionCambiarEstado()
    {
        string? estado;
        int numPedido;
        Console.WriteLine("CAMBIAR ESTADO DE UN PEDIDO");
        Console.WriteLine("INGRESE LOS SIGUIENTES DATOS:");
        Console.WriteLine("Número de pedido: ");
        bufferString = Console.ReadLine();
        numPedido = bufferString != "" && bufferString != null ? int.Parse(bufferString) : -1;
        Console.WriteLine("Estado nuevo (entregado - cancelado): ");
        estado = Console.ReadLine();

        if (numPedido >= 1 && estado != null)
        {
            cadeteria.CambiarEstadoDePedido(numPedido, estado);
        }
        else
        {
            Console.WriteLine("Debe ingresar todos los datos que se piden");
        }

        ContinuarGestion();
    }

    public void MenuOpcionReasignarPedido()
    {
        int numPedido, idCadete;
        Console.WriteLine("REASIGNAR PEDIDO A OTRO CADETE");
        Console.WriteLine("INGRESE LOS SIGUIENTES DATOS:");
        Console.WriteLine("Número de pedido: ");
        bufferString = Console.ReadLine();
        numPedido = bufferString != "" && bufferString != null ? int.Parse(bufferString) : -1;
        Console.WriteLine("Id de cadete: ");
        bufferString = Console.ReadLine();
        idCadete = bufferString != "" && bufferString != null ? int.Parse(bufferString) : -1;

        if (numPedido >= 1 && idCadete >= 1)
        {
            cadeteria.ReasignarPedidoAOtroCadete(numPedido, idCadete);
        }
        else
        {
            Console.WriteLine("Debe ingresar todos los datos que se piden");
        }

        ContinuarGestion();
    }

    public void MenuOpcionMostrarInforme()
    {
        Console.WriteLine("INFORME DEL DÍA");
        Console.WriteLine($"Monto ganado en el día: ${cadeteria.MontoGanadoEnElDia()}");
        Console.WriteLine($"Total de envíos entregados en el día: {cadeteria.TotalEnviosEnElDia()}");
        Console.WriteLine("Total de envíos entregados en el día por cada cadete: ");
        foreach (var enviosPorCadete in cadeteria.EnviosPorCadete())
        {
            Console.WriteLine($"Cadete {enviosPorCadete[0]} | Envíos: {enviosPorCadete[1]}");
        }
        Console.WriteLine("Envíos promedio en el día por cada cadete: ");
        foreach (var promedioEnviosPorCadete in cadeteria.PromedioEnviosPorCadete())
        {
            Console.WriteLine($"Cadete {promedioEnviosPorCadete[0]} | Promedio de envíos: {promedioEnviosPorCadete[1]}%");
        }
        ContinuarGestion();
    }

    public void ContinuarGestion() //OK
    {
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

}