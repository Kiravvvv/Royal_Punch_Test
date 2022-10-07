using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State_enum
{
    Idle,
    Attack,
    Stunned,
    Spec_attack
}


public class AI_idle_boss : Game_character_abstract
{
    [Space(20)]
    [Header("��������� �����")]

    [Tooltip("��������� ����� (��� ������ ����� ���� � ����)")]
    [SerializeField]
    float Distance_attack = 10f;

    [HideInInspector]
    [Tooltip("������� ������� ����� ������ � ���������")]
    public float Timer_value = 5f;


    Transform Target = null;


#pragma warning restore 0649

    public Standart_state_boss State_Standing;
    public Attack_boss_state State_Attack;
    public Stomp_attack_boss_state State_Stomp_Attack;
    public Jump_duble_kick_boss_state State_Jump_duble_kick;
    public Scattering_attack_boss_state State_Scattering_attack;
    public Super_punch_attack_boss_state State_Super_punch_attack;
    public Uppercut_attack_boss_state State_Uppercut_attack;
    public Stunned_boss_state State_Stunned;

    protected override void Start()
    {
        base.Start();

        Target = Game_administrator.Instance.Find_out_Player_script.transform;
        Game_administrator.Start_game_event.AddListener(Start_game);

        State_Standing = new Standart_state_boss(this, Movement_SM);
        State_Attack = new Attack_boss_state(this, Movement_SM);
        State_Stomp_Attack = new Stomp_attack_boss_state(this, Movement_SM);
        State_Jump_duble_kick = new Jump_duble_kick_boss_state(this, Movement_SM);
        State_Scattering_attack = new Scattering_attack_boss_state(this, Movement_SM);
        State_Super_punch_attack = new Super_punch_attack_boss_state(this, Movement_SM);
        State_Uppercut_attack = new Uppercut_attack_boss_state(this, Movement_SM);
        State_Stunned = new Stunned_boss_state(this, Movement_SM);

    }

    void Start_game()
    {
        Movement_SM.Initialize(State_Standing);
    }

    protected override void Update()
    {
        base.Update();
    }


    public bool Check_Timer
    {
        get
        {
            bool result = false;

            if (Timer_value > 0)
            {
                Timer_value -= Time.deltaTime;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }


    public bool Check_distance_attack
    {
        get
        {
            bool result = false;

            if (Vector3.Distance(transform.position, Target.position) <= Distance_attack)
            {
                result = true;
            }

            return result;
        }
    }

    public void Rotation_target()
    {
        Quaternion new_rotation = Quaternion.LookRotation(Target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, new_rotation, Speed_rotation);
    }

    public bool Check_rotation_fin
    {
        get
        {
            bool result = false;

            Quaternion new_rotation = Quaternion.LookRotation(Target.position - transform.position, Vector3.up);

            if(transform.rotation == new_rotation)
            {
                result = true;
            }

            return result;
        }
    }

    public void Stunned_start()
    {
        Movement_SM.Change_State(State_Stunned);
    }

    public void Stomp()
    {
        Movement_SM.Change_State(State_Stunned);
    }

    protected override void Dead()
    {
        base.Dead();
        Game_administrator.Instance.End_game(true);
        Anim.enabled = false;
    }

}
