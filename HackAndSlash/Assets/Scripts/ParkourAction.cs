using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParkourAction : ScriptableObject
{
    [SerializeField]  string animAction;
    [SerializeField] float minActionHeight;
    [SerializeField] float maxActionHeight;

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
