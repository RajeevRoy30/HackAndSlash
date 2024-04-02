using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AnimActions",menuName ="ScriptableObject/ParkourActions",order =1)]
public class ParkourAction : ScriptableObject
{
    [SerializeField]  string animAction;
    [SerializeField] float minActionHeight;
    [SerializeField] float maxActionHeight;

    [SerializeField] public Vector3 animPos;
    [SerializeField] public Vector3 animRot;
    public float animTime;
    public bool CheckForAnim(HitInfo info,Transform player)
    {
        
        float checkHeigt=info.heightHit.point.y-player.transform.position.y;
        if(checkHeigt<minActionHeight|| checkHeigt>maxActionHeight)
        {
            
           return false;
        }
        Debug.LogError("okok");
        return true;
    }
    public string AnimationName => animAction;
}
