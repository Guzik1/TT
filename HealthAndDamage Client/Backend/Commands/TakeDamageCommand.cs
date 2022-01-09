using Assets.Scripts.NetworkModules.HealthAndDamage;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using Toolbag;
using UnityEngine;

namespace Modules.HealthAndDamage.Backend.Commands
{
    [MessagePackObject]
    public class TakeDamageCommand : HealthAndDamageCommand
    {
        [Key(0)] public int CurrentHealth;

        public override void Execute()
        {
            Dispatcher.Invoke(() => {
                HealthAndDamageUtils.InvokeOnDamageTakeEvent(CurrentHealth);
            });
        }
    }
}
