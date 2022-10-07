using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : Game_character_abstract
{

    [Tooltip("Цель")]
    [SerializeField]
    Transform Target = null;

    bool Move_bool = false;

    Vector3 Direction_movement = Vector3.zero;

    bool Attack_bool = false;

    protected override void Awake()
    {
        base.Awake();
        Game_administrator.Instance.Add_player_script(this);
        GetComponent<Ragdoll_activity>().Ragdoll_event.AddListener(Active_control);
    }

    protected override void Update()
    {
        base.Update();

        if (Control_bool)
        {
            if (Move_bool && !Attack_bool)
            {
                Movement();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && !Attack_bool)
            {
                Attack_bool = true;
                Anim.SetTrigger("Attack");
            }

            Rotation_target();
        }

    }

    void Rotation_target()
    {
        Quaternion new_rotation = Quaternion.LookRotation(Target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, new_rotation, Speed_rotation);
    }

    void End_attack()
    {
        Anim.ResetTrigger("Attack");
        Attack_bool = false;
        Anim.SetTrigger("Next_attack");
    }

    public override void Active_control(bool _active)
    {
        base.Active_control(_active);

        if (_active)
        {
            Attack_bool = false;
            Anim.ResetTrigger("Attack");
        }
    }

    /// <summary>
    /// Передвижение
    /// </summary>
    void Movement()
    {
        //Body.MovePosition(My_transform.position + Direction_movement * Speed_movement);
        Vector3 direction_pos = My_transform.forward * Direction_movement.z + My_transform.right * Direction_movement.x; 

        Body.MovePosition(My_transform.position + direction_pos * Speed_movement);
    }


    public void New_direction(Vector2 _direction)
    {
        Direction_movement = new Vector3(_direction.x, 0, _direction.y);

        if (_direction != Vector2.zero)
        {
            Move_bool = true;
        }
        else
        {
            Move_bool = false;
        }

        Anim.SetBool("Move", Move_bool);
        Anim.SetFloat("Move_X", _direction.x);
        Anim.SetFloat("Move_Y", _direction.y);
    }

}
