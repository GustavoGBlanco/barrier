# Ejemplos prácticos y profesionales de `Barrier` en C#

Este documento presenta 10 ejemplos realistas y técnicamente justificados del uso de `Barrier` en C#. Todos los ejemplos usan hilos (`Thread`) para ilustrar cómo `Barrier` permite coordinar fases de ejecución entre múltiples hilos.

---

## 🧪 Ejemplo 1: Sincronización básica entre hilos

```csharp
private static Barrier _barrera = new(3);

public static void Tarea(string nombre)
{
    Console.WriteLine($"{nombre} fase 1 completada");
    _barrera.SignalAndWait();
    Console.WriteLine($"{nombre} fase 2 iniciada");
}
```

🔍 Todos los hilos esperan a que los otros terminen su primera fase antes de continuar.

✅ **¿Por qué `Barrier`?**  
Perfecto para sincronizar fases. No es para exclusión mutua, sino para avance grupal.

📊 **Comparación con otros mecanismos:**
- 🔐 `lock`, `Monitor`, `Mutex`: no sirven para coordinar fases.
- 🔁 `SemaphoreSlim`: controla concurrencia, no sincronización de etapas.

---

## 🧪 Ejemplo 2: Inicialización paralela y sincronización antes de trabajo real

```csharp
private static Barrier _inicioSincronizado = new(3);

public static void Inicializar(string modulo)
{
    Console.WriteLine($"{modulo} inicializando...");
    Thread.Sleep(200);
    _inicioSincronizado.SignalAndWait();
    Console.WriteLine($"{modulo} comienza su tarea principal.");
}
```

🔍 Todos los módulos comienzan al mismo tiempo luego de estar listos.

✅ **¿Por qué `Barrier`?**  
Evita que módulos avancen hasta que todos estén preparados.

📊 **Comparación con otros mecanismos:**
- 🔁 `ManualResetEvent`: más complejo de coordinar entre múltiples hilos.
- 🔄 `CountdownEvent`: no permite fases sucesivas.

---

## 🧪 Ejemplo 3: Fase intermedia de sincronización antes de reporte final

```csharp
private static Barrier _coordinador = new(3);

public static void Procesar(string hilo)
{
    Console.WriteLine($"{hilo} procesando parte 1...");
    Thread.Sleep(300);
    _coordinador.SignalAndWait();
    Console.WriteLine($"{hilo} procesando parte 2...");
}
```

🔍 Obliga a que todos los hilos terminen la parte 1 antes de comenzar la parte 2.

✅ **¿Por qué `Barrier`?**  
Permite puntos de encuentro bien definidos entre fases.

📊 **Comparación con otros mecanismos:**
- 🔁 `SemaphoreSlim`: no coordina avance conjunto.
- 🔐 `lock`: no aplica.

---

## 🧪 Ejemplo 4: Reutilización de barrera en múltiples ciclos

```csharp
private static Barrier _barreraReutilizable = new(3);

public static void EjecutarConFases(string hilo)
{
    for (int i = 0; i < 2; i++)
    {
        Console.WriteLine($"{hilo} completó fase {i + 1}");
        _barreraReutilizable.SignalAndWait();
    }
}
```

🔍 Sincroniza múltiples ciclos con la misma barrera.

✅ **¿Por qué `Barrier`?**  
Permite usar `SignalAndWait()` múltiples veces para fases sucesivas.

📊 **Comparación con otros mecanismos:**
- 🔁 `CountdownEvent`: se agota.
- 🔄 `ManualResetEvent`: requiere reset manual.

---

## 🧪 Ejemplo 5: Acción centralizada al final de cada fase

```csharp
private static Barrier _barreraConAccion = new(3, b => Console.WriteLine($"--- Todos completaron la fase {b.CurrentPhaseNumber} ---"));

public static void FaseTrabajo(string nombre)
{
    Console.WriteLine($"{nombre} trabajando en fase {_barreraConAccion.CurrentPhaseNumber}");
    Thread.Sleep(200);
    _barreraConAccion.SignalAndWait();
}
```

🔍 Ejecuta una acción automáticamente al finalizar cada fase.

