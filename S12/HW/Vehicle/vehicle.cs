public class Car{
    public string Brand;
    public string Model;
    public int N_Wheels;
    public int Cilenders;
    public double Displacement;
    public int Gears;
    public double Weight;
    public Car(string b, string m, int nw, int cil, double dis, int gear, double wei){
        Brand = b;
        Model = m;
        N_Wheels = nw;
        Cilenders = cil;
        Displacement = dis;
        Gears = gear;
        Weight = wei;
    }
    public void PrintCar(){
        System.Console.WriteLine($"{this.Brand} {this.Model}\nNumber of wheels: {this.N_Wheels}\tEngine: {this.Displacement} litre {this.Cilenders} cilenders\nGearbox: {this.Gears} speed\tWeight: {this.Weight}Kg");
    }
}