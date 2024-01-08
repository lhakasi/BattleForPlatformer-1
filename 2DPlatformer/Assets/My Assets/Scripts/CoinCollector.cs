using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private float _coins = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(collision.gameObject);

            _coins += 1;
        }
    }
}
