using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 0.3f);
    }

}
