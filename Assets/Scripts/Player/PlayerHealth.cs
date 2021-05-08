using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float healthPoints;

    public void takeDamage(float amount)
    {
        healthPoints -= amount;
        if (healthPoints <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
