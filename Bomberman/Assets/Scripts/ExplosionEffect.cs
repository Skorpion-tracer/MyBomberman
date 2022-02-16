using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ExplosionEffect : MonoBehaviour
{
    private Animator _animation;

    private void Awake()
    {
        _animation = GetComponent<Animator>();

        Destroy(gameObject, _animation.runtimeAnimatorController.animationClips[0].length);
    }
}
