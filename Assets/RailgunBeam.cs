using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunBeam : BulletBehaviour
{

    public LineRenderer myBeam;
    // Start is called before the first frame update
    void Start()
    {

        float beamThickness = 0.3f;
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, References.maxDistanceInALevel, References.wallsLayer);
        float distanceToWall = hitInfo.distance;

        foreach (RaycastHit enemyHitInfo in Physics.SphereCastAll(transform.position, beamThickness, transform.forward, distanceToWall, References.enemiesLayer))
        {
            enemyHitInfo.collider.GetComponentInParent<HealthSystem>().TakeDamage(damage);
        }
        


        myBeam.SetPosition(0, transform.position);
        myBeam.SetPosition(1, hitInfo.point);
        
    }

    protected override void Update()
    {
        base.Update();

        myBeam.endColor = Color.Lerp(myBeam.endColor, Color.clear, 0.05f);
    }

}
