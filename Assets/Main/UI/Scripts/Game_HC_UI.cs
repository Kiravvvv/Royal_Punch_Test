using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_HC_UI : Singleton<Game_HC_UI>
{
    [Tooltip("��������� ������")]
    [SerializeField]
    GameObject Start_panel = null;

    [Tooltip("������� ������ (�� ����� �������� ����)")]
    [SerializeField]
    GameObject Game_panel = null;

    [Tooltip("������ ����� ���� (������)")]
    [SerializeField]
    GameObject End_panel_win = null;

    [Tooltip("������ ����� ���� (���������)")]
    [SerializeField]
    GameObject End_panel_lose = null;



    [Space(20)]
    [Header("������")]

    [Tooltip("���������� ������")]
    [SerializeField]
    Image Health_image = null;

    private void Start()
    {
        All_off_panels();
        Start_panel.SetActive(true);
        Game_administrator.Player_Health_info_event.AddListener(Change_health);
    }

    /// <summary>
    /// ��������� ��� ������
    /// </summary>
    void All_off_panels()
    {
        Start_panel.SetActive(false);
        Game_panel.SetActive(false);
        End_panel_win.SetActive(false);
        End_panel_lose.SetActive(false);
    }


    public void Start_game()
    {
        Game_administrator.Instance.Start_game();
        All_off_panels();
        Game_panel.SetActive(true);
    }


    /// <summary>
    /// �������� ���������� ������
    /// </summary>
    /// <param name="_value">�������� �� 0 �� 1</param>
    public void Change_health(float _value)
    {
        Health_image.fillAmount = _value;
    }

}
