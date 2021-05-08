using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float healthPoints;

    [FMODUnity.EventRef]
    [SerializeField]
    string deathSound;

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
        FMODUnity.RuntimeManager.PlayOneShot(deathSound, transform.position);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
