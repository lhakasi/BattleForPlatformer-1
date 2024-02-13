using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class EnemyAttackLogic : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake() => _enemy = GetComponentInParent<Enemy>();    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))        
            _enemy.Attack(player);        
    }
}
