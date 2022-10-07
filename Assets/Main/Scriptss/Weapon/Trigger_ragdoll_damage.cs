using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_ragdoll_damage : Trigger_damage
{
    protected override void Damage_method(Health _health)
    {
        if (_health != null && _health != My_health)
        {
            _health.Damage(Damage, true);
            if(PS_punch != null)
            PS_punch.Play();
        }
    }
}
