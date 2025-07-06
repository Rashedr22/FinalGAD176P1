using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
  

      [SerializeField] GameObject enemy;
      [SerializeField] float speed;
    void Start()
    {
        
    }
      
          

  void Update()
      {
          //T-C
          Vector3 direction = enemy.transform.position - transform.position;
         transform.position += direction.normalized * speed * Time.deltaTime;

      }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.name);

        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(10f);
                Debug.Log("You have been damaged via trigger");
            }
        }
    }

}
