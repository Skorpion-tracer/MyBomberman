using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBomb : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bomb, transform.position, Quaternion.identity);
        }
    }
}
