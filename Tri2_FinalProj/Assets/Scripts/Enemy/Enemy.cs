using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected IFallBehavior fallBehavior;

    // Assign the fall behavior dynamically
    public void SetFallBehavior(IFallBehavior fallBehavior)
    {
        this.fallBehavior = fallBehavior;
    }

    void Start(){
        Fall();
    }

    void Update(){
        Debug.Log("update is running");
    }

    // Call the Fall method for the current behavior
public void Fall()
{
    if (fallBehavior != null)
    {
        Debug.Log("Calling fall behavior for " + gameObject.name);
        fallBehavior.Fall(gameObject); // Calling the fall method of the behavior
    }
    else
    {
        Debug.LogError("No fall behavior set for " + gameObject.name);
    }
}

    public abstract void PerformSpecialAction();  // Abstract method for specific enemy actions
}
