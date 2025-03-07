using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Enemy : MonoBehaviour
{
    protected IFallBehavior fallBehavior;
    private float destroyThreshold = -6f;

    // Assign the fall behavior dynamically
    public void SetFallBehavior(IFallBehavior fallBehavior)
    {
        this.fallBehavior = fallBehavior;
    }

    void Start(){
        Fall();
    }

    void Update(){
        if (transform.position.y < destroyThreshold)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    // Call the Fall method for the current behavior
public void Fall()
{
    if (fallBehavior != null)
    {
        fallBehavior.Fall(gameObject); // Calling the fall method of the behavior
    }
    else
    {
        Debug.LogError("No fall behavior set for " + gameObject.name);
    }
}

    public abstract void PerformSpecialAction();  // Abstract method for specific enemy actions
}
