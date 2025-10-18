using UnityEngine;
using System.Collections;
using System;


public class ColaMoveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject colaImage;
    private GameObject youWonText;
    
    public float maxScale = 1.1f;
    public float minScale = 0.7f;
    private bool isGrowing = true;
    private bool canPerformAction = true;
    void Start()
    {
        colaImage = GameObject.Find("ColaImage");
        youWonText = GameObject.Find("YouWonText(TMP)");
        if (colaImage == null)
        {
            Debug.LogError("ColaImage not found! Make sure it exist in the scene.");
            return;
        }
        else if (youWonText == null)
        {
            Debug.LogError("YouWonText not found! Make sure it exist in the scene.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canPerformAction)
        {
            StartCoroutine(DelayedAction(pulseCola));
        }
    }

    void pulseCola()
    {
        if (isObjBiggerThan(colaImage, maxScale))
        {
            isGrowing = false;
        }
        else if (isObjSmallerThan(colaImage, minScale))
        {
            isGrowing = true;
        }

        if (isGrowing)
        {
            makeObjBigger(colaImage);
            makeObjBigger(youWonText);
        }
        else
        {
            makeObjSmaller(colaImage);
            makeObjSmaller(youWonText);
        }
    }
    IEnumerator DelayedAction(Action methodToCall)
    {
        canPerformAction = false;
        Debug.Log("Starting delayed action...");

        // Wait for 0.2 seconds using scaled time
        yield return new WaitForSeconds(0.02f);

        Debug.Log("Action performed after 0.1 seconds!");

        // Call the provided method after the delay
        methodToCall?.Invoke();

        // You can also wait using unscaled time (ignoring Time.timeScale)
        // yield return new WaitForSecondsRealtime(3f);
        canPerformAction = true;
    }
    void makeObjBigger(GameObject obj)
    {
        obj.transform.localScale += new Vector3(0.002f, 0.002f, 0);
    }



void makeObjSmaller(GameObject obj)
    {
        obj.transform.localScale -= new Vector3(0.002f, 0.002f, 0);
    }

    bool isObjBiggerThan(GameObject obj, float maxScaleLimit)
    {
        if (obj.transform.localScale.x >= maxScaleLimit || obj.transform.localScale.y >= maxScaleLimit)
        {
            return true;
        }
        return false;
    }

    bool isObjSmallerThan(GameObject obj, float minScaleLimit)
    {
        if (obj.transform.localScale.x <= minScaleLimit || obj.transform.localScale.y <= minScaleLimit)
        {
            return true;
        }
        return false;
    }
}
