namespace Domain.Enum;

public enum OrderStages
{
    UnConfirmed,
    Confirmed,
    NewOrder,
    OnWay,
    Complete,
    Retract,
    CanselByCustomer,
    CanselByDriver,
}