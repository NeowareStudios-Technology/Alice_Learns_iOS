/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine.Video;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES

        metadataParse mParser;
        DynamicDataSetLoader targetControl;
        analyticsController analyticsControl;

        private bool firstrun = true;
        private bool ispaused;

        public bool staticTargets = false;

        private float startTime = 0.0f;
        private float endTime = 5.0f;
        private float timer;
        private bool check;

        public Text debugText;

        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            try
            {
                mParser = transform.Find("targetObject(Clone)").GetComponent<metadataParse>();
            }
            catch (NullReferenceException ex)
            {

            }

            try
            {
                targetControl = GameObject.FindObjectOfType<DynamicDataSetLoader>();
            }
            catch (NullReferenceException ex)
            {

            }

            try
            {
                analyticsControl = GameObject.FindObjectOfType<analyticsController>();
            }
            catch (NullReferenceException ex)
            {

            }

            try
            {
                debugText = GameObject.Find("Debug").GetComponent<Text>();
            }
            catch (NullReferenceException ex)
            {

            }

            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {

            Debug.Log("I see " + this.gameObject.name);

            try
            {
                if (!targetControl.ready)
                {
                    return;
                }
                GameObject.Find("targetManager").GetComponent<TargetTracker>().AddTarget(this.gameObject);

            }
            catch ( NullReferenceException ex) { }


            try
            {

                ispaused = mParser.isPaused;
                firstrun = mParser.firstRun;

                check = GameObject.FindObjectOfType<metadataParse>().pauseVideo;

            }
            catch (NullReferenceException ex) { }


            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
            Canvas[] canvasComponents = GetComponentsInChildren<Canvas>(true);

            // Enable Canvas
            foreach (Canvas component in canvasComponents)
            {
                component.enabled = true;
            }
            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

            try
            {
                if (check == true)
                {
#if UNITY_IOS || UNITY_EDITOR
                    mParser.videoPlayer.Pause();
                    mParser.audioSource.Pause();
#elif UNITY_ANDROID
                    mParser.easyPlayer.Pause();
#endif
                }
                Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
                string trackableName = mTrackableBehaviour.TrackableName;
                analyticsControl.launchTimeTrack(true);
                if (targetControl.currentTrackable != trackableName)
                {
                    targetControl.currentTrackable = trackableName;
                    mParser.resetCard();
                    debugText.text += "After reset card @ time: " + Time.time + "\n";
                    mParser.loadMetadata(trackableName);
                }
                // if still the same target play the video
                else
                {
                    //				mParser.videoPlayer.Play ();
                    //				mParser.audioSource.Play ();
                    mParser.playIcon.gameObject.SetActive(true);
                    mParser.pauseIcon.gameObject.SetActive(false);
                    mParser.pauseVideo = true;

                }
                //mParser.runContactAnimation();
            }
            catch(NullReferenceException ex) { }


        }

        public void DropTargetTracking()
        {
            OnTrackingLost();
        }


        private void OnTrackingLost()
        {
            try
            {
                GameObject.Find("targetManager").GetComponent<TargetTracker>().RemoveTarget(this.gameObject);
            }
            catch (NullReferenceException ex)
            { }

            try
            {
                firstrun = mParser.firstRun;
            }
            catch (NullReferenceException ex)
            {

            }
            Debug.Log("Tracking lost");
            if (!firstrun || staticTargets)
            {
                Debug.Log("Were in!");
                Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
                Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
                Canvas[] canvasComponents = GetComponentsInChildren<Canvas>(true);

                // Disable Canvas
                foreach (Canvas component in canvasComponents)
                {
                    component.enabled = false;
                }

                // Disable rendering:
                foreach (Renderer component in rendererComponents)
                {
                    component.enabled = false;
                }

                // Disable colliders:
                foreach (Collider component in colliderComponents)
                {
                    component.enabled = false;
                }
                //analyticsControl.launchTimeTrack(false);

                Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

                try
                {
                    ispaused = mParser.isPaused;
                    firstrun = mParser.firstRun;

                    // when target lost pause the video
                    if (!firstrun)
                    {
#if UNITY_IOS || UNITY_EDITOR
                        mParser.videoPlayer.Pause();
                        mParser.audioSource.Pause();
#elif UNITY_ANDROID
                    mParser.easyPlayer.Pause();
#endif
                    }

#if UNITY_IOS || UNITY_EDITOR
                    mParser.videoPlayer.Pause();
                    mParser.audioSource.Pause();
#elif UNITY_ANDROID
                    mParser.easyPlayer.Pause();
#endif
                }
                catch (NullReferenceException ex) { }
            }
        }

        #endregion // PRIVATE_METHODS
    }
}
