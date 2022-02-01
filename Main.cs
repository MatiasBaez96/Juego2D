using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    Shooting ShootingIns = new Shooting();
    MovementsFuntions movementsFuntios = new MovementsFuntions();

    void Update()
    {
        movementsFuntios.MovementsCheck();
        ShootingIns.SideShots();
    }
}

