using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System;
public static class MonoExtension{

    static string strAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string RandomLetter()
    {
        
        return strAlphabet[UnityEngine.Random.Range(0, strAlphabet.Length)].ToString();
    }

    public static string RandomLetter(string str) {
        //RETURNS RANDOM LETTER THAT DOES NOT EXIST IN STR
        string tempStr = strAlphabet;
        for(int i=0; i<str.Length; i++)
        {
            tempStr = tempStr.Replace(str[i].ToString(),"");
        }
    
        Debug.Log(tempStr.Length);
        return tempStr[UnityEngine.Random.Range(0, tempStr.Length)].ToString();
    }
    //
    
    public static void SetXPos(this Transform t, float newX)
    {
        t.position = new Vector3(newX,t.position.y,t.position.z);
    }

    public static void SetYPos(this Transform t, float newY)
    {
        t.position = new Vector3(t.position.x, newY, t.position.z);
    }

    public static void SetZPos(this Transform t, float newZ)
    {
        t.position = new Vector3(t.position.x, t.position.y, newZ);
    }

    public static float GetXPos(this Transform t)
    {
        return t.position.x;
    }

    public static float GetYPos(this Transform t)
    {
        return t.position.y;
    }

    public static float GetZPos(this Transform t)
    {
        return t.position.z;
    }
   	
	public static float GetZRot(this Transform t)
	{
		return t.rotation.z;
	}
	public static void SetZRot(this Transform t, float newZ)
	{
		t.rotation = Quaternion.Euler(new Vector3(t.rotation.x, t.rotation.y , newZ));
	}

    #region/*LOCAL*/
    public static void SetLocalXPos(this Transform t, float newX)
	{
        try {
            t.localPosition = new Vector3(newX, t.localPosition.y, t.localPosition.z);
        }
        catch(Exception ex){
            Debug.Log(ex.Message);
        }
		
	}
	public static void SetLocalYPos(this Transform t, float newY)
	{
        try {
            t.localPosition = new Vector3(t.localPosition.x, newY, t.localPosition.z);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
		
	}
    public static void SetLocalXRot(this Transform t, float newX)
    {
        try {
            t.localRotation = Quaternion.Euler(new Vector3(newX, t.localRotation.y, t.localRotation.z));
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
      

    }
    public static void SetLocalYRot(this Transform t, float newY)
    {
        t.localRotation = Quaternion.Euler(new Vector3(t.localRotation.x, newY, t.localRotation.z));

    }
    public static void SetLocalZRot(this Transform t, float newZ)
    {
        t.localRotation = Quaternion.Euler(new Vector3(t.localRotation.x, t.localRotation.y, newZ));
        
    }

    public static float GetLocalZRot(this Transform t)
    {
        return t.localRotation.z;
    }

   
    
    public static void SetLocalWidth(this Transform t, float width)
    {
        t.localScale = new Vector3(width, t.localScale.y, t.localScale.z);
    }
    public static void SetLocalHeight(this Transform t, float height) {
        t.localScale = new Vector3(t.localScale.x,height,t.localScale.z);
    }
	public static float GetLocalWidth(this Transform t){
		return t.localScale.x;
	}
	public static float GetLocalHeight(this Transform t){
		return t.localScale.y;
	}
	public static float GetLocalXPos(this Transform t){
     
            return t.localPosition.x;
	}
	public static float GetLocalYPos(this Transform t){
		return t.localPosition.y;
	}
	#endregion

    //public static void SetHeight(this Transform t, float height)
    //{
    //    //t.lossyScale.y = height;// = new Vector3(t.lossyScale.x, height, t.lossyScale.z);
    //}

    public static void SetHeight(this Transform t, float height)
    {
        RectTransform rt = t.GetComponent<RectTransform>();
        try
        {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
    public static void SetWidth(this Transform t, float width)
    {
        RectTransform rt = t.GetComponent<RectTransform>();
        try
        {
            rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
    public static void SetHeight(this RectTransform t, float height) {
        try
        {
            t.sizeDelta = new Vector2(t.sizeDelta.x, height);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
     
    }
    public static void SetWidth(this RectTransform t, float width)
    {
        try
        {
            t.sizeDelta = new Vector2(width, t.sizeDelta.y);
        }catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
        
    }

    public static float GetWidth(this Transform t)
    {
        return GetWidth(t.GetComponent<RectTransform>());
    }

    public static float GetHeight(this Transform t)
    {
        return GetHeight(t.GetComponent<RectTransform>());
    }
	public static float GetWidth(this RectTransform t){
		return t.sizeDelta.x;
	}
    public static float GetHeight(this RectTransform t)
    {
        return t.sizeDelta.y;
    }

    public static void SetLocalWidth(this RectTransform t, float width) {
        t.localScale = new Vector3(width, t.localScale.y, t.localScale.z);
    }
    public static void SetLocalHeight(this RectTransform t, float height)
    {
        t.localScale = new Vector3(t.localScale.x, height, t.localScale.z);
    }


}
