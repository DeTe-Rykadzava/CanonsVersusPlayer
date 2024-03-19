using Interfaces;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out IDamageable obj))
        {
            obj.TakeDamage(damage);
        }
    }
}
