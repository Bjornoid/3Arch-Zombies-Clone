using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour, IDamage
{
    [Header("----- Survivability Stats -----")]
    [SerializeField] int playerHealth;



    private int healthOrig;
  
    void Start()
    {
        // health to reset to after revived
        healthOrig = playerHealth;
    }

    void Update()
    {
        
    }

    public void takeDamage(int dmg)
    {
        playerHealth -= dmg;
        if (playerHealth <= 0 )
        {
            // die
        }
    }
}
