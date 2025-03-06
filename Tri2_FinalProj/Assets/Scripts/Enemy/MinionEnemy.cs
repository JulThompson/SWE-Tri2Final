using UnityEngine;

public class MinionEnemy : Enemy
{
    public override void PerformSpecialAction()
    {
        Debug.Log("Minion enemy performs a special action!");
    }
}
