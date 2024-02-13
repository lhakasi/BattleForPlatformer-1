using UnityEngine;

public class Coin : MonoBehaviour, IPickable
{    
    [SerializeField] private AudioSource _pickCoinSound;

    public void PlayPickSound() => _pickCoinSound.Play();

    public void TurnOff() => gameObject.SetActive(false);
}