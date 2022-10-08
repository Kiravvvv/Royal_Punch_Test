﻿//Набор параметров для персонажей
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]//Атрибут добавляющий здоровье
[RequireComponent(typeof(Rigidbody))]
public abstract class Game_character_abstract : Game_object_abstract
{
    #region Variables

    public StateMachine Movement_SM;

#pragma warning disable 0649

    [Space(20)]
    [Header("Настройки персонажа")]

    [Tooltip("Голова (если есть)")]
    [SerializeField]
    protected Transform Head = null;

    [Tooltip("Главная кость (если есть)")]
    [SerializeField]
    protected Transform Main_bone = null;

    [Tooltip("Скорость")]
    [SerializeField]
    protected float Speed_movement = 0.1f;

    protected float Speed_movement_default = 0;//Параметр скорости с которым работаем

    [Tooltip("Скорость поворота")]
    [SerializeField]
    protected float Speed_rotation = 1f;

    [Tooltip("Сила прыжка")]
    [SerializeField]
    protected float Jump_force = 100f;

    protected Rigidbody Body = null;//Физика

    protected Health Health_script = null;//Скрипт здоровья

    protected bool Control_bool = true;//Контролирует ли игрок персонажа
    protected bool Grounded_bool = true;//Стоит ли на замле
    #endregion

    #region MonoBehaviour Callbacks
    protected virtual void Awake()
    {
        Health_script = GetComponent<Health>();
        Body = GetComponent<Rigidbody>();

        Movement_SM = new StateMachine();

       // Standing = new Standart_state(this, Movement_SM);

       // Movement_SM.Initialize(Standing);
    }

    protected override void Start()
    {
        base.Start();

        Speed_movement_default = Speed_movement;
        Health_script.Dead_event.AddListener(Dead);
    }

    protected virtual void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Ground")
        {
            Grounded_bool = true;
        }
    }



    protected virtual void Update()
    {
        if (Movement_SM.Current_State != null)
        {
            Movement_SM.Current_State.Handle_Input();
            Movement_SM.Current_State.Logic_Update();
        }

    }

    protected virtual void FixedUpdate()
    {
        if(Movement_SM.Current_State != null)
        Movement_SM.Current_State.Physics_Update();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Включить/отключить контроль персонажем
    /// </summary>
    /// <param name="_active">Активность</param>
    public virtual void Active_control(bool _active)
    {
        Control_bool = _active;
    }

    /// <summary>
    /// Жизни закончились
    /// </summary>
    protected virtual void Dead()
    {
        Control_bool = false;
    }

    /// <summary>
    /// Нас захватили
    /// </summary>
    public void I_grab_activity()
    {
        GetComponent<Ragdoll_activity>().Activity_base_collider_and_rigibody(false);
        Control_bool = false;
    }


    /// <summary>
    /// Получить трансфорт главной кости
    /// </summary>
    public Transform Get_find_Main_bone
    {
        get
        {
            return Main_bone;
        }
    }

    /// <summary>
    /// Включить в аниматоре анимацию с булевой переменной
    /// </summary>
    /// <param name="param">Id</param>
    /// <param name="value">включение и отключение</param>
    public void SetAnimationBool(int param, bool value)
    {
        Anim.SetBool(param, value);
    }

    /// <summary>
    /// Включить в аниматоре анимацию с тригерной переменной
    /// </summary>
    /// <param name="param">Id</param>
    public void TriggerAnimation(int param)
    {
        Anim.SetTrigger(param);
    }
    #endregion

}
