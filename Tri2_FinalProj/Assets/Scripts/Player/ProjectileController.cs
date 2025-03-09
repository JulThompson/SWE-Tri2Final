using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int velocity = 12;
    public Rigidbody2D rb;
    public BoxCollider2D collider;
    public int pointsForEnemyHit = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        rb.velocity = new Vector2(0, velocity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            ScoreManager.Instance.AddPoints(pointsForEnemyHit);
            Debug.Log("added pts 1");
        }
    }
}
