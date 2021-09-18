using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float speed;
    public Rigidbody ourRigidBody;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        ourRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        ChasePlayer();
        
    }

    protected void ChasePlayer()
    {
        if (References.thePlayer != null)
        {


            Vector3 playerPosition = References.thePlayer.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;
            ourRigidBody.velocity = vectorToPlayer.normalized * speed;
            Vector3 playerPositionAtOurHeight = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            transform.LookAt(playerPositionAtOurHeight);

            // Follow the player



        }
    }


    protected void OnCollisionEnter(Collision thisCollision)
    {
        GameObject theirGameObject = thisCollision.gameObject;

        if (theirGameObject.GetComponent<PlayerBehaviour>() != null)
        {
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
            if (theirHealthSystem != null)
            {
                theirHealthSystem.TakeDamage(1);

            }

        }


    }
}
