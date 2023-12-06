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
