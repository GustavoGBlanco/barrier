# Módulo 7: `Barrier` en C#

## 🛠️ ¿Qué es `Barrier`?
`Barrier` es un mecanismo de sincronización que permite a **múltiples hilos esperar unos por otros en etapas** (fases), antes de continuar con la siguiente.

Ideal cuando varios hilos deben **llegar a un punto común antes de continuar**.

---

## 🟠 Concepto clave
- Cada hilo llama a `SignalAndWait()` cuando termina una fase.
- Todos los hilos deben llegar para que continúe la siguiente fase.
- Se pueden definir acciones al completar cada fase.

---

## 🏠 Escenario práctico: **Fábricas sincronizadas por fases**

Simulamos que 3 estaciones de trabajo (hilos) fabrican productos en 2 fases:
1. Fabricación del cuerpo
2. Pintura

Cada fase solo puede comenzar cuando **todas las estaciones** han completado la anterior.

### Archivos

#### `ManufacturingStation.cs`
```csharp
using System;
using System.Threading;

public class ManufacturingStation
{
    private readonly int _id;
    private readonly Barrier _barrier;

    public ManufacturingStation(int id, Barrier barrier)
    {
        _id = id;
        _barrier = barrier;
    }

    public void Producir()
    {
        Console.WriteLine($"Estación {_id} - Fase 1: Fabricando cuerpo");
        Thread.Sleep(1000 + _id * 200);
        _barrier.SignalAndWait();

        Console.WriteLine($"Estación {_id} - Fase 2: Pintando");
        Thread.Sleep(1000 + _id * 200);
        _barrier.SignalAndWait();

        Console.WriteLine($"Estación {_id} - Producto terminado!");
    }
}
```

#### `Program.cs`
```csharp
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Barrier barrera = new(participantCount: 3, barrier =>
        {
            Console.WriteLine("--- Todas las estaciones completaron la fase. ---");
        });

        for (int i = 1; i <= 3; i++)
        {
            int id = i;
            var estacion = new ManufacturingStation(id, barrera);
            new Thread(estacion.Producir).Start();
        }
    }
}
```

---

## 🔢 Detalles técnicos

- `Barrier(int participantes, Action<Barrier> postPhaseAction)`
  - `participantes`: cantidad de hilos que deben sincronizarse.
  - `postPhaseAction`: acción que se ejecuta cuando todos llegan.

- `SignalAndWait()`:
  - Notifica que el hilo llegó.
  - Espera hasta que los demás también lleguen.

---

## 🧼 Buenas prácticas con `Barrier`

| Regla | Motivo |
|-------|--------|
| ✅ Usalo cuando todos los hilos deben sincronizarse por fases | Ideal para flujos por etapas |
| ✅ Mantené el mismo número de participantes durante la barrera | Evita inconsistencias |
| ✅ Usá `postPhaseAction` para logging o validaciones globales | Mejora trazabilidad |

---
