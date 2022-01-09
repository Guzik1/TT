using MessagePack;
namespace Modules.HealthAndDamage.Backend.Commands
{
    /// <summary>
    /// [OUT] send to server when give a damage to other player by this player.
    /// </summary>
    [MessagePackObject]
    public class GiveDamageCommand : HealthAndDamageCommand
    {
        [Key(0)] public int ForPlayerId;
        [Key(1)] public float DamageMultipler;

        public GiveDamageCommand(int forPlayerId, float damageMultipler)
        {
            ForPlayerId = forPlayerId;
            DamageMultipler = damageMultipler;
        }

        public override void Execute(){ }
    }
}
