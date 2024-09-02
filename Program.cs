using espacioDeLaCadeteria;

// PARA SABER CUÁNTOS CADETES AGREGAR POR CADETERIA
Random random = new Random();
int numeroAleatorio;

// ACCEDER A LOS DATOS DE TODOS LOS CADETES Y CADETERIAS
AccesoADatos datos = new AccesoADatos();
var datosCadetes = datos.ObtenerDatos("cadetes.csv");
var datosCadeterias = datos.ObtenerDatos("cadeterias.csv");

// _______________________________________________________________________________

// List<Cadeteria> cadeterias = new List<Cadeteria>();

//CREAR TODAS LAS CADETERIAS (USANDO LOS DATOS DE LAS CADETERÍAS)
/*foreach (var item in datosCadeterias)
{
    Cadeteria cadeteria = new Cadeteria(item[0], item[1]);
    cadeterias.Add(cadeteria);
}

// AGREGAR UNA CANTIDAD ALEATORIA DE CADETES (USANDO LOS DATOS DE LOS CADETES) EN CADA CADETERÍA
/*foreach (var cadeteria in cadeterias)
{
    numeroAleatorio = random.Next(1, 11); // PARA SABER CUÁNTOS CADETES AGREGAR POR CADETERIA
    for (int i = 0; i < numeroAleatorio; i++)
    {
        cadeteria.AgregarCadete(int.Parse(datosCadetes[i][0]), datosCadetes[i][1], datosCadetes[i][2], datosCadetes[i][3]);
    }
}*/


//EJEMPLO PRUEBA
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

//MOSTRAR TODAS LAS CADETERIAS Y SUS CADETES
/*foreach (var cadeteria in cadeterias)
{
    Console.WriteLine($"\nCadeteria {cadeteria.Nombre}");
    Console.WriteLine("Lista de Cadetes");
    foreach (var cadete in cadeteria.ListadoCadetes)
    {
        Console.WriteLine($"Id: {cadete.Id} | Nombre: {cadete.Nombre} | Dirección: {cadete.Direccion} | Teléfono: {cadete.Telefono}");
    }
}

Console.WriteLine("\n\n");


/*
//CARGAR PEDIDOS PARA CADA CADETE
Pedido pedido1 = new Pedido("obeservacion del pedido 1", "Juan Carlos", "Av. Belgrano", "3814578647", "473");
Pedido pedido2 = new Pedido("obeservacion del pedido 2", "Juan Pablo", "Av. Mitre", "3814570047", "1200");

cadeterias[0].CrearPedido("obeservacion del pedido a asignar", "Juan Pancho", "Av. Jujuy", "3814522647", "320");
cadeterias[0].AsignarPedidoACadete(1, 2);
cadeterias[0].AsignarPedidoACadete(2, 2);
cadeterias[0].AsignarPedidoACadete(3, 3);

cadeterias[0].Informe();*/