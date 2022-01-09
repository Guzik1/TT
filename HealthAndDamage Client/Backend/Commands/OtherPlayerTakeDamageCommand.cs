using Assets.Scripts.NetworkModules.HealthAndDamage;
using MessagePack;
using Toolbag;
using UnityEngine;

namespace Modules.HealthAndDamage.Backend.Commands
{
    [MessagePackObject]
    public class OtherPlayerTakeDamageCommand : HealthAndDamageCommand
    {
        [Key(0)] public int PlayerId;
        [Key(1)] public int CurrentHealth;

        public override void Execute()
        {
            Dispatcher.Invoke(() => {
                HealthAndDamageUtils.InvokeOnOtherPlayerDamageTakeEvent(PlayerId, CurrentHealth);
            });
        }
    }
}
