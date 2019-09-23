using mixpanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixpanelTest : MonoBehaviour
{
    private const float Delay = 0.3f;

    public TMPro.TMP_InputField input;

    public void SignUp()
    {
        Mixpanel.Alias(input.text);
        MakeEventDeleyed("SignUp");
    }

    public void ResetUser()
    {
        PlayerPrefs.DeleteAll();
        MakeEventDeleyed("Reset");
    }

    public void Login()
    {
        Mixpanel.Identify(input.text);
        MakeEventDeleyed("Login");
    }

    public void MakeEvent(string eventName)
    {
        Mixpanel.Track(eventName);
    }

    public void MakeEventDeleyed(string eventName)
    {
        StartCoroutine(WaitCoroutine(eventName));
    }

    IEnumerator WaitCoroutine(string eventName)
    {
        yield return new WaitForSeconds(Delay);
        Mixpanel.Track(eventName);
    }
}
