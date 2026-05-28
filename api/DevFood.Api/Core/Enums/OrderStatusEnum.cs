namespace DevFood.Api.Core.Enums
{
    public enum OrderStatusEnum
    {
        Requested = 1,
        Processing = 2,
        ReadyForDelivery = 3,
        Intransit = 4,
        Delivered = 5,
        Canceled = 6
    }
}
