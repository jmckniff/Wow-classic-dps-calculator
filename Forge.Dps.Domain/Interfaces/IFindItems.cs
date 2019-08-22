using Forge.Dps.Domain.Entities;

namespace Forge.Dps.Domain.Interfaces
{
    public interface IFindItems
    {
        Item FindByName(string itemName);
    }
}
