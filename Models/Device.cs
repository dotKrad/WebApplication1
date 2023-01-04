namespace WebApplication1.Model
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        public int AccountId { get; set; }
        public bool IsAdopted { get; set; }
        public string AdoptionCode { get; set; }

    }
}
