//���������
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : MonoBehaviour
{

    [Tooltip("����� ������ ����")]
    [SerializeField]
    Transform Fire_point = null;

    [Tooltip("������ ����")]
    [SerializeField]
    GameObject Bullet_prefab = null;

    /// <summary>
    /// ����������
    /// </summary>
    public void Fire()
    {
        if(gameObject.activeSelf)
        Instantiate(Bullet_prefab, Fire_point.position, Fire_point.rotation);
    }

    public void Fire(Vector3 _vector)
    {
        if (gameObject.activeSelf)
        {

            Fire_point.transform.LookAt(_vector, Fire_point.up);


            Instantiate(Bullet_prefab, Fire_point.position, Fire_point.rotation);
        }
           
    }

}
