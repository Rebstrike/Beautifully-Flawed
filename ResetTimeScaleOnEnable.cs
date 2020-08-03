using UnityEngine;

public class ResetTimeScaleOnEnable : MonoBehaviour
{
    void OnEnable(){
        Time.timeScale = 1;
    }
}
