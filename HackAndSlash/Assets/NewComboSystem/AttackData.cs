using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ComboAttackData", menuName = "ScriptableObject/ComboData", order = 1)]
public class AttackData : ScriptableObject
{

    public float startTime, endTime,animKeyFrameToPerformNextCombo;
    public string AnimationName;
    public AnimationClip anim;
}
