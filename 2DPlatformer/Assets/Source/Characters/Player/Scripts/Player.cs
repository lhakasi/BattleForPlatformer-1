using AnimationStates;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, ICharacter
{
    [field: SerializeField] public PlayerView View { get; private set; }
    [field: SerializeField] public GroundChecker GroundChecker { get; private set; }
    [field: SerializeField] public AttackZone AttackZone { get; private set; }
    [field: SerializeField] public PlayerConfig Config { get; private set; }
    
    [SerializeField] private CoinCollector _coinCollector;

    [SerializeField, Range(0, 100)] private int _maxHealth;
    [field: SerializeField, Range(0, 100)] public int CurrentHealth { get; private set; }
    

    private PlayerInput _input;
    private PlayerStateMachine _stateMachine;
    private Rigidbody2D _rigidbody;

    public PlayerInput Input => _input;
    public Rigidbody2D Rigidbody => _rigidbody;

    private void OnValidate()
    {
        if (CurrentHealth > _maxHealth)
            CurrentHealth = _maxHealth;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInput();
        _stateMachine = new PlayerStateMachine(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MedKit>(out MedKit medKit))
        {
            TakeHealing(medKit.HealingEffect);

            medKit.PlayPickSound();
            medKit.TurnOff();
        }

        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _coinCollector.AddCoin();

            coin.PlayPickSound();
            coin.TurnOff();
        }
    }

    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        View.StartAnimation(States.Hurt);        
        View.StartAnimation(States.Idle);        

        if (CurrentHealth <= 0)        
            Die();        
    }

    public void TakeHealing(int healing)
    {
        CurrentHealth += healing;

        if (CurrentHealth > _maxHealth)
            CurrentHealth = _maxHealth;
    }

    private void Die()
    {
        View.StartAnimation(States.Die);

        gameObject.SetActive(false);

        Debug.Log("онлеп");
    }
}