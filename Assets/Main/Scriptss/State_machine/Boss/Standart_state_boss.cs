using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standart_state_boss : State
{
    private AI_idle_boss Character;
    public Standart_state_boss(AI_idle_boss character, StateMachine stateMachine) : base(character, stateMachine)
    {
        Character = character;
    }

    int Random_spec_attack = 0;

    public override void Enter_state()
    {
        Debug.Log("Standart_state_boss");
        base.Enter_state();
        Random_spec_attack = Random.Range(0, 5);
        Character.Timer_value = Random.Range(4, 8);
    }

    public override void Logic_Update()
    {
        base.Logic_Update();
        Character.Rotation_target();

        if (Character.Check_distance_attack)
            State_Machine_script.Change_State(Character.State_Attack);
        else
        {
            if (Character.Check_Timer)
            {
                switch (Random_spec_attack)
                {
                    case 0:
                        State_Machine_script.Change_State(Character.State_Stomp_Attack);
                        break;
                    case 1:
                        State_Machine_script.Change_State(Character.State_Jump_duble_kick);
                        break;
                    case 2:
                        State_Machine_script.Change_State(Character.State_Scattering_attack);
                        break;
                    case 3:
                        State_Machine_script.Change_State(Character.State_Super_punch_attack);
                        break;
                    case 4:
                        State_Machine_script.Change_State(Character.State_Uppercut_attack);
                        break; 
                }

            }
        }
    }

}
