using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp_attack_boss_state : State
{

    private int Stomp_attack_anim_id = Animator.StringToHash("Stomp_attack");

    private AI_idle_boss Character;
    public Stomp_attack_boss_state(AI_idle_boss character, StateMachine stateMachine) : base(character, stateMachine)
    {
        Character = character;
    }

    public override void Enter_state()
    {
        Debug.Log("Stomp_attack_boss_state");
        base.Enter_state();
        Character.TriggerAnimation(Stomp_attack_anim_id);
    }
}
