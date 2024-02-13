using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private AudioSource _pickCoinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _coinCollector.AddCoin();

            _pickCoinSound.Play();

            this.gameObject.SetActive(false);
        }
    }
}