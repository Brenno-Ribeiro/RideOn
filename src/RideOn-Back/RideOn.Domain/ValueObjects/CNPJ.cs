namespace RideOn.Domain.ValueObjects
{
    public sealed class CNPJ
    {
        public string Cnpj { get; set; }

        public CNPJ()
        {
                
        }

        public CNPJ(string cnpj)
        {
            Cnpj = cnpj;
        }

    }
}
