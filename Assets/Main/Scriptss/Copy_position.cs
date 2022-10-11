using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy_position : MonoBehaviour
{

    [Tooltip("���� ��������")]
    [SerializeField]
    Transform Target = null;

    [Tooltip("��������� ������ ����� ����, ��� �� ������������")]
    [SerializeField]
    float Distance_activation = 10f;

    [Tooltip("���� �������� �������� ��������")]
    [SerializeField]
    bool Target_children = false;

    void LateUpdate()
    {
        if (Vector3.Distance(Target.position, transform.position) >= Distance_activation)
        {
            transform.position = Target.position;

            if (Target_children)
                Target.localPosition = Vector3.zero;
        }
            
    }
}
