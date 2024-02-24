using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour

{
    // Start is called before the first frame update
   private  Animator playerAnime;

    private void Awake()
    {
        playerAnime = GetComponent<Animator>(); 
    }
    public void MovementAnimation(float Xvalue,float Yvalue)
    {
        float x, y;
        x = playerAnime.GetFloat("XValue");
        y = playerAnime.GetFloat("YValue");

        Xvalue = Mathf.Lerp(x, Xvalue, 0.45f);
        Yvalue = Mathf.Lerp(y, Yvalue, 0.45f);





        playerAnime.SetFloat("XValue", Xvalue);
        playerAnime.SetFloat("YValue", Yvalue);
        
    }
    public void SwordEquip(bool Sword)
    {
        playerAnime.SetBool("Equip",Sword);
    }
    public void SwordEquipTrigger()
    {
        playerAnime.SetTrigger("EquipTrigger");
    }
}
