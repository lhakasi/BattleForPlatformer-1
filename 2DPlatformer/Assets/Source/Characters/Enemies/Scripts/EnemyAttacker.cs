using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class EnemyAttacker : MonoBehaviour
{    
    [SerializeField, Range(0, 100)] private int _damage;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))        
            Attack(player);        
    }

    private void Attack(Player player)
    {
        player.TakeDamage(_damage);
    }
}
