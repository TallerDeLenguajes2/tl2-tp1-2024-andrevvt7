namespace espacioDeLaCadeteria;

public class Informe{
    public int totalEnviosEnElDia;
    public int montoGanadoEnElDia;
    public List<List<int>> enviosPorCadete;
    public List<List<int>> promedioEnviosPorCadete;

    public Informe(int totalEnvios, int montoGanado, List<List<int>> envios, List<List<int>> promedios){
        totalEnviosEnElDia = totalEnvios;
        montoGanadoEnElDia = montoGanado;
        enviosPorCadete = envios;
        promedioEnviosPorCadete = promedios;
    }
}