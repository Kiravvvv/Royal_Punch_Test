using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

/*
[CustomEditor(typeof(Camera_control))]
public class GUI_Camera_control : Editor
{
    public override void OnInspectorGUI()
    {

        Camera_control C_c = (Camera_control)target;

        
        C_c.Target = EditorGUILayout.ObjectField(new GUIContent("Target", "���� ������"), C_c.Target, typeof(Transform), true) as Transform;
        C_c.Behind_target_bool = EditorGUILayout.Toggle(new GUIContent("Behind_target", "����� ��������� ����� ����"), C_c.Behind_target_bool);

        if (C_c.Behind_target_bool)
        {
            EditorGUILayout.BeginVertical("box");

            C_c.Height = EditorGUILayout.FloatField(new GUIContent("Height", "������ ������"), C_c.Height);
            C_c.Zoom = EditorGUILayout.FloatField(new GUIContent("Zoom", "����������� ������"), C_c.Zoom);

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }
        else
        {
            EditorGUILayout.BeginVertical("box");

            C_c.Offset = EditorGUILayout.Vector3Field(new GUIContent("Offset", "�������� ������"), C_c.Offset);

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        C_c.Speed = EditorGUILayout.FloatField(new GUIContent("Speed", "�������� ����������� � ����"), C_c.Speed);

        C_c.Mouse_control_bool = EditorGUILayout.Toggle(new GUIContent("Behind_target", "����� �� ����� ������ ������� ������"), C_c.Mouse_control_bool);

        if (C_c.Mouse_control_bool)
        {
            EditorGUILayout.BeginVertical("box");

            C_c.Speed_rotation = EditorGUILayout.FloatField(new GUIContent("Speed_rotation", "�������� ��������"), C_c.Speed_rotation);
            C_c.Axis_X = EditorGUILayout.ObjectField(new GUIContent("Axis_X", "�������� ������ ��� �������� �� ���������"), C_c.Axis_X, typeof(Transform), true) as Transform;

            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }


        if (GUI.changed)//��������� ��� �� ������������ � ���������� ����� ����� �������������� � ���������� 
        {
            EditorUtility.SetDirty(C_c.gameObject);
            EditorSceneManager.MarkSceneDirty(C_c.gameObject.scene);
        }


    }
}
*/