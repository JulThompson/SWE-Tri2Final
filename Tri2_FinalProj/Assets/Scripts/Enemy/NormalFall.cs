using UnityEngine;

public class NormalFall : IFallBehavior
{
    public void Fall(GameObject enemy)
    {
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0.25f;
        }
    }
}