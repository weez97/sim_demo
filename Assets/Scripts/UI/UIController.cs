using System;
using EventTools;
using UnityEngine;

public interface IUiScreen
{
    public bool IsShowing();
    public void Show();
    public void Hide();
}

[Serializable]
public struct ScreenData
{
    public string name;
    public GameObject fab;
}

public class UIController : MonoBehaviour
{
    public ScreenData[] screens;

    IUiScreen currentScreen;

    void OnEnable()
    {
        CustomEventHandler.InputEvent += ShowScreen;
    }

    void OnDisable()
    {
        CustomEventHandler.InputEvent -= ShowScreen;
    }

    private void ShowScreen(string name)
    {
        // no need to continue if something is already showing
        if (currentScreen != null)
            return;

        GameObject tObj = GetScreen(name);

        if (tObj != null)
        {
            currentScreen = Instantiate(tObj).GetComponent<Shop>();
        }
        else
        {
            Debug.LogError($"Screen {name} prefab not found.");
        }
    }

    private GameObject GetScreen(string name)
    {
        for (int i = 0; i < screens.Length; i++)
            if (screens[i].name == name)
                return screens[i].fab;
        return null;
    }
}
