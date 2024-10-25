using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SlashBehavior : MonoBehaviour
{
    SpriteRenderer slash;
    BoxCollider2D hitbox;
    private void Start()
    {
        slash = this.GetComponent<SpriteRenderer>();
        hitbox = this.GetComponent<BoxCollider2D>();
        slash.enabled = false;
    }
    public void HideSlash()
    {
        slash.enabled = false;
        hitbox.enabled = false;
    }
    public void ShowSlash()
    {
        slash.enabled = true;
        hitbox.enabled = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // get the enemy and damage them
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.photonView.RPC("TakeDamage", RpcTarget.MasterClient, this.GetComponentInParent<PlayerController>().damage);
        }
        Debug.Log("Enemy Spotted");
    }
}
