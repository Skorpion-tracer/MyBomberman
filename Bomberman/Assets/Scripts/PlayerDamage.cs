using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamage
{
    public void Damage()
    {
        GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }
}

