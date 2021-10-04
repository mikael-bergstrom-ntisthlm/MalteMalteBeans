
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class guess : MonoBehaviour
{
    UnityEngine.TouchScreenKeyboard keyboard;
    public static string keyboardText = "";

    public void open() {
        keyboard = TouchScreenKeyboard.Open("How many beans are in the jar?", TouchScreenKeyboardType.NumberPad);
    }

    void FixedUpdate() {
        if (keyboard != null) {
            if (keyboard.status == TouchScreenKeyboard.Status.Done) {
                keyboardText = keyboard.text;
                SaveData(keyboardText);
            }
        }
        
    }

    void SaveData(string value) {
        Debug.LogError("The value is " + value);
    }
}
