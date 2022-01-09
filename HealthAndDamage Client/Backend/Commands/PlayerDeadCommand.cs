using Assets.Scripts.NetworkModules.HealthAndDamage;
using MessagePack;
using Toolbag;

namespace Modules.HealthAndDamage.Backend.Commands
{
    [MessagePackObject]
    public class PlayerDeadCommand : HealthAndDamageCommand
    {
        [Key(0)] public int KillerPlayerId;

        public override void Execute()
        {
            Dispatcher.Invoke(() => {
                HealthAndDamageUtils.InvokeOnPlayerDeadEvent();
            });
        }
    }
}
