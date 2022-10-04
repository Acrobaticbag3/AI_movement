using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    //Transform that NPC has to follow
    public Transform transformToFollow;
 
    //NavMesh Agent variable
    NavMeshAgent agent;
 
    public float enemyDistance = 1.0f;
 
    // Start is called before the first frame update
    void Start() {
       agent = GetComponent<NavMeshAgent>();
    }
 
    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(transform.position, agent.transform.position);
 
        if (distance < enemyDistance) {
            //Follow the player
            Vector3.Distance(transform.position, transformToFollow.transform.position);
        }
    }
}
