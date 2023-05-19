namespace AEPortal.Bussiness.ResponseModel
{
    public class ShipClosestPortResponse
    {
        public Guid ShipId { get; set; }
        public Guid PortId { get; set; }
        public string PortName { get; set; }
        public double EstimatedArrivalTime { get; set; }
    }
}
