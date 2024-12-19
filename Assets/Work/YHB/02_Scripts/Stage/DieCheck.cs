using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCheck : MonoBehaviour
{
    [SerializeField] private Stage stage;

    private void Awake()
    {
        stage = GetComponentInParent<Stage>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!collision.gameObject.CompareTag("Player")) return;
        if (collision.gameObject.CompareTag("Thorm")) return;

        stage.Restart();
    }



}
