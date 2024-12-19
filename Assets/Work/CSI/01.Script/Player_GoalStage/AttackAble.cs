using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] 
public class AttackAble : MonoBehaviour,IRestartable
{
    public void RestartSet()
    {
        
    }

    public void RestartEnd()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        transform.GetComponentInParent<Stage>().Restart();
    }
}
