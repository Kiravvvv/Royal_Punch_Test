using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_tracking : MonoBehaviour
{
    [Tooltip("���� ��� ��������")]
    [SerializeField]
    Transform Target = null;

    [Tooltip("�������� ������")]
    [SerializeField]
    Vector3 Offset = Vector3.zero;

    [Tooltip("������� �� ��� �")]
    [SerializeField]
    bool Follow_X_bool = false;

    [Tooltip("������� �� ��� Y")]
    [SerializeField]
    bool Follow_Y_bool = false;

    [Tooltip("������� �� ��� Z")]
    [SerializeField]
    bool Follow_Z_bool = true;

    [Tooltip("������ �� ���������")]
    [SerializeField]
    bool Rotation_bool = false;

    [Tooltip("���� � ������� ������� ����� ��������")]
    [SerializeField]
    Transform Target_look = null;

    [Tooltip("�������� ������ �� �������")]
    [SerializeField]
    Vector3 Offset_rotation = Vector3.zero;

    [Tooltip("������������ ������ ������ ������������� �����������")]
    [SerializeField]
    bool Movement_bool = false;

    [Tooltip("�������� �����������")]
    [SerializeField]
    float Speed_movement = 0.2f;

    [Tooltip("�������� ��������")]
    [SerializeField]
    float Speed_rotation = 2f;


    [Tooltip("����� ��������������")]
    [SerializeField]
    bool Debug_mode = false;

    void LateUpdate()
    {
        Movement_to_target();
    }

    /// <summary>
    /// ������� ������ � ����
    /// </summary>
    void Movement_to_target()
    {
        if (Target)
        {
            Vector3 target_vector = Vector3.zero;

            if (Rotation_bool)
            {
                if (Target_look)
                {
                    target_vector += (Target_look.position - new Vector3(Target.position.x, Target.position.y, Target.position.z)).normalized * Offset.z;
                }
                else
                {
                    target_vector += Target.forward * Offset.z;
                }

                target_vector += Target.right * Offset.x;
                target_vector += Target.up * Offset.y;

                if (Movement_bool)
                {


                    transform.position = Vector3.MoveTowards(transform.position, Target.transform.position + target_vector, Speed_movement);

                    if (Target_look)
                    {
                        Vector3 fin_rotation = Quaternion.LookRotation(new Vector3(Target_look.position.x, transform.position.y, Target_look.position.z) - transform.position).eulerAngles;
                        fin_rotation += Offset_rotation;

                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(fin_rotation), Speed_rotation);
                    }
                    else
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Target.eulerAngles + Offset_rotation), Speed_rotation);
                    //transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, Target.eulerAngles + Offset_rotation, Speed_rotation);
                }
                else
                {
                    transform.position = Target.transform.position + target_vector;

                    if (Target_look)
                    {
                        transform.rotation = Quaternion.LookRotation(new Vector3(Target_look.position.x, transform.position.y, Target_look.position.z) - transform.position);
                        transform.eulerAngles += Offset_rotation;
                    }
                        
                    else
                        transform.eulerAngles = Target.eulerAngles + Offset_rotation;
                }

            }
            else
            {
                if (Follow_X_bool)
                    target_vector.x = Target.position.x;
                if (Follow_Y_bool)
                    target_vector.y = Target.position.y;
                if (Follow_Z_bool)
                    target_vector.z = Target.position.z;


                Vector3 target_position = target_vector + Offset;

                if(Movement_bool)
                    transform.position = Vector3.MoveTowards(transform.position, target_position, Speed_movement);
                else
                transform.position = target_position;

            }

        }
    }

    public void New_target(Transform _target)
    {
        Target = _target;
    }


    private void OnDrawGizmos()
    {
        if (Target && Debug_mode)
        {

            Vector3 target_vector = Vector3.zero;

            if (Follow_X_bool)
                target_vector.x = Target.position.x;
            if (Follow_Y_bool)
                target_vector.y = Target.position.y;
            if (Follow_Z_bool)
                target_vector.z = Target.position.z;

            transform.position = target_vector + Offset;

            if (Rotation_bool)
            {
                transform.eulerAngles = Target.eulerAngles + Offset_rotation;
            }

        }
    }

}

