using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private int _healingEffect;
    [SerializeField]private AudioSource _pickMedKitSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeHealing(_healingEffect);

            _pickMedKitSound.Play();

            this.gameObject.SetActive(false);
        }
    }
}
