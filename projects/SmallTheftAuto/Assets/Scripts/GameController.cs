using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject phoneBox;
    void Start()
    {
        Instantiate(player);
        Instantiate(phoneBox).transform.position=new Vector3(-0.519f, 41.2f,0f);
    }

    void Update()
    {
        //
    }
}
