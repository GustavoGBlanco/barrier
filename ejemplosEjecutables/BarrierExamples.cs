
using System;
using System.Threading;

public static class BarrierExamples
{
    private static Barrier _barrera = new(3);
    private static Barrier _inicioSincronizado = new(3);
    private static Barrier _coordinador = new(3);
    private static Barrier _barreraReutilizable = new(3);
    private static Barrier _barreraConAccion = new(3, b => Console.WriteLine($"--- Todos completaron la fase {b.CurrentPhaseNumber} ---"));
    private static Barrier _pipeline = new(3);
    private static Barrier _modulos = new(4);
    private static Barrier _simulacion = new(3);
    private static Barrier _ensamblado = new(3);
    private static Barrier _finalizacion = new(3, b => Console.WriteLine($"✅ Todos completaron la fase crítica {b.CurrentPhaseNumber}"));

    public static void Tarea(string nombre)
    {
        Console.WriteLine($"{nombre} fase 1 completada");
        _barrera.SignalAndWait();
        Console.WriteLine($"{nombre} fase 2 iniciada");
    }

    public static void Inicializar(string modulo)
    {
        Console.WriteLine($"{modulo} inicializando...");
        Thread.Sleep(200);
        _inicioSincronizado.SignalAndWait();
        Console.WriteLine($"{modulo} comienza su tarea principal.");
    }

    public static void Procesar(string hilo)
    {
        Console.WriteLine($"{hilo} procesando parte 1...");
        Thread.Sleep(300);
        _coordinador.SignalAndWait();
        Console.WriteLine($"{hilo} procesando parte 2...");
    }

    public static void EjecutarConFases(string hilo)
    {
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"{hilo} completó fase {i + 1}");
            _barreraReutilizable.SignalAndWait();
        }
    }

    public static void FaseTrabajo(string nombre)
    {
        Console.WriteLine($"{nombre} trabajando en fase {_barreraConAccion.CurrentPhaseNumber}");
        Thread.Sleep(200);
        _barreraConAccion.SignalAndWait();
    }

    public static void EtapaPipeline(string nombre)
    {
        Console.WriteLine($"{nombre} ejecutando ETAPA 1");
        Thread.Sleep(300);
        _pipeline.SignalAndWait();

        Console.WriteLine($"{nombre} ejecutando ETAPA 2");
        Thread.Sleep(200);
        _pipeline.SignalAndWait();

        Console.WriteLine($"{nombre} ejecutando ETAPA 3");
        Thread.Sleep(100);
        _pipeline.SignalAndWait();
    }

    public static void CalculoModulo(string nombre)
    {
        Console.WriteLine($"{nombre} calculando parte A...");
        Thread.Sleep(200);
        _modulos.SignalAndWait();

        Console.WriteLine($"{nombre} calculando parte B...");
        Thread.Sleep(200);
        _modulos.SignalAndWait();
    }

    public static void EjecutarSimulacion(string nombre)
    {
        for (int fase = 1; fase <= 3; fase++)
        {
            Console.WriteLine($"{nombre} ejecutando fase {fase}");
            Thread.Sleep(100 * fase);
            _simulacion.SignalAndWait();
        }
    }

    public static void FaseEnsamblado(string componente)
    {
        for (int i = 1; i <= 2; i++)
        {
            Console.WriteLine($"{componente} completó paso {i}");
            Thread.Sleep(150);
            _ensamblado.SignalAndWait();
        }
    }

    public static void TareaCritica(string nombre)
    {
        Console.WriteLine($"{nombre} ejecutando tarea crítica.");
        Thread.Sleep(250);
        _finalizacion.SignalAndWait();
    }
}
