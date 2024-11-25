using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject WeaponHolder;
    public KeyCode Slot1 = KeyCode.Alpha1, Slot2 = KeyCode.Alpha2;

    private GameObject currentlyEquippedWeapon = null; // Tracks the equipped weapon
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Debug.Log("Weapon picked up: " + collision.gameObject.name);

            collision.transform.SetParent(WeaponHolder.transform);
            collision.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.SetActive(false);

            // Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Slot2))
        {
            EquipWeapon("Gun");
        }

        if (Input.GetKeyDown(Slot1))
        {
            EquipWeapon("Bat");
        }
    }

    private void EquipWeapon(string weaponName)
    {
        if (WeaponHolder != null)
        {
            // Find the new weapon by name
            Transform newWeaponTransform = WeaponHolder.transform.Find(weaponName);
            if (newWeaponTransform != null)
            {
                GameObject newWeapon = newWeaponTransform.gameObject;

                // Check if it's already equipped
                if (currentlyEquippedWeapon == newWeapon)
                {
                    // Unequip if the same weapon is toggled
                    newWeapon.SetActive(false);
                    currentlyEquippedWeapon = null;
                    Debug.Log(weaponName + " has been unequipped!");
                }
                else
                {
                    // Unequip the current weapon, if any
                    if (currentlyEquippedWeapon != null)
                    {
                        currentlyEquippedWeapon.SetActive(false);
                        Debug.Log(currentlyEquippedWeapon.name + " has been unequipped!");
                    }

                    // Equip the new weapon
                    newWeapon.SetActive(true);
                    currentlyEquippedWeapon = newWeapon;

                    // Reset position and rotation relative to the WeaponHolder
                    newWeaponTransform.localPosition = Vector3.zero; // Sets position to (0, 0, 0)
                    newWeaponTransform.localRotation = Quaternion.identity; // Sets rotation to (0, 0, 0)

                    Debug.Log(weaponName + " has been equipped and positioned!");
                }
            }
            else
            {
                Debug.LogWarning("No weapon named '" + weaponName + "' found in WeaponHolder!");
            }
        }
        else
        {
            Debug.LogError("WeaponHolder is not assigned in the Inspector!");
        }
    }
}
