using UnityEngine;

public class ColaMoveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject colaImage;
    private GameObject youWonText;
    
    public float maxScale = 1.3f;
    public float minScale = 0.5f;
    private bool isGrowing = true;
    void Start()
    {
        colaImage = GameObject.Find("ColaImage");
        youWonText = GameObject.Find("YouWonText");
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
            //makeObjBigger(youWonText);
        }
        else
        {
            makeObjSmaller(colaImage);
            //makeObjSmaller(youWonText);
        }
    }

    void makeObjBigger(GameObject obj)
    {
        obj.transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    void makeObjSmaller(GameObject obj)
    {
        obj.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
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
