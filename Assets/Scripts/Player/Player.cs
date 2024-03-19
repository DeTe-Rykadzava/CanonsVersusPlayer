using Interfaces;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IDamageable, IHealing
    {
        public float MaxHp { get; private set; } = 100f;
        public float HitPoints { get; private set; }

        public bool IsDead { get; private set; } = false;

        private void Awake()
        {
            HitPoints = MaxHp;
        }

        private void FixedUpdate()
        {
            if (HitPoints <= 0)
                Dead();
        }

        private void Dead()
        {
            IsDead = true;
        }

        public void RefillHitPoints()
        {
            HitPoints = MaxHp;
            IsDead = false;
        }

        public void TakeDamage(float damage)
        {
            HitPoints -= damage;
        }

        public void TakeHill(float hillPoint)
        {
            HitPoints += hillPoint;
            HitPoints = Mathf.Clamp(HitPoints, 0, MaxHp);
        }
    }
}