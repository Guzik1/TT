using Assets.Scripts.NetworkModules.HealthAndDamage;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.HealthAndDamage.UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar: MonoBehaviour
    {
        public Gradient gradient;
        public Image fill;

        Slider slider;

        int maxHealth = 100;

        void Start()
        {
            slider = GetComponent<Slider>();

            slider.maxValue = maxHealth;

            SetHealth(maxHealth);

            HealthAndDamageUtils.OnDamageTakeEvent += SetHealth;
        }

        void OnDestroy()
        {
            HealthAndDamageUtils.OnDamageTakeEvent -= SetHealth;
        }

        public void SetHealth(int health)
        {
            slider.value = health;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
