using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipGunNew : MonoBehaviour
{

    public FinalShoot gunScript;
    public Rigidbody rb;
    public BoxCollider boxCollider;
    public Transform player;
    public Transform gunHolder;
    public Transform playerCam;

    public float pickUpRange;
    public float dropUpForce;
    public float dropForwardForce;

    public bool equiped;
    public static bool slotFull;

    private void Start()
    {
        if(!equiped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            boxCollider.isTrigger = false;
        }

        if (equiped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            boxCollider.isTrigger = true;
            slotFull = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (!equiped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && !slotFull) PickUp();

        if (equiped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        equiped = true;
        slotFull = true;

        transform.SetParent(gunHolder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        boxCollider.isTrigger = true;

        gunScript.enabled = true;
    }

    private void Drop()
    {
        equiped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(playerCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(playerCam.up * dropUpForce, ForceMode.Impulse);

        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);

        rb.isKinematic = false;
        boxCollider.isTrigger = false;

        gunScript.enabled = false;
    }
}
