using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    
    public List<WeaponBehaviour> weapons = new List<WeaponBehaviour>();
    public int selectedWeaponIndex;

  

    


    void Start()
    {
        
        References.thePlayer = gameObject;
        selectedWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = inputVector * speed;
        // WASD to move


        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);
        // Look at cursor position

        Vector3 lookAtPosition = cursorPosition;

        transform.LookAt(lookAtPosition);

        // Face new position


        if (weapons.Count > 0 && Input.GetButton("Fire1"))
        {
            weapons[selectedWeaponIndex].Fire(cursorPosition);

        }

        if (Input.GetButtonDown("Fire2"))
        {
            ChangeWeaponIndex(selectedWeaponIndex + 1);

        }

    }

    private void ChangeWeaponIndex (int index)
    {
        selectedWeaponIndex = index;
        if (selectedWeaponIndex >= weapons.Count)
        {
            selectedWeaponIndex = 0;
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == selectedWeaponIndex)
            {
                weapons[i].gameObject.SetActive(true);
            } else
            {
                weapons[i].gameObject.SetActive(false);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        WeaponBehaviour theirWeapon = other.GetComponentInParent<WeaponBehaviour>();

        if (theirWeapon != null)
        {
            weapons.Add(theirWeapon);
            theirWeapon.transform.position = transform.position;
            theirWeapon.transform.rotation = transform.rotation;
            theirWeapon.transform.SetParent(transform);
            ChangeWeaponIndex(weapons.Count - 1);
        }
    }




}
