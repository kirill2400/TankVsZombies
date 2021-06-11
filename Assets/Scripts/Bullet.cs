using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    protected override void FixedUpdate()
    {
        Transform.Translate(Transform.forward * (BulletSpeed * Time.fixedDeltaTime), Space.World);
    }
}
