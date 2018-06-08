/// <summary>
///	泛型单例类 
/// </summary>
using UnityEngine;
using System.Collections;

public class ISingleton<T> where T:class, new(){
	private static T instance;
	private static readonly object syslock = new object();

	public static T Instance(){
		if(instance==null){
			lock(syslock){
				if(instance==null){
					instance = new T();
				}
			}
		}
		return instance;
	}
}