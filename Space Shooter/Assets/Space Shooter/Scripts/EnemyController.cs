using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int EnemyHealth = 10;

    public void GetDamaged(int damage)
    {
        EnemyHealth -= damage;
        if (EnemyHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
