using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Enemy HP: " + health);

        if (health <= 0f)
        {
            Die();
        }

        // Null check added to ensure the GameObject is valid before using it.
        if (gameObject != null)
        {
            StartCoroutine(changeColor(gameObject));
        }

    }

    void Die()
    {
        Destroy(gameObject);  // Removes the enemy 
    }

    private IEnumerator changeColor(GameObject go)
    {

            go.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
            go.GetComponent<Renderer>().material.color = Color.green;
            yield break;

    }

}
