using UnityEngine;

public class Utilities : MonoBehaviour {

    public static GameObject InstantiateParent(string prefabPath, Transform parent) {
        return InstantiateParent(Resources.Load(prefabPath) as GameObject, parent);
    }
    public static GameObject InstantiateParent(GameObject prefab, Transform parent) {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.SetParent(parent, false);
        return newObject;
    }
    public static Color ModifyAlphaColor(Color color, float value) {
        color.a = value;
        return color;
    }
	public static float RangeRemap(float value, float from1, float from2, float to1, float to2){
		return to1 + (value-from1) * (to2-to1) / (from2-from1);
	}
	// Range check, inclusive
	public static bool IsInRange(int value, int minimum, int maximum){
		return (value >= minimum) && (value <= maximum);
	}
	// Range check for arrays
	public static bool IsInArrayRange(int value, int arrayLength){
		return (value >= 0) && (value < arrayLength);
	}
}