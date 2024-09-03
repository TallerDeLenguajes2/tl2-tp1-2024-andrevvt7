using espacioDeLaCadeteria;

// PARA SABER CUÁNTOS CADETES AGREGAR POR CADETERIA
Random random = new Random();
int numeroAleatorio;
int opcion;

// ACCEDER A LOS DATOS DE TODOS LOS CADETES Y CADETERIAS
AccesoADatos datos = new AccesoADatos();
var datosCadetes = datos.ObtenerDatos("cadetes.csv");
var datosCadeterias = datos.ObtenerDatos("cadeterias.csv");

//CREAR CADETERIA CON DATOS ALEATORIOS
numeroAleatorio = random.Next(1, 11);
if (datosCadeterias == null){return;}
if (datosCadetes == null){return;}

Cadeteria cadeteria = new Cadeteria(datosCadeterias[numeroAleatorio][0], datosCadeterias[numeroAleatorio][1]);

//CREAR GESTIÓN PARA CADETERIA
Gestion gestion = new Gestion(cadeteria);

//AGREGARLE UN NÚMERO ALEATORIO DE CADETES
numeroAleatorio = random.Next(1, 11);
for (int i = 0; i < numeroAleatorio; i++) //agregarle 4 cadetes
{
    cadeteria.AgregarCadete(int.Parse(datosCadetes[i][0]), datosCadetes[i][1], datosCadetes[i][2], datosCadetes[i][3]);
}


Console.Clear();
do
{
    Console.ForegroundColor = ConsoleColor.Blue;
    gestion.MostrarMenu();

    opcion = int.Parse(Console.ReadLine());
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Blue;
    switch (opcion)
    {
        case 1:
            gestion.GenerarPedido();
            break;
        case 2:
            gestion.AsignarPedido();
            break;
        case 3:
            gestion.CambiarEstado();
            break;
        case 4:
            gestion.ReasignarPedido();
            break;
        case 5:
            gestion.MostrarInforme();
            break;
        case 6:
            Console.WriteLine("Programa terminado.");
            break;
        default:
            Console.WriteLine("Opción no válida.");
            Console.Clear();
            break;
    }
} while (opcion != 6);

Console.WriteLine("\n\nTODO OK\n\n");
Console.Clear();

// _______________________________________________________________________________

/*
//EJEMPLO PRUEBA ANTES DE CREAR EL MENÚ
//CREAR CADETERIA
numeroAleatorio = random.Next(1, 11);
Cadeteria cadeteria1 = new Cadeteria(datosCadeterias[numeroAleatorio][0], datosCadeterias[numeroAleatorio][1]); //crear cadeteria
//cadeterias.Add(cadeteria1);

//AGREGARLE UN NÚMERO ALEATORIO DE CADETES
numeroAleatorio = random.Next(1, 11);
for (int i = 0; i < 8; i++) //agregarle 4 cadetes
{
    cadeteria1.AgregarCadete(int.Parse(datosCadetes[i][0]), datosCadetes[i][1], datosCadetes[i][2], datosCadetes[i][3]);
}


//Console.WriteLine("CREACION DE PEDIDOS");
cadeteria1.CrearPedido("obeservacion del pedido a asignar 1", "Juan Pancho 1", "Av. Jujuy 1", "3814522647", "320");
cadeteria1.CrearPedido("obeservacion del pedido a asignar 2", "Juan Pancho 2", "Av. Jujuy 2", "3814522647", "320");
cadeteria1.CrearPedido("obeservacion del pedido a asignar 3", "Juan Pancho 3", "Av. Jujuy 3", "3814522647", "320");
cadeteria1.CrearPedido("obeservacion del pedido a asignar 4", "Juan Pancho 4", "Av. Jujuy 4", "3814522647", "320");
cadeteria1.CrearPedido("obeservacion del pedido a asignar 5", "Juan Pancho 4", "Av. Jujuy 4", "3814522647", "320");
cadeteria1.CrearPedido("obeservacion del pedido a asignar 6", "Juan Pancho 4", "Av. Jujuy 4", "3814522647", "320");
cadeteria1.CrearPedido("obeservacion del pedido a asignar 7", "Juan Pancho 4", "Av. Jujuy 4", "3814522647", "320");


//ASIGNAR
Console.WriteLine("\n\nASIGNACION DE PEDIDOS A CADETES");
int cantidadDisponiblePedidosAAsignarOriginal = cadeteria1.PedidosSinAsignar.Count();
int cantidadDisponiblePedidosAAsignarModificada;
int numeroAleatorioDePedido;
string pedidosYaAsignados;

foreach (var cadete in cadeteria1.ListadoCadetes)
{
    cantidadDisponiblePedidosAAsignarModificada = cadeteria1.PedidosSinAsignar.Count();
    numeroAleatorio = random.Next(0, cantidadDisponiblePedidosAAsignarModificada);

    Console.WriteLine($"\n___________________CADETE {cadete.Id}_____________________________");
    Console.WriteLine($"\nCANTIDAD DE PEDIDOS DISPONIBLES PARA ASIGNAR: {cantidadDisponiblePedidosAAsignarModificada}");

    Console.WriteLine($"Número aleatorio de pedidos a asignar (de los disponibles) al cadete {cadete.Id}: {numeroAleatorio}");

    if (numeroAleatorio != 0) //si se le asigna algún pedido o no
    {
        for (int i = 0; i < numeroAleatorio; i++)
        {
            numeroAleatorioDePedido = random.Next(1, cantidadDisponiblePedidosAAsignarOriginal);
            Console.WriteLine($"Tratar de asignar pedido número {numeroAleatorioDePedido}");
            cadeteria1.AsignarPedidoACadete(numeroAleatorioDePedido,cadete.Id);
        }
    }

    pedidosYaAsignados = string.Join(',', cadeteria1.ListadoPedidosYaAsignados());
    Console.WriteLine($"Pedidos ya asignados: {pedidosYaAsignados}");
}

//Console.WriteLine("ASIGNACION CON LA SEGUNDA FUNCION");
//cadeteria1.AsignarPedidoACadete(5,4);


Console.WriteLine("CAMBIO DE ESTADO");
cadeteria1.CambiarEstadoDePedido(1, "entregado");
cadeteria1.CambiarEstadoDePedido(5, "entregado");
cadeteria1.CambiarEstadoDePedido(3, "entregado");
cadeteria1.CambiarEstadoDePedido(4, "entregado");


Console.WriteLine("\nMUESTRA DE DATOS DE LA CADETERIA");
Console.WriteLine($"Cadeteria {cadeteria1.Nombre}");

Console.WriteLine("\nLista de Cadetes");
foreach (var cadete in cadeteria1.ListadoCadetes)
{
    Console.WriteLine($"Id: {cadete.Id} | Nombre: {cadete.Nombre} | Dirección: {cadete.Direccion} | Teléfono: {cadete.Telefono}");
}


Console.WriteLine("Lista de Pedidos por Cadete");
foreach (var cadete in cadeteria1.ListadoCadetes)
{
    Console.WriteLine($"_______________________________________");
    Console.WriteLine($"Cadete {cadete.Id}");
    if (cadete.ListadoPedidos.Count() != 0)
    {
        foreach (var pedido in cadete.ListadoPedidos)
        {
            Console.WriteLine($"Pedido número: {pedido.Numero} | Estado: {pedido.Estado}");
        }
    } else {
        Console.WriteLine("El cadete no tiene asignado ningún pedido");
    }
}
Console.WriteLine("\n\n");

// INFORME DE UNA DE LAS CADETERIAS
cadeteria1.Informe();
*/