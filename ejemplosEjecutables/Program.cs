
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("🧪 Ejecutando ejemplos de Barrier en C#...");

        Console.WriteLine("----------Ejemplo 1----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.Tarea($"Hilo{i}")).Start();
        Thread.Sleep(800);

        Console.WriteLine("----------Ejemplo 2----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.Inicializar($"Módulo{i}")).Start();
        Thread.Sleep(800);

        Console.WriteLine("----------Ejemplo 3----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.Procesar($"Hilo{i}")).Start();
        Thread.Sleep(800);

        Console.WriteLine("----------Ejemplo 4----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.EjecutarConFases($"Hilo{i}")).Start();
        Thread.Sleep(1000);

        Console.WriteLine("----------Ejemplo 5----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.FaseTrabajo($"Trabajador{i}")).Start();
        Thread.Sleep(800);

        Console.WriteLine("----------Ejemplo 6----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.EtapaPipeline($"Hilo{i}")).Start();
        Thread.Sleep(1200);

        Console.WriteLine("----------Ejemplo 7----------");
        for (int i = 1; i <= 4; i++)
            new Thread(() => BarrierExamples.CalculoModulo($"Módulo{i}")).Start();
        Thread.Sleep(1000);

        Console.WriteLine("----------Ejemplo 8----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.EjecutarSimulacion($"Simulador{i}")).Start();
        Thread.Sleep(1200);

        Console.WriteLine("----------Ejemplo 9----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.FaseEnsamblado($"Componente{i}")).Start();
        Thread.Sleep(1000);

        Console.WriteLine("----------Ejemplo 10----------");
        for (int i = 1; i <= 3; i++)
            new Thread(() => BarrierExamples.TareaCritica($"Tarea{i}")).Start();
        Thread.Sleep(800);

        Console.WriteLine("✅ Fin de los ejemplos.");
    }
}
