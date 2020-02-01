using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//It is common to create a class to contain all of your
//extension methods. This class must be static.
public static class ExtensionMethods
{
    //Even though they are used like normal methods, extension
    //methods must be declared static. Notice that the first
    //parameter has the 'this' keyword followed by a Transform
    //variable. This variable denotes which class the extension
    //method becomes a part of.

    //Remove a list from a list:
    public static void RemoveList<T>(this List<T> listToRemoveFrom, List<T> listToRemove)
    {
        foreach(T item in listToRemove)
        {
            listToRemoveFrom.Remove(item);
        }
    }
    //Enable/Disable a whole List:
    public static void EnableAll(MonoBehaviour[] listToRemoveFrom, bool state)
    {
        listToRemoveFrom.ToList().EnableAll(state);
    }
    public static void EnableAll(this List<MonoBehaviour> listToRemoveFrom, bool state)
    {
        foreach(MonoBehaviour item in listToRemoveFrom)
        {
            item.enabled = state;
        }
    }
    //Destroys all Children Objects which have a component of type
    public static void DestroyAllChildren(this GameObject go, System.Type type){
        List<Component> components = new List<Component>(go.GetComponentsInChildren(type));
        for(int i = components.Count-1; i >= 0;i--){
            if (components[i].gameObject != go){
                GameObject.Destroy(components[i].gameObject);
            }
        }
    }
    //Destroys all monos in childern except which have a component of type T
/*     public static void DestroyAllMonosExcept<T>(this GameObject go){
        List<Component> components = new List<Component>(go.GetComponentsInChildren(typeof(MonoBehaviour)));
        for(int i = components.Count-1; i >= 0;i--){
            if (!(components[i] is T || components[i] is SkeletonMecanim)){
                //Debug.Log(components[i].GetType()+" its not equal by type: " + typeof(T));
                GameObject.Destroy(components[i]);
            }
        }
    } */
    //other stuff
    public static Vector3Int ConvertToVector3(this Vector3 vec3)
    {
        return new Vector3Int((int)vec3.x, (int)vec3.y, (int)vec3.z);
    }
    public static int Vector3ToCellCount(this Vector3 vec3){
        Vector3Int intVec = vec3.ConvertToVector3();
        return intVec.x * intVec.y * intVec.z;
    }
    public static int Vector3ToCellCount(this Vector3Int intVec){
        return intVec.x * intVec.y * intVec.z;
    }
    public static void ResetTransformation(this Transform trans)
    {
        trans.position = Vector3.zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = new Vector3(1, 1, 1);
    }
    //Hierarchy helpers for messagins systems:
    public static bool IsSibling(this Transform trans, Transform otherTransform){
        if(trans.parent.GetComponentsInChildren<Transform>().Contains(otherTransform))
            return true;
        else return false;
    }
    public static T GetComponentInSiblings<T>(this Transform trans){
        T c = trans.parent.gameObject.GetComponentInChildren<T>();
        if (c != null)
            return c;
        else return default(T);
    }
    //collider extentions:
    public static List<Transform> GetBoundBoxColliders(this Collider myCollider, Collider[] theirColliders){
        List<Transform> collided = new List<Transform>();
        foreach (Collider theirCol in theirColliders) {
            if (theirCol.bounds.Intersects(myCollider.bounds)) {
                if (theirCol.transform.parent.gameObject != myCollider.transform.parent.gameObject && //for Targetable,
                    theirCol.gameObject != myCollider.transform.parent.gameObject){//for BuildableSpaceMarker?
                    Vector3 dir;
                    float dist;
                    if(Physics.ComputePenetration(myCollider, myCollider.transform.position, myCollider.transform.rotation,
                            theirCol, theirCol.transform.position, theirCol.transform.rotation,
                            out dir, out dist)){
                        collided.Add(theirCol.transform.parent);
                        //Debug.Log(myCollider.transform.parent.name+" adding "+theirCol.transform.parent.name);
                    }
                }
            }
        }
        return collided;
    }
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    //Transform extentions"
    public static Transform FindNearest(this List<Transform> transformList, Transform target){
        if(transformList.Count == 0)
            return null;
        Transform nearest = transformList[0];
        foreach(Transform tr in transformList){
            float prevDistance = (nearest.transform.position - target.position).magnitude;
            float thisDistance = (tr.position - target.position).magnitude;
            if (thisDistance < prevDistance)
                nearest = tr;
        }
        return nearest;
    }
}