using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class References
{

    public static GameObject thePlayer;
    public static GameObject canvas;
    public static EnemySpawner spawner;
    public static Screenshake screenShake;

    public static float maxDistanceInALevel = 1000;

    public static LayerMask wallsLayer = LayerMask.GetMask("Walls");
    public static LayerMask enemiesLayer = LayerMask.GetMask("Enemies");




}
