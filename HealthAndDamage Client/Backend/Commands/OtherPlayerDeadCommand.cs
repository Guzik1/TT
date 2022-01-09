using Assets.Scripts.NetworkModules.HealthAndDamage;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using Toolbag;

namespace Modules.HealthAndDamage.Backend.Commands
{
    [MessagePackObject]
    public class OtherPlayerDeadCommand : HealthAndDamageCommand
    {
        [Key(0)] public int PlayerId;

        public override void Execute()
        {
            Dispatcher.Invoke(() => {
                HealthAndDamageUtils.InvokeOnOtherPlayerDeadEvent(PlayerId);
            });
        }
    }
}
