using UnityEngine;

public class NormalEnemy : Enemy
{
    public override void PerformSpecialAction()
    {
        Debug.Log("Normal enemy performs a special action!");
    }
}
