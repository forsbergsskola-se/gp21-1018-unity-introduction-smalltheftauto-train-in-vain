using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLifespan : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
