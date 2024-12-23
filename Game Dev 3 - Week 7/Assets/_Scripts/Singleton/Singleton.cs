using UnityEngine;

namespace GameDevWithMarco.Singleton
{
    // Abstract class for creating a Singleton pattern in Unity
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance; // Store the single instance of the derived class

        // Property to access the instance
        public static T Instance
        {
            get
            {
                // If no instance exists, find or create one
                if (instance == null)
                {
                    instance = FindObjectOfType<T>(); // Look for an existing instance in the scene

                    if (instance == null) // If still no instance found
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name); // Create a new GameObject
                        instance = singletonObject.AddComponent<T>(); // Add the derived class component to the GameObject
                    }
                }
                return instance; // Return the single instance
            }
        }

        protected virtual void Awake()
        {
            // Check if the instance already exists and it's not this instance
            if (instance != null && instance != this)
            {
                Destroy(gameObject); // Destroy the duplicate instance's GameObject
            }
            else
            {
                instance = this as T; // Set the instance to this (the current instance)
                DontDestroyOnLoad(gameObject); // Ensure this object persists across scene loads
            }
        }

        // Ensures that the instance is always valid and persists across multiple scenes
        protected virtual void OnEnable()
        {
            // If the instance is null or does not match this object, make this object the new instance
            if (instance == null || instance != this)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }

        
        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        
    }
}
