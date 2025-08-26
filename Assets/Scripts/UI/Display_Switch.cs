using UnityEngine;

public class Display_Switch : MonoBehaviour
{
    void Start()
    {
        SetFullScreenWindowOnMainDisplay();
    }

    void SetFullScreenWindowOnMainDisplay()
    {
#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        // Move window to main display position (0,0)
        MoveWindowToMainDisplay();
#endif
    }

#if !UNITY_EDITOR && UNITY_STANDALONE_WIN
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern System.IntPtr GetActiveWindow();

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    void MoveWindowToMainDisplay()
    {
        var hwnd = GetActiveWindow();
        MoveWindow(hwnd, 0, 0, Screen.width, Screen.height, true);
    }
#endif
}
