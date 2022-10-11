using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned_boss_state : State
{
    private int Stunned_attack_anim_id = Animator.StringToHash("Stunned");

    private AI_idle_boss Character;
    public Stunned_boss_state(AI_idle_boss character, StateMachine stateMachine) : base(character, stateMachine)
    {
        Character = character;
    }

    public override void Enter_state()
    {
        Debug.Log("Stunned_boss_state");
        base.Enter_state();
        Character.Timer_value= 6f;
        Character.SetAnimationBool(Stunned_attack_anim_id, true);

    }

    public override void Exit_state()
    {
        base.Exit_state();
        Character.SetAnimationBool(Stunned_attack_anim_id, false);
    }

    public override void Logic_Update()
    {
        base.Logic_Update();

        if (Character.Check_Timer)
        {
            State_Machine_script.Change_State(Character.State_Standing);
        }
    }

}
