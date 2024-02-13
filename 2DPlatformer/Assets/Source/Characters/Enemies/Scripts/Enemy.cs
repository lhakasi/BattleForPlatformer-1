using UnityEngine;

public class Enemy : MonoBehaviour, IMovable, ICharacter
{
    [SerializeField, Range(0, 50)] private int _maxHealth;
    [field: SerializeField, Range(0, 50)] public int CurrentHealth {  get; private set; }
    
    [SerializeField, Range(0, 3)] private float _speed;    

    private IMover _mover;

    public float Speed => _speed;
    public Transform Transform => transform;

    private void OnValidate()
    {
        if (CurrentHealth > _maxHealth)
            CurrentHealth = _maxHealth;
    }

    private void Update() => _mover?.Move(Time.deltaTime);

    public void SetMover(IMover mover)
    {
        _mover?.StopMove();
        _mover = mover;
        _mover.StartMove();
    }    

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)        
            Die();        
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("Мишка помер T_T");
    }
}