using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Barrel : MonoBehaviour, I_damage
{

    [Tooltip("������� ������")]
    [SerializeField]
    GameObject PS_explosion_prefab = null;
    
    [Tooltip("������ ����������� ������")]
    [SerializeField]
    float Radius_explosion = 2f;

    [Tooltip("���� ������")]
    [SerializeField]
    float Force_explosion = 8f;

    [Tooltip("������� ������")]
    [SerializeField]
    SphereCollider Trigger_explosion = null;

    [Space(20)]
    [Header("������")]

    [Tooltip("�������� ������ ������")]
    [SerializeField]
    bool Explosiont_start = false;

    [Tooltip("����� ������� (���������� ������ ��� �����������)")]
    [SerializeField]
    bool Debug_bool = false;

    private void Awake()
    {
        Trigger_explosion.enabled = false;
    }

    private void Start()
    {
        if (Explosiont_start)
            Explosion();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<I_damage>() != null)
        {
            print(other.name);
            other.GetComponent<I_damage>().Damage();
        }
    }

    /// <summary>
    /// ���������� �����
    /// </summary>
    void Explosion_impulse()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, Radius_explosion);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(Force_explosion, explosionPos, Radius_explosion, 3.0F, ForceMode.Impulse);
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// �������� ����
    /// </summary>
    public void Damage()
    {
        Explosion();
    }

    /// <summary>
    /// �����
    /// </summary>
    void Explosion()
    {
        Instantiate(PS_explosion_prefab, transform.position, Quaternion.identity);
        Trigger_explosion.enabled = true;

        Invoke(nameof(Explosion_impulse), 0.1f);
    }

    private void OnDrawGizmos()
    {
        if (Trigger_explosion.radius != Radius_explosion)
        {
            Trigger_explosion.radius = Radius_explosion;
        }

        if (Debug_bool)
        {
            Gizmos.color = new Color(1, 0, 0, 0.2f);
            Gizmos.DrawSphere(transform.position, Radius_explosion);
        }

    }
}
