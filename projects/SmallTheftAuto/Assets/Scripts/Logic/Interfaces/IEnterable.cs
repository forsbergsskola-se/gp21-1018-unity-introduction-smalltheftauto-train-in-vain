using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IEnterable
{
    public void Enter(GameObject User);
    public void Exit();
}
