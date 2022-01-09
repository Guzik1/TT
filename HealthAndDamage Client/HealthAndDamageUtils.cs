using Modules.HealthAndDamage.Backend;
using Modules.HealthAndDamage.Backend.Commands;

namespace Assets.Scripts.NetworkModules.HealthAndDamage
{
    public static class HealthAndDamageUtils
    {
        public delegate void OnDamageTake(int currentHealth);
        public static event OnDamageTake OnDamageTakeEvent;

        public delegate void OnOtherPlayerDamageTake(int playerId, int currentHealth);
        public static event OnOtherPlayerDamageTake OnOtherPlayerDamageTakeEvent;

        public delegate void OnPlayerDead();
        public static event OnPlayerDead OnPlayerDeadEvent;

        public delegate void OnOtherPlayerDead(int playerId);
        public static event OnOtherPlayerDead OnOtherPlayerDeadEvent;

        public static void InvokeOnDamageTakeEvent(int currentHealth)
        {
            OnDamageTakeEvent?.Invoke(currentHealth);
        }

        public static void InvokeOnOtherPlayerDamageTakeEvent(int playerId, int currentHealth)
        {
            OnOtherPlayerDamageTakeEvent?.Invoke(playerId, currentHealth);
        }

        public static void InvokeOnPlayerDeadEvent()
        {
            OnPlayerDeadEvent?.Invoke();
        }

        public static void InvokeOnOtherPlayerDeadEvent(int playerId)
        {
            OnOtherPlayerDeadEvent?.Invoke(playerId);
        }

        public static void GiveDemage(int forPlayerId, float damageMultipler)
        {
            HealthAndDamageCommand cmd = new GiveDamageCommand(forPlayerId, damageMultipler);
            HealthAndDamageController.GetInstance().Send(cmd);
        }
    }
}
