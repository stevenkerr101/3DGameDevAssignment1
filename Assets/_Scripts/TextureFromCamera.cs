using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class TextureFromCamera : MonoBehaviour
{
    public GameObject imageFrame;
    public GameObject rawImagePhoto;
    public float ratio = 0.25f;
    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            rawImagePhoto.SetActive(false);
            StartCoroutine(CaptureScreen());
            rawImagePhoto.SetActive(true);
        }
    }

    IEnumerator CaptureScreen()
    {
        RectTransform frameTransform = imageFrame.GetComponent<RectTransform>();
        Rect framing = frameTransform.rect;
        Vector2 pivot = frameTransform.pivot;
        Vector2 origin = frameTransform.anchorMin;

        origin.x *= Screen.width;
        origin.y *= Screen.height;

        float xOffset = pivot.x * framing.width;
        origin.x += xOffset;
        float yOffset = pivot.y * framing.height;
        origin.y += yOffset;
        framing.x += origin.x;
        framing.y += origin.y;

        Texture2D texture = new Texture2D((int)framing.width, (int)framing.height);

        yield return new WaitForEndOfFrame();

        texture.ReadPixels(framing, 0, 0);
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();

        File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

        Vector3 photoScale = new Vector3(framing.width * ratio, framing.height * ratio, 1);
        rawImagePhoto.GetComponent<RectTransform>().localScale = photoScale;
        rawImagePhoto.GetComponent<RawImage>().texture = texture;
    }
}