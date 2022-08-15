using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Bannernaya : MonoBehaviour
{
    public string placementId = "Banner";
    void Start()
    {/*
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4073275", false);
        }
        StartCoroutine(ShowBanner());*/
    }

    IEnumerator ShowBanner()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }

}
