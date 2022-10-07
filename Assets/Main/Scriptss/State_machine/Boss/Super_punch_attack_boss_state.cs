using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super_punch_attack_boss_state : State
{
    private AI_idle_boss Character;
    public Super_punch_attack_boss_state(AI_idle_boss character, StateMachine stateMachine) : base(character, stateMachine)
    {
        Character = character;
    }

    public override void Enter_state()
    {
        base.Enter_state();
        Character.TriggerAnimation(Animator.StringToHash("Training_super_punch"));
        Character.Timer_value = 2;
    }


    public override void Logic_Update()
    {
        base.Logic_Update();

        if (Character.Check_Timer)
        {
            Character.TriggerAnimation(Animator.StringToHash("Super_punch"));
        }
    }

}
