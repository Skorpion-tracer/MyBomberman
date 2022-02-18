using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private float _maxTimer = 5f;
    [SerializeField] private GameObject _effectBang;

    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _maxTimer)
        {
            Instantiate(_effectBang, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
