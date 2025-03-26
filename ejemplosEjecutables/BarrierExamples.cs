
using System;
using System.Threading;

public static class SincronizacionBasica
{
    private static Barrier _barrier = new(2);

    public static void Ejecutar(string nombre)
    {
        Console.WriteLine($"{nombre} llegó al punto de sincronización");
        _barrier.SignalAndWait();
        Console.WriteLine($"{nombre} continuando luego de la barrera");
    }
}

public static class FaseInicial
{
    private static Barrier _barrier = new(3);

    public static void Fase(string nombre)
    {
        Console.WriteLine($"{nombre} completó su parte de la fase inicial");
        _barrier.SignalAndWait();
        Console.WriteLine($"{nombre} comienza la siguiente fase");
    }
}

public static class FaseConNotificacion
{
    private static Barrier _barrier = new(2, b => Console.WriteLine($"=> Todos completaron la fase {b.CurrentPhaseNumber}"));

    public static void Ejecutar(string nombre)
    {
        Console.WriteLine($"{nombre} ejecutando fase {_barrier.CurrentPhaseNumber}");
        _barrier.SignalAndWait();
    }
}

public static class SimulacionCarrera
{
    private static Barrier _barrier = new(3);

    public static void Corredor(string nombre)
    {
        Console.WriteLine($"{nombre} listo");
        _barrier.SignalAndWait();
        Console.WriteLine($"{nombre} corriendo...");
        Thread.Sleep(new Random().Next(500, 1000));
        Console.WriteLine($"{nombre} llegó a la meta");
    }
}

public static class DosFases
{
    private static Barrier _barrier = new(2);

    public static void Ejecutar(string nombre)
    {
        Console.WriteLine($"{nombre} fase 1");
        _barrier.SignalAndWait();
        Console.WriteLine($"{nombre} fase 2");
        _barrier.SignalAndWait();
        Console.WriteLine($"{nombre} terminado");
    }
}

public static class CoordinacionSensores
{
    private static Barrier _barrier = new(4);

    public static void Sensor(string id)
    {
        Console.WriteLine($"Sensor {id} calibrando...");
        Thread.Sleep(500);
        Console.WriteLine($"Sensor {id} listo");
        _barrier.SignalAndWait();
        Console.WriteLine($"Sensor {id} enviando datos...");
    }
}

public static class JuegoPorTurnos
{
    private static Barrier _barrier = new(3);

    public static void Jugador(string nombre)
    {
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"{nombre} juega turno {i}");
            _barrier.SignalAndWait();
        }
    }
}

public static class EliminacionDeHilo
{
    private static Barrier _barrier = new(3);

    public static void Tarea(string nombre)
    {
        Console.WriteLine($"{nombre} ejecuta fase 1");
        _barrier.SignalAndWait();

        if (nombre == "Hilo3")
        {
            Console.WriteLine($"{nombre} se retira después de la fase 1");
            _barrier.RemoveParticipant();
            return;
        }

        Console.WriteLine($"{nombre} ejecuta fase 2");
        _barrier.SignalAndWait();
    }
}

public static class ProcesamientoFases
{
    private static Barrier _barrier = new(3);

    public static void Proceso(string nombre)
    {
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"{nombre} procesando lote {i}");
            Thread.Sleep(500);
            _barrier.SignalAndWait();
        }
    }
}

public static class ReinicioCoordinado
{
    private static Barrier _barrier = new(2);

    public static void Modulo(string nombre)
    {
        Console.WriteLine($"{nombre} listo para reiniciar");
        _barrier.SignalAndWait();
        Console.WriteLine($"{nombre} reiniciando...");
    }
}
