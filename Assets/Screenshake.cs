using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{

    Vector3 normalPosition;
    Vector3 desiredPosition;

    public Vector3 joltVector;
    public float shakeAmount;

    public float shakeDecayFactor;
    public float joltDecayFactor;

    public float maxMoveSpeed;


    private void Awake()
    {
        References.screenShake = this;
    }
    void Start()
    {
        normalPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 shakeVector = new Vector3(GetRandomShakeAmount(), GetRandomShakeAmount(), GetRandomShakeAmount());
        desiredPosition = normalPosition + joltVector + shakeVector;

        //Set our position to the jolted position
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, maxMoveSpeed * Time.deltaTime);

        //Jolt vectore decreases
        joltVector *= joltDecayFactor;
        shakeAmount *= shakeDecayFactor;
    }

    float GetRandomShakeAmount()
    {
        return Random.Range(-shakeAmount, shakeAmount);
    }
}
