namespace RideOn.Domain.ValueObjects
{
    public sealed class Plate
    {
        public string Number { get; set; }

        public Plate()
        {
                
        }

        public Plate(string number)
        {
            Number = number;
        }   
    }
}
