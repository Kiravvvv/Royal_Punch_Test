using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppercut_attack_boss_state : State
{
    private AI_idle_boss Character;
    public Uppercut_attack_boss_state(AI_idle_boss character, StateMachine stateMachine) : base(character, stateMachine)
    {
        Character = character;
    }

    public override void Enter_state()
    {
        base.Enter_state();
        Character.TriggerAnimation(Animator.StringToHash("Training_uppercut"));
        Character.Timer_value = 5f;
    }


    public override void Logic_Update()
    {
        base.Logic_Update();

        if (Character.Check_Timer)
        {
            if (Character.Check_distance_attack)
            {
                Character.TriggerAnimation(Animator.StringToHash("Uppercut"));
            }
            else
            {
                Character.TriggerAnimation(Animator.StringToHash("Fail"));
                Character.Stunned_start();
            }
        }
    }

}
