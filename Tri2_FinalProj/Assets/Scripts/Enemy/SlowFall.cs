using UnityEngine;

public class SlowFall : IFallBehavior
{
    public void Fall(GameObject enemy)
    {
        Debug.Log("Slow falling");
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0.1f;
        }
    }
}
