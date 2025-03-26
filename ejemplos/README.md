# Ejemplos de `Barrier` en C#

Este documento contiene 10 ejemplos prácticos y progresivos del uso de `Barrier` en C#. Cada uno está diseñado para ejecutarse con `Thread` y representar un escenario real donde varios hilos deben sincronizarse en fases.

---

## 🧪 Ejemplo 1: Sincronización básica entre 2 hilos

```csharp
private static Barrier _barrier = new(2);

public static void Ejecutar(string nombre)
{
    Console.WriteLine($"{nombre} llegó al punto de sincronización");
    _barrier.SignalAndWait();
    Console.WriteLine($"{nombre} continuando luego de la barrera");
}
```

🔍 Dos hilos se sincronizan antes de continuar.

✅ **¿Por qué Barrier?**  
Permite sincronizar un número exacto de hilos sin bloqueo indefinido.

---

## 🧪 Ejemplo 2: Fase inicial de múltiples hilos

```csharp
private static Barrier _barrier = new(3);

public static void FaseInicial(string nombre)
{
    Console.WriteLine($"{nombre} completó su parte de la fase inicial");
    _barrier.SignalAndWait();
    Console.WriteLine($"{nombre} comienza la siguiente fase");
}
```

🔍 Todos los hilos deben esperar que los demás terminen antes de avanzar.

---

## 🧪 Ejemplo 3: Barrera con acción entre fases

```csharp
private static Barrier _barrier = new(2, b => Console.WriteLine($"==> Todos completaron la fase {b.CurrentPhaseNumber}"));

public static void EjecutarConFase(string nombre)
{
    Console.WriteLine($"{nombre} ejecutando fase { _barrier.CurrentPhaseNumber }");
    _barrier.SignalAndWait();
}
```

🔍 Ejecuta una acción centralizada cada vez que se completa una fase.

✅ **¿Por qué Barrier?**  
Es el único sincronizador que permite lógica entre fases multihilo.

---

## 🧪 Ejemplo 4: Simulación de carrera

```csharp
private static Barrier _barrier = new(3);

public static void Corredor(string nombre)
{
    Console.WriteLine($"{nombre} listo");
    _barrier.SignalAndWait(); // salida
    Console.WriteLine($"{nombre} corriendo...");
    Thread.Sleep(new Random().Next(500, 1000));
    Console.WriteLine($"{nombre} llegó a la meta");
}
```

🔍 Todos los hilos comienzan al mismo tiempo una simulación.

---

## 🧪 Ejemplo 5: Dos fases sincronizadas

```csharp
private static Barrier _barrier = new(2);

public static void Fase1y2(string nombre)
{
    Console.WriteLine($"{nombre} fase 1");
    _barrier.SignalAndWait();
    Console.WriteLine($"{nombre} fase 2");
    _barrier.SignalAndWait();
    Console.WriteLine($"{nombre} terminado");
}
```

🔍 Ejecuta dos fases consecutivas asegurando que todos avancen a la vez.

---

## 🧪 Ejemplo 6: Coordinación de sensores

```csharp
private static Barrier _barrier = new(4);

public static void Sensor(string id)
{
    Console.WriteLine($"Sensor {id} calibrando...");
    Thread.Sleep(500);
    Console.WriteLine($"Sensor {id} listo");
    _barrier.SignalAndWait();
    Console.WriteLine($"Sensor {id} enviando datos...");
}
```

🔍 Todos los sensores deben estar listos antes de transmitir datos.

---

## 🧪 Ejemplo 7: Juego por turnos

```csharp
private static Barrier _barrier = new(3);

public static void Jugador(string nombre)
{
    for (int i = 1; i <= 3; i++)
    {
        Console.WriteLine($"{nombre} juega turno {i}");
        _barrier.SignalAndWait();
    }
}
```

🔍 Los turnos del juego se sincronizan en cada ronda.

---

## 🧪 Ejemplo 8: Fase con eliminación de hilo

```csharp
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
```

🔍 Un hilo puede dejar de participar dinámicamente.

✅ **¿Por qué Barrier?**  
Permite adaptar dinámicamente el número de hilos activos.

---

## 🧪 Ejemplo 9: Procesamiento distribuido por fases

```csharp
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
```

🔍 Todos deben procesar una etapa antes de avanzar a la siguiente.

---

## 🧪 Ejemplo 10: Barrera para reinicio coordinado

```csharp
private static Barrier _barrier = new(2);

public static void ReiniciarSistema(string modulo)
{
    Console.WriteLine($"{modulo} listo para reiniciar");
    _barrier.SignalAndWait();
    Console.WriteLine($"{modulo} reiniciando...");
}
```

🔍 Se espera que todos los módulos estén listos antes de un reinicio.

✅ **¿Por qué Barrier?**  
Es ideal para escenarios donde se debe coordinar acciones atómicas por fases.

---
