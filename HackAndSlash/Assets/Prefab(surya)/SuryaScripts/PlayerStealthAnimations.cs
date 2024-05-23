using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AnimActions", menuName = "ScriptableObject/StealthActions", order = 1)]
public class PLayerStealthAnimations : ScriptableObject
{
    [SerializeField] string animAction;
    [SerializeField] string animAction1;
    //[SerializeField] float minActionHeight;
    //[SerializeField] float maxActionHeight;

    [SerializeField] public Vector3 animPos;
    [SerializeField] public Vector3 animRot;
    public float animTime;
    public string AnimationName => animAction;
    public string AnimationName1 => animAction1;
}
