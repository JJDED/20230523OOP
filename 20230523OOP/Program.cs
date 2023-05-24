using MyClasses;
using System.Reflection;

internal class Program
{
    static void Main(string[] args)
    {
        Car fiat = new Car() { id = 1, brand = "fiat", model = "127" };
        // Reflection....
        // Definitions and metadata in mediate code
        var tt = fiat.GetType();

        Console.WriteLine(tt);
        Console.WriteLine($"This is my class {tt.Name}");
        // insert skal kunne variere!!
        string s = "insert into car values('127','Fiat')"; // this is bad!! 1)sqlinjections
                                                           // 2)error because off inconsistens in db
                                                           // 3)not future proved
        string sql = $"insert into {tt.Name} values('127','Fiat')";
        Console.WriteLine("here is our query " + sql);

        Bike bike = new Bike { Name = "something", Id = 1 }; // what is the difference from other instance
        tt = bike.GetType();
        sql = $"insert into {tt.Name} values('whatever')";
        Console.WriteLine("here is our query " + sql);

        PropertyInfo[] properties;
        properties = tt.GetProperties();
        Console.WriteLine($"This is my property {properties[0].Name}");
        //foreach (var property in properties)
        //{
        //    Console.WriteLine(property.Name);
        //}

        sql = $"insert into {tt.Name} (Name) values('data')";
        sql = $"insert into {tt.Name} (";
        foreach (var property in properties) // id , name
        {
            //logik - create my insert sentence
            // id skal kaseres - hvis det er id vÃ¦k med dig
            //sql = sql + 
            if (property.Name != "Id")
            {
                sql += property.Name;
            }
            Console.WriteLine($"test {property.Name}");
        }
        sql += ") values (";
        foreach (var property in properties)
        {
            if (property.Name != "Id")
            {
                //'data'
                sql += $"'{property.GetValue(bike)}'"; // , 'data'
            }
            // Console.WriteLine(property.GetValue(bike));
        }
        // values ('something', 'something more',)  -- trim min string..

        sql += ")";
        Console.WriteLine(sql);
    }
    public static void hat(Bike bike)// polymorf eller interface eller Object eller T
    {

    }
    public static void hat(Object bike)// polymorf eller interface eller Object eller T
    {

    }
}
