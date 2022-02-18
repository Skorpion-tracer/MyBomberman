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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamage>(out IDamage damage))
        {
            damage.Damage();
        }
    }
}
