using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class VibrateControllerOnImpact : MonoBehaviour
{
    public float leftVibAmount;
    public float rightVibAmount;
    public float WaitTime;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Vibrate());
    }

    IEnumerator Vibrate()
    {
        GamePad.SetVibration(PlayerIndex.One, leftVibAmount, rightVibAmount);
        yield return new WaitForSeconds(WaitTime);
        GamePad.SetVibration(PlayerIndex.One, 0, 0);
    }
}
