using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class DealDamageOnContact : MonoBehaviour
{
    [SerializeField] int damage = 5;

    private ulong ownerClientID;

    public void SetOwner(ulong ownerClientID)
    {
        this.ownerClientID = ownerClientID;
    }

    private int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;

        if (collision.attachedRigidbody.TryGetComponent<NetworkObject>(out NetworkObject networkObject))
        {
            if (ownerClientID == networkObject.OwnerClientId) { return; }
        }

        if (collision.attachedRigidbody.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }

    }

}
