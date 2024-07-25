using System.Linq;
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
            InventoryManagerWithEvents.OnSingleJumpInInventory += EnableSingleJump;
            InventoryManagerWithEvents.OnDoubleJumpInInventory += EnableDoubleJump;
            ConceptCollectionNotifier.OnSingleJumpSold += DisableSingleJump;
            ConceptCollectionNotifier.OnDoubleJumpSold += DisableDoubleJump;
            ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
            ConceptCollectionNotifier.OnConceptPurchased += ConceptAddedToInventory;
            ConceptCollectionNotifier.OnConceptSold += ConceptRemovedFromInventory;
            

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


            }

            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
            {
                JumpingIsAllowed = true;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
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
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
            }
            else if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "jump" && DoubleJumpInInventory)
            {
                JumpingIsAllowed = true;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump" && !SingleJumpInInventory)
            {
                JumpingIsAllowed = false;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
                
            }
            else if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump" && SingleJumpInInventory)
            {
                JumpingIsAllowed = true;
                Debug.Log("Jumping allowed?" + JumpingIsAllowed);
            }      
                    
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
            {

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

        private void EnableSingleJump()
        {
            SingleJumpInInventory = true;
            Debug.Log("Single Jump in Inventory? "+ SingleJumpInInventory);
        }
        private void EnableDoubleJump()
        {
            DoubleJumpInInventory = true;
            Debug.Log("Double Jump in Inventory? "+ DoubleJumpInInventory);
        }
        private void DisableSingleJump()
        {
            SingleJumpInInventory = false;
            Debug.Log("Single Jump in Inventory? " + SingleJumpInInventory);
        }
        private void DisableDoubleJump()
        {
            DoubleJumpInInventory = false;
            Debug.Log("Double Jump in Inventory? " + DoubleJumpInInventory);
        }

        private void SetJumpFalse()
        {
            JumpingIsAllowed = false;
        }

    }
}
