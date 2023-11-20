using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyZombie : MonoBehaviour
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
}
