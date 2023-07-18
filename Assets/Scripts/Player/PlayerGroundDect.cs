using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDect : MonoBehaviour
{
    [SerializeField]float radius = 1f;
    [SerializeField] LayerMask groundLayer;
    Collider[] result=new Collider[1];
    public bool isGround=>Physics.OverlapSphereNonAlloc(transform.position, radius, result,groundLayer)!=0;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
