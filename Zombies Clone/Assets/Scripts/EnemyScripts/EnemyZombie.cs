using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyZombie : MonoBehaviour, IDamage
{
    // Plan to make a state machine of multiple zombie types:

    // Crawler Zombie
    // Runner Zombie
    // Super Runner Zombie

    // This File consists of NORMAL zombie AI, and will be used as a basis for the other zombie enemy types.

    // Enemy Zombie Components
    [Header("----- Zombie Model Components -----")]
    [SerializeField] Renderer zombieModel;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] public Animator zombieAnim;
    [SerializeField] Transform headPos;
    [SerializeField] Collider rightHandCollider;
    [SerializeField] Collider leftHandCollider;
    [SerializeField] Transform playerPosition;

    [Header("----- Zombie Stats -----")]
    [Range(1, 100)][SerializeField] int HP;
    [Range(1, 25)][SerializeField] int playerFaceSpeed;
    [Range(1, 360)][SerializeField] int viewConeAngle;

    [Header("----- Zombie Audio Components -----")]
    [SerializeField] AudioSource zombieAudio;
    [SerializeField] AudioClip[] groanSounds;
    [Range(1, 100)][SerializeField] float zombieVolume;

    // Vars

    Vector3 playerDirection; // Direction of the player
    float stoppingDistance; // Enemy Zombie stopping Distance from player
    float speedOrig;


   

    void Start()
    {
        // Track the original speed of the zombie (If we want to slow or stun a zombie)
        speedOrig = agent.speed;


    }


    void Update()
    {
        
    }

    void FacePlayer()
    {
        Quaternion faceRotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0f, playerDirection.z));

        transform.rotation = Quaternion.Lerp(transform.rotation, faceRotation, Time.deltaTime * playerFaceSpeed);
    }

    public void takeDamage(int dmg)
    {
        HP -= dmg;

        // Play Zombie Hurt Sound Here

        if (HP <= 0)
        {
            StopAllCoroutines();

            // Update that Zombie Dies in the Round Logic Here

            // Set Zombie Animation to False here

            // Stop the zombie agent from moving
            agent.enabled = false;

            // Disable Damage Colliders
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            // Allow the zombie to continue to attack the player.

            // Maybe put some indicator for damage? (Flash red, more groan, etc..)
        }
    }
}
