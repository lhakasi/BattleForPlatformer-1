using UnityEngine;
using AnimationStates;

[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    //public void StartAnimation(States state) => _animator.SetBool(state.ToString(), true);

    //public void StopAnimation(States state) => _animator.SetBool(state.ToString(), false);
}

namespace AnimationStates
{
    public enum States
    {
        Idle,
        Walk,
        Jump,
        Attack,
        Grounded,
        Airborne
    }
}