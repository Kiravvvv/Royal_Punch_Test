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

            Vector3 direction = _health.transform.position - My_health.transform.position;
            _health.GetComponent<Ragdoll_activity>().Add_impulse_ragdoll(direction.normalized + Vector3.up * 2, 12, ForceMode.Impulse);

            if (PS_punch != null)
            PS_punch.Play();
        }
    }
}
