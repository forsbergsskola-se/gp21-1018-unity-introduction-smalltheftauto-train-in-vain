using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPhoneBoxInteraction : MonoBehaviour
{
    // private const float RangeToGetIn = 5f;
    // private const KeyCode PhoneBoxInteractKey = KeyCode.F;
    // private List<GameObject> phoneBoxInScene;
    // private GameObject targetPhoneBox;
    //
    //
    // private GameObject QuestUi;
    //
    //
    // void Start()
    // {
    //     phoneBoxInScene = GameObject.FindGameObjectsWithTag("PhoneBox").ToList();
    //     QuestUi = GameObject.FindGameObjectWithTag("QuestUi");
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     if (gameObject.activeInHierarchy && phoneBoxInRange()&& Input.GetKeyDown(PhoneBoxInteractKey) )
    //     {
    //         PhoneBox();
    //     }
    // }
    //
    // private void PhoneBox()
    // {
    //     targetPhoneBox.GetComponent<PhoneBoxInteraction>().EnterPhoneBox();
    // }
    //
    // private bool phoneBoxInRange()
    // {
    //     var result = false;
    //     var lenght = phoneBoxInScene.Count;
    //     for (int i = 0; i < lenght; i++)
    //     {
    //         result = Vector3.Distance(gameObject.transform.position, phoneBoxInScene[i].gameObject.transform.position) <= RangeToGetIn;
    //         if (result)
    //         {
    //             targetPhoneBox = phoneBoxInScene[i];
    //             break;
    //         }
    //     }
    //
    //     return result;
    // }
}
