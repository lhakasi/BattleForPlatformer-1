using UnityEngine;

public class MedKit : MonoBehaviour, IPickable
{
    [field: SerializeField, Range(0, 100)] public int HealingEffect { get; private set; }
    [SerializeField]private AudioSource _pickMedKitSound;

    public void PlayPickSound() => _pickMedKitSound.Play();

    public void TurnOff() => gameObject.SetActive(false);
}
