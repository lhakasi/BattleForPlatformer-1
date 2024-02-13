using UnityEngine;

public class Enemy : MonoBehaviour, IMovable
{
    [SerializeField, Range(0, 50)] private int _maxHealth;
    [field: SerializeField, Range(0, 50)] public int CurrentHealth;
    [SerializeField, Range(0, 3)] private float _speed;
    [SerializeField, Range(0, 100)] private int _damage;
    [SerializeField] private string _damageDealerTag;

    private IMover _mover;

    public float Speed => _speed;
    public Transform Transform => transform;

    private void OnValidate()
    {
        if (CurrentHealth > _maxHealth)
            CurrentHealth = _maxHealth;
    }

    private void Update() => _mover?.Update(Time.deltaTime);

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }

    public void Attack(Player player)
    {
        player.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)        
            Die();        
    }

    private void Die()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Мишка помер T_T");
    }
}