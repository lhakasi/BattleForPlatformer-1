using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] private LayerMask _enemies;
    [SerializeField, Range(0,10)] private float _attackRange;
    
    private Vector2 _attackPoint => transform.position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint, _attackRange);
    }

    public List<Enemy> GetHitEnemies()
    {
        List<Enemy> enemies = new List<Enemy>();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint, _attackRange, _enemies);

        foreach(Collider2D enemy in hitEnemies)        
            enemies.Add(enemy.GetComponent<Enemy>());

        Debug.Log(enemies.Count);

        return enemies;        
    }    
}
