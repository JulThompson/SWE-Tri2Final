using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    public void handleSpace();
    public void advanceState();
}
