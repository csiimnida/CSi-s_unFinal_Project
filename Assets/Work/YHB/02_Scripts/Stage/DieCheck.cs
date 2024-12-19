using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCheck : MonoBehaviour
{
    [SerializeField] private Stage stage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        stage.Restart();
    }


}
