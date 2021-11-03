using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
   public Slider slider;
   public Gradient Gradient;
   public Image fill;

   public void MaxHealth(int health)
   {
      slider.maxValue = health;
      slider.value = health;
      fill.color=Gradient.Evaluate(1f);
   }
   public void SetHealth(int health)
   {
      slider.value = health;
      fill.color = Gradient.Evaluate(slider.normalizedValue);
   }
}
