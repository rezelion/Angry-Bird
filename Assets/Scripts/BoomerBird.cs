using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerBird : Bird
{
    [SerializeField]
    public float _fieldImpact;
    public float force;
    public bool _hasBoom = false;
    public LayerMask LayerHit;
    public GameObject ExploFX;

    //public float TimeVal = 3f;

    public void Update()
    {
         Boom();
    }

    public void Boom()
    {
        
            if (State == BirdState.HitSomething)
            {
                Collider2D[] Object = Physics2D.OverlapCircleAll(transform.position, _fieldImpact, LayerHit);
                foreach (Collider2D obj in Object)
                {
                    Vector2 dir = obj.transform.position - transform.position;
                    obj.GetComponent<Rigidbody2D>().AddForce(dir * force);
                }
            GameObject ExFX = Instantiate(ExploFX,transform.position,Quaternion.identity);
            Destroy(ExFX,5);
            Destroy(gameObject);
            }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _fieldImpact);
    }
}
