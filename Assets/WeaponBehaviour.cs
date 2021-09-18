using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float secondsBetweenShots;
    public float accuracy;
    public float numberOfProjectiles;
    public AudioSource audioSource;
    public float kickAmount;

    float secondsSinceLastShot;


    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBetweenShots;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastShot += Time.deltaTime;

        //Fire rate

        
    }

    public void Fire(Vector3 targetPosition)
    {
        if (secondsSinceLastShot >= secondsBetweenShots)
        {
            References.spawner.activated = true;
            audioSource.Play();
            References.screenShake.joltVector = transform.forward * kickAmount;


            for (int i = 0; i < numberOfProjectiles; i++) 
            {
                GameObject newBullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
                Vector3 inaccuratePosition = targetPosition;
                float inaccuracy = Vector3.Distance(transform.position, targetPosition) / accuracy;
                inaccuratePosition.x += Random.Range(-inaccuracy, inaccuracy);
                inaccuratePosition.z += Random.Range(-inaccuracy, inaccuracy);
                newBullet.transform.LookAt(inaccuratePosition);
                secondsSinceLastShot = 0;

            }

           

        }
        //Click to fire
    }
}
