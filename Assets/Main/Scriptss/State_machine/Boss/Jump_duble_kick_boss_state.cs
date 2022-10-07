using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_duble_kick_boss_state : State
{
    private AI_idle_boss Character;
    public Jump_duble_kick_boss_state(AI_idle_boss character, StateMachine stateMachine) : base(character, stateMachine)
    {
        Character = character;
    }

    public override void Enter_state()
    {
        base.Enter_state();
        Character.TriggerAnimation(Animator.StringToHash("Jump_duble_kick"));
    }

}
