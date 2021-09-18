using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBehaviour : EnemyBehaviour
{
    
    
    public float visionRange;
    public float visionConeAngle;
    public bool alerted;
    
    public Light myLight;
    public float turnSpeed;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        alerted = false;
        int randomNavPointIndex = Random.Range(0, References.navPoints.Count);
        navAgent.destination = References.navPoints[randomNavPointIndex].transform.position;
        
    }

    void GoToRandomNavPoint()
    {
        int randomNavPointIndex = Random.Range(0, References.navPoints.Count);
        navAgent.destination = References.navPoints[randomNavPointIndex].transform.position;
    }
    // Update is called once per frame
    protected override void Update()
    {
       
        
        if (References.thePlayer != null) 
        {

         
         Vector3 playerPosition = References.thePlayer.transform.position;
         Vector3 vectorToPlayer = playerPosition - transform.position;
         myLight.color = Color.white;
            

            if (alerted)
            {
                myLight.color = Color.red;
                ChasePlayer();


            } else
            {

                if (navAgent.remainingDistance < 0.5f)
                {
                    GoToRandomNavPoint();
                }
                //Rotate
                Vector3 lateralOffset = transform.right * Time.deltaTime;
                transform.LookAt(transform.position + transform.forward + lateralOffset * turnSpeed);
                ourRigidBody.velocity = transform.forward * speed;

                //Checking if we can see the player
                if (Vector3.Distance(transform.position, playerPosition) <= visionRange)
                {
                    if (Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle)
                    {
                        

                        if (Physics.Raycast(transform.position, vectorToPlayer, vectorToPlayer.magnitude, References.wallsLayer) == false)
                        {
                            //First time we see the player

                            alerted = true;
                            References.spawner.activated = true;

                        }
                        
                      
                    }
                }

            }

      }
    }

    
}
