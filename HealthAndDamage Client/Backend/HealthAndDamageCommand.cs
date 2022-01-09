using MessagePack;
using Modules.HealthAndDamage.Backend.Commands;

namespace Modules.HealthAndDamage.Backend
{
    [Union(2, typeof(GiveDamageCommand))]
    [Union(3, typeof(TakeDamageCommand))]
    [Union(4, typeof(OtherPlayerTakeDamageCommand))]
    [Union(10, typeof(PlayerDeadCommand))]
    [Union(11, typeof(OtherPlayerDeadCommand))]
    [MessagePackObject]
    public abstract class HealthAndDamageCommand
    {
        public abstract void Execute();
    }
}
