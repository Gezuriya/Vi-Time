using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMove : MonoBehaviour
{
    public float speed;
    public Vector2 dirRight;

    void FixedUpdate()
    {

        transform.Translate(speed * dirRight * Time.deltaTime, Space.World);
        transform.rotation *= Quaternion.Euler(0, 0, 0.5f);

        Destroy(gameObject, 10f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
