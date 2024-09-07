using espacioDeLaCadeteria;

int opcionMenu, tipoAcceso;
string? bufferString;

tipoAcceso = Gestion.ElegirTipoDeAccesoADatos(); //elección del tipo de acceso
Cadeteria cadeteria = Gestion.CargarDatosCadeteria(tipoAcceso); //creación y carga de datos (sus datos y el de los cadetes) de la cadetería
Gestion gestion = new Gestion(cadeteria); //para gestionar el menú según la cadetería creada


Console.Clear();
do
{
    Console.ForegroundColor = ConsoleColor.Blue;

    gestion.MostrarMenu();

    bufferString = Console.ReadLine(); // ingreso de la opción elegida del menú
    opcionMenu = bufferString != null && bufferString != ""? int.Parse(bufferString): -1;
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Blue;

    switch (opcionMenu)
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
            break;
        default:
            Console.WriteLine("Opción no válida.");
            Console.Clear();
            break;
    }
} while (opcionMenu != 6);

Console.Clear();