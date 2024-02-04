using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease,
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch(type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                Debug.Log(player.GetComponent<BombController>().bombAmount);
                break;
            case ItemType.BlastRadius:
                player.GetComponent<BombController>().explosionRadius++;
                Debug.Log(player.GetComponent<BombController>().explosionRadius);
                break;
            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().speed++;
                Debug.Log(player.GetComponent<MovementController>().speed);
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickup(other.gameObject);
        }
    }
}
