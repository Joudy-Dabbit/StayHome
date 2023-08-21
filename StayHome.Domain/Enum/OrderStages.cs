namespace Domain.Enum;

public enum OrderStages
{
    UnConfirmed,
    Confirmed,
    NewOrder,
    OnWay,
    Complete,
    Rejected,
    CanselByCustomer,
    CanselByDriver,
}