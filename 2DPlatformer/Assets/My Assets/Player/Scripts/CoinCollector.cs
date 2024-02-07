using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private float _coins = 0;
    [SerializeField] private AudioSource _coinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(collision.gameObject);

            _coinCollected.Play();

            _coins += 1;
        }
    }
}
