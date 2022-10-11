using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppercut_attack_boss_state : State
{
    private AI_idle_boss Character;

    bool Grab_bool = false;

    Transform Target = null;


    public Uppercut_attack_boss_state(AI_idle_boss character, StateMachine stateMachine) : base(character, stateMachine)
    {
        Character = character;
    }

    public override void Enter_state()
    {
        base.Enter_state();
        Character.TriggerAnimation(Animator.StringToHash("Training_uppercut"));
        Character.Timer_value = 5f;
        Target = Character.Target;
    }

    public override void Exit_state()
    {
        base.Exit_state();
        Grab_bool = false;
    }


    public override void Logic_Update()
    {
        base.Logic_Update();
        int id_attack = Random.Range(0, 2);

        if (Character.Check_distance_attack && !Grab_bool)
        {
            if(id_attack == 0)
                Character.TriggerAnimation(Animator.StringToHash("Grab_fall"));
            else
                Character.TriggerAnimation(Animator.StringToHash("Uppercut"));

            Grab_bool = true;
        }

        if (Character.Check_Timer && !Grab_bool)
        {

            Character.TriggerAnimation(Animator.StringToHash("Fail"));
                Character.Stunned_start();
        }
        else if(!Grab_bool)
        {
            Vector3 magnite_direction = Character.transform.position - Target.position;
            Target.GetComponent<Rigidbody>().MovePosition(Target.position + magnite_direction * Character.Magnite_force);
            if(!Character.Check_Timer)
            Character.Rotation_target();
        }
    }



}
