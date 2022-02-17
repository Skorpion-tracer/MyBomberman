using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PutBomb : MonoBehaviour
{
    private const string BOMB = "Bomb";

    [SerializeField] private GameObject _bomb;

    private void Update()
    {
#if PC
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bomb, transform.position, Quaternion.identity);
        } 
#endif

#if UNITY_ANDROID
        if (CrossPlatformInputManager.GetButtonDown(BOMB))
        {
            Instantiate(_bomb, transform.position, Quaternion.identity);
        }
#endif
    }
}
