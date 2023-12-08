using System.Runtime.InteropServices.WindowsRuntime;
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
        private static bool JumpingIsAllowed = false;

        private void Start()
        {
			DashingIsAllowed = false;
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
            }

            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
            {
                JumpingIsAllowed = true;
            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
            {
                JumpingIsAllowed = true;
            }

        }
        private void ConceptRemovedFromInventory(GameObject concept)
        {
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "dash")
            {
                DashingIsAllowed = false;

            }
            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "jump")
            {
                JumpingIsAllowed = false;
            }

            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
            {
                JumpingIsAllowed = false;
            }

            if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
            {
                JumpingIsAllowed = false;
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

        

    }
}
