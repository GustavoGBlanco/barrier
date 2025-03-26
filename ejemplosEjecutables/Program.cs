
using System;
using System.Threading;

class BarrierExamplesApp
{
    static void Main()
    {
        Console.WriteLine("----------Ejemplo 1----------");
        new Thread(() => SincronizacionBasica.Ejecutar("Hilo1")).Start();
        new Thread(() => SincronizacionBasica.Ejecutar("Hilo2")).Start();
        Thread.Sleep(1000);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 2----------");
        for (int i = 1; i <= 3; i++)
        {
            string nombre = $"Hilo{i}";
            new Thread(() => FaseInicial.Fase(nombre)).Start();
        }
        Thread.Sleep(1000);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 3----------");
        new Thread(() => FaseConNotificacion.Ejecutar("HiloA")).Start();
        new Thread(() => FaseConNotificacion.Ejecutar("HiloB")).Start();
        Thread.Sleep(1000);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 4----------");
        for (int i = 1; i <= 3; i++)
        {
            string corredor = $"Corredor{i}";
            new Thread(() => SimulacionCarrera.Corredor(corredor)).Start();
        }
        Thread.Sleep(1500);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 5----------");
        new Thread(() => DosFases.Ejecutar("Hilo1")).Start();
        new Thread(() => DosFases.Ejecutar("Hilo2")).Start();
        Thread.Sleep(1500);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 6----------");
        for (int i = 1; i <= 4; i++)
        {
            string sensor = $"S{i}";
            new Thread(() => CoordinacionSensores.Sensor(sensor)).Start();
        }
        Thread.Sleep(1500);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 7----------");
        for (int i = 1; i <= 3; i++)
        {
            string jugador = $"Jugador{i}";
            new Thread(() => JuegoPorTurnos.Jugador(jugador)).Start();
        }
        Thread.Sleep(2000);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 8----------");
        new Thread(() => EliminacionDeHilo.Tarea("Hilo1")).Start();
        new Thread(() => EliminacionDeHilo.Tarea("Hilo2")).Start();
        new Thread(() => EliminacionDeHilo.Tarea("Hilo3")).Start();
        Thread.Sleep(1500);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 9----------");
        for (int i = 1; i <= 3; i++)
        {
            string nombre = $"Tarea{i}";
            new Thread(() => ProcesamientoFases.Proceso(nombre)).Start();
        }
        Thread.Sleep(2000);
        Console.WriteLine();

        Console.WriteLine("----------Ejemplo 10----------");
        new Thread(() => ReinicioCoordinado.Modulo("MóduloA")).Start();
        new Thread(() => ReinicioCoordinado.Modulo("MóduloB")).Start();
        Thread.Sleep(1000);
        Console.WriteLine();
    }
}
