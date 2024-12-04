using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 5;
    public Vector3 bulletVec = Vector3.zero;

    void Update()
    {
        // Move the bullet in the (0, 1, 0) direction
        transform.Translate(bulletVec * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().GetDamaged(damage);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().GetDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        bulletVec = Vector3.Normalize(direction);
    }
}
