using System;

using UnityEngine;

[System.Serializable]
public class Attack
{
    [SerializeField] private string animationName;
    [SerializeField] private float transitionDuration;
    [SerializeField] private int comboStateIndex;
    [SerializeField] private float comboAttackTime;
    [SerializeField] private float force;
    [SerializeField] private float forceTime;
    [SerializeField] private float knockback;
    [SerializeField] private int damage;

    public string AnimationName => animationName;

    public float TransitionDuration => transitionDuration;
    public int ComboStateIndex => comboStateIndex;
    public float ComboAttackTime => comboAttackTime;
    public float Force => force;
    public float ForceTime => forceTime;
    public float Knockback => knockback;
    public int Damage => damage;
}