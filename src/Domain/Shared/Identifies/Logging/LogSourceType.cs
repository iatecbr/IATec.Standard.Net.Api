using Domain.Shared.Identifies.Base;

namespace Domain.Shared.Identifies.Logging;

public class LogSourceType(string type) : BaseIdentify(type)
{
    public static LogSourceType AccountPeople => new("accounts.People");
    public static LogSourceType InventoryAsset => new("inventory.Assets");
}