using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class Controller : MonoBehaviour
{
    private string m_result = string.Empty;

    private void OnGUI()
    {
        var options = new[]
        {
            GUILayout.Width( Screen.width ),
            GUILayout.Height( Screen.height / 4 ),
        };

        if (GUILayout.Button("Unity Ads", options))
        {
            ShowRewardedAd();
        }

        GUILayout.Label(m_result);
    }

    private void ShowRewardedAd()
    {
        if (!Advertisement.IsReady()) return;

        var options = new ShowOptions
        {
            resultCallback = OnResult,
        };
        Advertisement.Show(options);
    }

    private void OnResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                m_result = "Finished";
                break;
            case ShowResult.Skipped:
                m_result = "Skipped";
                break;
            case ShowResult.Failed:
                m_result = "Failed";
                break;
        }
    }
}