Garage garage = new Garage(3);

garage[0] = new Car { Model = "Alfa Romeo", Price = 1244244 };
garage[1] = new Car { Model = "Toyota Prius", Price = 12 };

Console.WriteLine(garage[0]);
Console.WriteLine(garage["AlfaRomeo"]);




class Car
{
    public string Model { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"{Model} - {Price}$";
    }

}

class Garage
{
    Car[] cars;
    public Garage(int count)
    {
        cars = new Car[count];
    }
    public int Count
    {
        get { return cars.Length; }
    }

    public Car this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Length)
            {
                return cars[index];
            }

            throw new IndexOutOfRangeException();
        }
        set
        {
            if (index >= 0 && index < cars.Length)
            {
                cars[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
    public Car this[string model]
    {
        get
        {
            if (Enum.IsDefined(typeof(Models), model))
            {
                return cars[(int)Enum.Parse(typeof(Models), model)];
            }
            else
            {
                return new Car();
            }
        }
        set { cars[(int)Enum.Parse(typeof(Models), model)] = value; }
    }


    enum Models { AlfaRomeo, Prius, NAZ, ZAZ, Lamborgini}
}
