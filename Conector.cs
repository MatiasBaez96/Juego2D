using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IntDoDamage
{
    void DoDamage(int var);    
}

public class Weapon_Base
{
    public int damage;
    public IntDoDamage damageType;

    public void TryDoAttack()
    {
        damageType?.DoDamage(damage);
    }
}

public class FireDamage : IntDoDamage
{
    public void DoDamage(int damage)
    {
        
    }
}
