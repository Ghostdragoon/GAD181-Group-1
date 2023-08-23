using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponInventory : MonoBehaviour
{
    public int selectedWepon = 0;


    // Start is called before the first frame update
    void Start()
    {
        SelectWepon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWepon = selectedWepon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(selectedWepon >= transform.childCount - 1)
                selectedWepon = 0;
            else
            selectedWepon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWepon <= 0)
                selectedWepon = transform.childCount - 1;
            else
                selectedWepon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWepon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWepon = 1;
        }

        if (previousWepon != selectedWepon)
        {
            SelectWepon();
        }
    }

    void SelectWepon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWepon)
                weapon.gameObject.SetActive(true);
            else 
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
