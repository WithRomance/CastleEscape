using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public abstract class Knights : MonoBehaviour,IDamageable
{
   
    public bool isAlive = true;
    public int level;
    public float moveSpeed;
    public TMP_Text levelText;

    
    protected Rigidbody rb;
    protected Animator animator;
   
    public int _level { get { return level; } set { value = level; } }
    public bool _isAlive { get { return isAlive; } set { value = isAlive; } }

    public abstract void TakeDamage();
    
    public void Attack(IDamageable target)
    {
        animator.SetBool("isAttacking",true);
        StartCoroutine(AttackStoper());
        target.TakeDamage();
    }
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            if (level > damageable._level && damageable._isAlive) Attack(damageable);
           
        }

    }
    protected void LevelTextInitializer() =>levelText.text="LV."+level.ToString();

    IEnumerator AttackStoper()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isAttacking", false);
    }
    
}
