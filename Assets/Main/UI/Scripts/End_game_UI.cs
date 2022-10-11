using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_game_UI : MonoBehaviour
{
    [Tooltip("���� ��������� ����")]
    [SerializeField]
    GameObject Canvas_game_wins = null;

    [Tooltip("���� ����������� ����")]
    [SerializeField]
    GameObject Canvas_game_lose = null;


    private void Start()
    {
        Game_administrator.End_game_event.AddListener(Game_end);
    }

    /// <summary>
    /// ����� ����
    /// </summary>
    /// <param name="_win">�������� ��� ���������</param>
    void Game_end(bool _win)
    {
        if (_win)
            Invoke("Delay_End_game_win", 0.5f);
        else
            Invoke("Delay_End_game_lose", 0.5f);

        Game_Player.Cursor_player(true);
    }


    /// <summary>
    /// ��������� ���� � ���� ������ (������� ��� ��������)
    /// </summary>
    void Delay_End_game_win()
    {
        Canvas_game_wins.SetActive(true);
    }

    /// <summary>
    /// ��������� ���� � ���� ��������� (������� ��� ��������)
    /// </summary>
    void Delay_End_game_lose()
    {
        Canvas_game_lose.SetActive(true);
    }

}
