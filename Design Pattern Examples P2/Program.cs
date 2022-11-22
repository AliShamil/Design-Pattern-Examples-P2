namespace BuilderPattern;

public class Engine
{
    public override string ToString() => "Simple Engine";
}

public class SportEngine : Engine
{
    public override string ToString() => "Sport Engine";
}

public interface ICarBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(Engine engine);
    void SetTripComputer();
    void SetGPS();

}

public class CarBuilder : ICarBuilder
{
    private Car car = new();

    public void Reset()
    {
        car = new();
    }

    public void SetEngine(Engine engine)
    {
        car.Engine = engine;
    }

    public void SetGPS()
    {
        car.GPS = "GPS for Simple Car";
    }

    public void SetSeats(int number)
    {
        car.Seats = number;
    }

    public void SetTripComputer()
    {
        car.TripComputer = "TripComputer for Simple Cars";
    }

    public Car GetResult() => car;
}

public class CarManualBuilder : ICarBuilder
{
    private CarManual manualCar = new();

    public void Reset()
    {
        manualCar = new();
    }

    public void SetEngine(Engine engine)
    {
        manualCar.Engine = engine;
    }

    public void SetGPS()
    {
        manualCar.GPS = "GPS For Manual Car";
    }

    public void SetSeats(int number)
    {
        manualCar.Seats = number;
    }

    public void SetTripComputer()
    {
        manualCar.TripComputer = "TripComputer for Manual Cars";
    }

    public CarManual GetResult() => manualCar;
}









public class Car
{
    public int Seats { get; set; }
    public string? TripComputer { get; set; }
    public string? GPS { get; set; }
    public Engine? Engine { get; set; }

    public override string ToString()
    =>$@"Seats count: {Seats}
Trip Computer: {TripComputer??"EMPTY"}
GPS: {GPS??"EMPTY"}
Engine:{Engine}";
    
}

public class CarManual : Car
{

}






public class Director
{
    public CarManual MakeSUV(CarManualBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(4);
        builder.SetEngine(new Engine());
        return builder.GetResult();
    }

    public Car MakeSportCar(CarBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(2);
        builder.SetEngine(new SportEngine());
        builder.SetTripComputer();
        builder.SetGPS();
        return builder.GetResult();
    }

}



public class Program
{
    public static void Main()
    {
        Director director = new();
        CarBuilder carBuilder = new();
        CarManualBuilder carManualBuilder = new();

        CarManual carManual = director.MakeSUV(carManualBuilder);
        Car sportCar = director.MakeSportCar(carBuilder);
        Console.WriteLine("---- CAR INFO ----");
        Console.WriteLine(carManual);
        Console.WriteLine();

        Console.WriteLine(sportCar);
    }
}