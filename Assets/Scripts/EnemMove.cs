using UnityEngine;

public class EnemMove : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject[] dest = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < dest.Length; i++)
            {
                Destroy(dest[i]);
            } 
        }
    }
} 



