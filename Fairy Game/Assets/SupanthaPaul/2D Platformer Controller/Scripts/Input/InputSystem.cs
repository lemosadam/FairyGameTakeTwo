﻿using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

namespace SupanthaPaul
{
	public class InputSystem : MonoBehaviour
	{
      // input string caching
		static readonly string HorizontalInput = "Horizontal";
		static readonly string JumpInput = "Jump";
		static readonly string DashInput = "Dash";

		private static bool DashingIsAllowed = false;
        public static bool JumpingIsAllowed = false;
        private bool SingleJumpInInventory = false;
        private bool DoubleJumpInInventory = false;


        private void Start()
        {
			DashingIsAllowed = false;
            SingleJumpInInventory = false;
            DoubleJumpInInventory = false;
            ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
            ConceptCollectionNotifier.OnConceptPurchased += ConceptAddedToInventory;
            ConceptCollectionNotifier.OnConceptSold += ConceptRemovedFromInventory;
            InventoryManagerWithEvents.OnSingleJumpInInventory += ToggleSingleJumpInInventory;
            InventoryManagerWithEvents.OnDoubleJumpInInventory += ToggleDoubleJumpInInventory;
            ConceptCollectionNotifier.OnSingleJumpSold += ToggleSingleJumpInInventory;
            ConceptCollectionNotifier.OnDoubleJumpSold += ToggleDoubleJumpInInventory;

        }
        private void ConceptAddedToInventory(GameObject concept)
        {
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "dash")
            {
                DashingIsAllowed = true;

            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "jump")
            {
                JumpingIsAllowed = true;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
                //SingleJumpInInventory = true;
                Debug.Log("Single Jump in inventory? " + SingleJumpInInventory);


            }

            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
            {
                JumpingIsAllowed = true;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
                //DoubleJumpInInventory = true;
                Debug.Log("Double Jump in inventory? " + DoubleJumpInInventory);
            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
            {

            }

        }
        private void ConceptRemovedFromInventory(GameObject concept)
        {
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "dash")
            {
                DashingIsAllowed = false;

            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "jump" && !DoubleJumpInInventory)
            {
                JumpingIsAllowed = false;
                //SingleJumpInInventory = false;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
                Debug.Log("Single Jump in inventory? " + SingleJumpInInventory);
            }
            else if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "jump" && DoubleJumpInInventory)
            {
                //SingleJumpInInventory = false;
                Debug.Log("Single Jump in inventory? " + SingleJumpInInventory);
                JumpingIsAllowed = true;
            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump" && !SingleJumpInInventory)
            {
                Debug.Log("Single Jump in inventory? " + SingleJumpInInventory);
                JumpingIsAllowed = false;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
                //DoubleJumpInInventory = false;
                Debug.Log("Double Jump in inventory? " + DoubleJumpInInventory);
                
            }
            else if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump" && SingleJumpInInventory)
            {
                //DoubleJumpInInventory = false;
                Debug.Log("Double Jump in inventory? " + DoubleJumpInInventory);
                JumpingIsAllowed = true;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
            }      
                    
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
            {
                //JumpingIsAllowed = false;
            }
        }

            public static float HorizontalRaw()
		{
			return Input.GetAxisRaw(HorizontalInput);
		}

		public static bool Jump()
		{

            return Input.GetButtonDown(JumpInput) && JumpingIsAllowed;
            
        }

		public static bool Dash()
		{
			return Input.GetButtonDown(DashInput) && DashingIsAllowed;
		}

        private void ToggleSingleJumpInInventory()
        {
            SingleJumpInInventory = !SingleJumpInInventory;
        }
        private void ToggleDoubleJumpInInventory()
        {
            DoubleJumpInInventory = !DoubleJumpInInventory;
        }

        private void SetJumpFalse()
        {
            JumpingIsAllowed = false;
        }

    }
}
