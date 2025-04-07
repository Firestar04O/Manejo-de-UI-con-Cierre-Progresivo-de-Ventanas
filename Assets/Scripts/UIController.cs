using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class UIController : MonoBehaviour
{
    [Header("Nombre de la ventana a crear:")]
    [SerializeField] public string WindowName; 

    public SimpleLinkedList<string> activateWindows = new SimpleLinkedList<string>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseLastWindow();
        }
    }
    public void OpenWindow(string windowName)
    {
        Node<string> newWindowNode = new Node<string>(windowName);
        activateWindows.Add(newWindowNode);
        Debug.Log("Ventana " + windowName + " abierta");
    }
    public void CloseLastWindow()
    {
        Node<string> closedWindowNode = activateWindows.RemoveLast();
        if (closedWindowNode != null)
        {
            string closedWindowName = closedWindowNode.value;
            int remainWindows = activateWindows.CountActiveWindows();
            Debug.Log("Se cerró la ventana " + closedWindowName + ". Quedan " + remainWindows + " ventanas abiertas");
        }
        else
        {
            Debug.Log("Ya se cerraron todas las ventanas");
        }
    }
    [Button]
    private void AbrirVentana()
    {
        int remainWindows = activateWindows.CountActiveWindows();
        OpenWindow(WindowName);
    }
}

