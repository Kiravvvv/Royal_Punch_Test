using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_boss_state : State
{
    private int Attack_anim_id = Animator.StringToHash("Attack");

    private AI_idle_boss Character;
    public Attack_boss_state(AI_idle_boss character, StateMachine stateMachine) : base(character, stateMachine)
    {
        Character = character;
    }

    public override void Enter_state()
    {
        Debug.Log("Attack_boss_state");
        base.Enter_state();
    }

    public override void Logic_Update()
    {
        base.Logic_Update();
        if (!Character.Check_rotation_fin)
        {
            State_Machine_script.Change_State(Character.State_Standing);
        }
        else
        {
            Character_script.TriggerAnimation(Attack_anim_id);

            if(!Character.Check_distance_attack)
                State_Machine_script.Change_State(Character.State_Standing);
        }
    }


}
