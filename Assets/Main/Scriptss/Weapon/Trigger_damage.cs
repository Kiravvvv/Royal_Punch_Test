//Триггер нанесения урона
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_damage : MonoBehaviour
{

    [Tooltip("Здоровье владельца")]
    [SerializeField]
    protected Health My_health = null;

    [Tooltip("Нанесения урона")]
    [SerializeField]
    protected int Damage = 1;

    [Tooltip("СЧ при попадание")]
    [SerializeField]
    protected ParticleSystem PS_punch = null;

    private void OnTriggerEnter(Collider other)
    {
        Damage_method(other.GetComponent<Health>());
    }

    protected virtual void Damage_method(Health _health)
    {

        if (_health != null && _health != My_health)
        {
            _health.Damage_add(Damage, null);

            if (PS_punch != null)
            PS_punch.Play();
        }
    }
}
