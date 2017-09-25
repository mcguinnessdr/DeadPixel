using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class PowerClear : Power {

    public float radius;
    public override void Use()
    {
        var colliders = Physics2D.OverlapCircleAll(Player.player.transform.position, radius);
        colliders.Where(collider => collider.name == "DeadPlayer(Clone)").All(deadPlayer => { Destroy(deadPlayer.gameObject); return true; });
    }
}
