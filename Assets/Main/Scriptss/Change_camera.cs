using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_camera : Singleton<Change_camera>
{

    [Tooltip("Камера следит за игроком")]
    [SerializeField]
    Camera_tracking Camera_player = null;

    [Tooltip("Камера следит за босом")]
    [SerializeField]
    Camera_tracking Camera_boss = null;

    public void Active_player_camera()
    {
        Camera_player.enabled = true;
        Camera_boss.enabled = false;
    }

    public void Active_boss_camera()
    {
        Camera_player.enabled = false;
        //Camera_boss.enabled = true;
    }

}
