namespace api_neo_nasa
{
    public class AsteroidsDTO
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public double Media { get; set; }
        public double? Velocidad { get; set; }
        public double RelativeVelocity { get; set; }
        public string Planet {get;set;}
    }
}
