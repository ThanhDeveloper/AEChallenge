using System.Drawing;

namespace AEPortal.Bussiness.ResponseModel
{
    public class ShipResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public double Velocity { get; set; }
    }
}
