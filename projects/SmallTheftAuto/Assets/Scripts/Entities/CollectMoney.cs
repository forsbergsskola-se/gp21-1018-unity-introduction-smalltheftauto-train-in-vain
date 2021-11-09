using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{
   private PlayerController playerController;
   private SpriteRenderer spriteRenderer;
   public Sprite hundredDollars;
   public Sprite fiftyDollars;
   public Sprite tenDollars;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         PickUpMoney();
      }
   }
   
   void PickUpMoney()
   {
      playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
      spriteRenderer = GetComponent<SpriteRenderer>();
      

      if (spriteRenderer.sprite == hundredDollars)
      {
         playerController.addMoney(100);
      }
      
      else if (spriteRenderer.sprite == fiftyDollars)
      {
         playerController.addMoney(50);
      }
      
      else if (spriteRenderer.sprite == tenDollars)
      {
         playerController.addMoney(10);
      }
      else
      {
         Debug.Log("Something is wrong");
      }
      
      Destroy(gameObject);
   }
}
