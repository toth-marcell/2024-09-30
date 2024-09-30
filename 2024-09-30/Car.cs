namespace _2024_09_30
{
    public class Car
    {
        public int Id;
        public string Make;
        public string Model;
        public string Colour;
        public int Year;
        public int Power;
        public override string ToString() => $"{Year} {Make} {Model}";
    }
}
