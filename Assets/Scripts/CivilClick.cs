    using UnityEngine;

    public class CivilClick : MonoBehaviour
    {
        public Window_Controller controller; // Referencia al script principal

        private void OnMouseDown()
        {
            if (controller != null && controller.ventanaon && !controller.civilRescatado)
            {
                controller.StartCoroutine(controller.QuitVentana());
            }
        }
    }

