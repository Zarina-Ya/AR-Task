using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
public class ImageTracking : MonoBehaviour
{

    [SerializeField] private GameObject[] _prefabsForImage;
    private Dictionary<string, GameObject> _pairPrefab;
    private ARTrackedImageManager _imageManager;
    float positionspawn = 0f;
    private Vector3 scaleFactor = new Vector3(0.1f, 0.1f, 0.1f);
    private void Awake()
    {
        _imageManager = FindObjectOfType<ARTrackedImageManager>();
        _pairPrefab = new Dictionary<string, GameObject>();
        foreach (var prefabs in _prefabsForImage)
        {
            GameObject newPrefab = Instantiate(prefabs,new Vector3(positionspawn, 0f,0f),Quaternion.identity);
            newPrefab.name = prefabs.name;
            newPrefab.SetActive(false);
            _pairPrefab.Add(prefabs.name, newPrefab);
            //newPrefab.SetActive(false);
            positionspawn += 0.3f;
        }

       
    }
    /// <summary>
    /// Когда мы включили отслеживаемый менеджер, мы хотим добавить обработчик событий trackedImagesChanged для привязки метода OnTrackedImagesChanged, 
    /// который мы создадим для вызова один раз в каждом кадре для отслеживания информации об измененных 2D-изображениях, т.е. добавленных, обновленных или удаленных. 
    /// Когда мы отключаем отслеживаемый менеджер, мы удаляем привязку. Это используется просто для того, чтобы поддерживать чистоту нашего кода.
    /// </summary>
    private void OnEnable()
    {
        _imageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        _imageManager.trackedImagesChanged -= ImageChanged;
    }

    //
    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateUmage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateUmage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            _pairPrefab[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateUmage(ARTrackedImage trackedImage)
    {
        var name = trackedImage.referenceImage.name;// имя отслеживаемого изображения
        //Vector3 position = trackedImage.transform.position;

        GameObject prefab = _pairPrefab[name];



        if(trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
        {
            prefab.transform.position = trackedImage.transform.position;
            prefab.transform.rotation = trackedImage.transform.rotation;
            prefab.SetActive(true);
        }
        else
        {
            prefab.SetActive(true);
        }
        
    }
   


}
