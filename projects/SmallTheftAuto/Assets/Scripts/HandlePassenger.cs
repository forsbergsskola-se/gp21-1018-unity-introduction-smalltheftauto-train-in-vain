using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePassenger : MonoBehaviour
{
    public GameObject Player;

    public void Enter()
    {
        Player.SetActive(false);
    }

    public void Exit()
    {
        Player.SetActive(true);
    }
}
