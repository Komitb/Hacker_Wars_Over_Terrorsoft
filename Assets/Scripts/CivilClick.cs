    using UnityEngine;

    public class CivilClick : MonoBehaviour
    {
        public Window_Controller controller; // Referencia al script principal

        private void OnMouseDown() //Cuando se pulsa el click en el civil nos cierra la ventana
        {
            if (controller != null && controller.ventanaon && !controller.civilRescatado)
            {
                controller.StartCoroutine(controller.QuitVentana());
            }
        }
    }

