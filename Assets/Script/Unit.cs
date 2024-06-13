using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   public float currentHealth;
   public float maxHealth;
   public float speed;

   public float movmentDirection;
   
   

   private void Update()
   {
      Movment();
   }

   public void Movment()
   {
      transform.position += Vector3.right * movmentDirection * speed * Time.deltaTime;
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      var unit = other.collider.GetComponent<Unit>();
      StartCoroutine(AttackNum(unit));
   }

   IEnumerator AttackNum(Unit unit)
   {
      while (unit.gameObject)
      {
         unit.currentHealth -= 10;

         if (unit.currentHealth <= 0)
         {
            Destroy(unit.gameObject);
         }

         yield return new WaitForSeconds(1);
      }
   }
   
}