✅ **¿Por qué `Barrier`?**  
Soporta ejecución coordinada de lógica global al final de cada etapa.

📊 **Comparación con otros mecanismos:**
- 🔁 `SemaphoreSlim`, `Monitor`: no permiten lógica global automática entre fases.
- 🔄 `ManualResetEvent`: requiere implementación adicional.

---

## 🧪 Ejemplo 6: Simulación de pipeline por fases

```csharp
private static Barrier _pipeline = new(3);

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
```

🔍 Los hilos avanzan juntos a través de múltiples etapas como en un pipeline.

✅ **¿Por qué `Barrier`?**  
Facilita avanzar por etapas sincronizadas sin necesidad de múltiples señales manuales.

📊 **Comparación con otros mecanismos:**
- 🔄 `CountdownEvent`: requiere reset y manejo complejo.
- 🔁 `ManualResetEvent`: no soporta fases consecutivas.
- 🔐 `lock`: no es adecuado.

---

## 🧪 Ejemplo 7: Coordinación entre módulos de cálculo

```csharp
private static Barrier _modulos = new(4);

public static void CalculoModulo(string nombre)
{
    Console.WriteLine($"{nombre} calculando parte A...");
    Thread.Sleep(200);
    _modulos.SignalAndWait();

    Console.WriteLine($"{nombre} calculando parte B...");
    Thread.Sleep(200);
    _modulos.SignalAndWait();
}
```

🔍 Asegura que todos los módulos terminen la parte A antes de pasar a la B.

✅ **¿Por qué `Barrier`?**  
Es ideal para sincronizar trabajo en paralelo por etapas.

📊 **Comparación con otros mecanismos:**
- 🔁 `SemaphoreSlim`: regula concurrencia, no sincronización.
- 🔄 `Barrier` es específico y más expresivo para este patrón.

---

## 🧪 Ejemplo 8: Hilos dependientes en fases de simulación

```csharp
private static Barrier _simulacion = new(3);

public static void EjecutarSimulacion(string nombre)
{
    for (int fase = 1; fase <= 3; fase++)
    {
        Console.WriteLine($"{nombre} ejecutando fase {fase}");
        Thread.Sleep(100 * fase);
        _simulacion.SignalAndWait();
    }
}
```

🔍 Sincroniza a todos los hilos por fase, asegurando consistencia de simulación.

✅ **¿Por qué `Barrier`?**  
Es el mecanismo ideal para avanzar por fases cíclicas con múltiples hilos.

📊 **Comparación con otros mecanismos:**
- 🔁 `lock`, `Monitor`: no aplican a este nivel de coordinación grupal.

---

## 🧪 Ejemplo 9: Ensamblado por pasos sincronizados

```csharp
private static Barrier _ensamblado = new(3);

public static void FaseEnsamblado(string componente)
{
    for (int i = 1; i <= 2; i++)
    {
        Console.WriteLine($"{componente} completó paso {i}");
        Thread.Sleep(150);
        _ensamblado.SignalAndWait();
    }
}
```

🔍 Simula una línea de ensamblado sincronizada por pasos.

✅ **¿Por qué `Barrier`?**  
Maneja sincronización por pasos de forma ordenada y reutilizable.

📊 **Comparación con otros mecanismos:**
- 🔁 `SemaphoreSlim`: sin fases explícitas.
- 🔄 `CountdownEvent`: no permite repetición de fases.

---

## 🧪 Ejemplo 10: Coordinación de tareas críticas con acción final

```csharp
private static Barrier _finalizacion = new(3, b => Console.WriteLine($"✅ Todos completaron la fase crítica {b.CurrentPhaseNumber}"));

public static void TareaCritica(string nombre)
{
    Console.WriteLine($"{nombre} ejecutando tarea crítica.");
    Thread.Sleep(250);
    _finalizacion.SignalAndWait();
}
```

🔍 Ejecuta una acción cuando todos completan su tarea crítica.

✅ **¿Por qué `Barrier`?**  
Permite ejecutar una acción final automáticamente, útil para logging o limpieza.

📊 **Comparación con otros mecanismos:**
- 🔁 `lock`: no permite acciones globales.
- 🔄 `Barrier` es el único con `postPhaseAction`.

---
