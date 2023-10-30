using HealthSystem;
using UnityEngine;

namespace Player
{
    public class PlayerHealth: DamageTaker<EnemyCommonBullet>
    {
        protected override void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}