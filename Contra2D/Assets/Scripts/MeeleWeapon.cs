using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleWeapon : MonoBehaviour
{
    public float attackDamage = 20f;
    public Vector3 attOffset;
    public float rangeAttack = 2f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 position = transform.position;
        position += transform.right * attOffset.x;
        position += transform.up * attOffset.y;

        Collider2D col = Physics2D.OverlapCircle(position, rangeAttack, attackMask);

        if (col != null)
        {
            bool visibility = col.GetComponent<PlayerManager>().isVisible;
            if (visibility) {
            col.GetComponent<PlayerManager>().TakeDamage(attackDamage);}
        
        }
    }


    private void OnDrawGizmosSelected()
    {
        Vector3 position = transform.position;

        position += transform.right * attOffset.x;
        position += transform.up * attOffset.y;

        Gizmos.DrawWireSphere(position, rangeAttack);
    }
}
