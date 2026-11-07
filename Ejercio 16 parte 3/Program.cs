Console.WriteLine("SISTEMA DE MONITOREO DE TANQUE");
Console.WriteLine();

// Validar el nivel del tanque
Console.Write("Ingrese el nivel del tanque: ");
string entrada = Console.ReadLine() ?? "";

if (int.TryParse(entrada, out int nivel))
{
    if (nivel >= 0 && nivel <= 100)
    {
        Console.WriteLine("Nivel aceptado: " + nivel + " %");
    }
    else
    {
        Console.WriteLine("Error: El nivel debe estar entre 0 y 100.");
    }
}
else
{
    Console.WriteLine("Error: Debe ingresar un número entero.");
}

Console.WriteLine();

// Crear el arreglo de sensores
Sensor[] sensores =
{
    new SensorTemperatura("T-01", 28),
    new SensorNivel("N-01", 65),
    new SensorTemperatura("T-02", 31)
};

// Recorrer los sensores
foreach (Sensor sensor in sensores)
{
    try
    {
        Console.WriteLine($"{sensor.Identificador}: {sensor.Leer()}");
    }
    catch (InvalidOperationException)
    {
        Console.WriteLine("Error: Falló el sensor " + sensor.Identificador);
    }
    finally
    {
        Console.WriteLine("Fin del intento");
    }
}


// Clase abstracta
abstract class Sensor
{
    public string Identificador { get; set; }

    public Sensor(string identificador)
    {
        Identificador = identificador;
    }

    public abstract string Leer();
}


// Clase de temperatura
class SensorTemperatura : Sensor
{
    public double Temperatura { get; set; }

    public SensorTemperatura(string identificador, double temperatura)
        : base(identificador)
    {
        Temperatura = temperatura;
    }

    public override string Leer()
    {
        return Temperatura + " °C";
    }
}


// Clase de nivel
class SensorNivel : Sensor
{
    public double Nivel { get; set; }

    public SensorNivel(string identificador, double nivel)
        : base(identificador)
    {
        Nivel = nivel;
    }

    public override string Leer()
    {
        throw new InvalidOperationException("Sensor desconectado");
    }
}