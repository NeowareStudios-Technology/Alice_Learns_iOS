/*============================================================================== 
 * Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class TrackableEventHandlerPure : MonoBehaviour, ITrackableEventHandler
{
    public float animtrigger;
    #region PRIVATE_MEMBERS
    private TrackableBehaviour mTrackableBehaviour;
    private bool mHasBeenFound = false;
    private bool mLostTracking;
    private float mSecondsSinceLost;
	public GameObject findNull;
    string Null = " ";
	public GameObject cover, hold, seam, p23, p45, p67, p89, p1011, p1213, p1415, p1617, p1819, p2021, p2223, p2425, p2627, p2829, p3031, p3233, p3435, p3637, p3839, p4041, p4243, p4445, p4647, p4849, p5051, p5253, p5455,p5657, p5859, p6061, p62;
    #endregion // PRIVATE_MEMBERS


    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        OnTrackingLost();
    }

    void Update()
    {
        // Pause the video if tracking is lost for more than two seconds
        if (mHasBeenFound && mLostTracking)
        {
            if (mSecondsSinceLost > 0.5f)
            {
                VideoPlaybackBehaviour video = GetComponentInChildren<VideoPlaybackBehaviour>();
                if (video != null &&
                    video.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    video.VideoPlayer.Pause();
                }

                mLostTracking = false;
            }

            mSecondsSinceLost += Time.deltaTime;
        }
    }

    #endregion //MONOBEHAVIOUR_METHODS


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
    #endregion //PUBLIC_METHODS


    #region PRIVATE_METHODS
    private void OnTrackingFound()
    {
        animtrigger = 1;
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();
		Canvas [] canvasComponents = GetComponentsInChildren<Canvas>(true);

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
		if (mTrackableBehaviour.TrackableName == "Cover")
		{
			cover.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "eggs_ham")
		{
			hold.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "InSeam")
		{
			seam.SetActive(true);
		}

		if (mTrackableBehaviour.TrackableName == "P2_3")
		{
			p23.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P4_5")
		{
			p45.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P6_7")
		{
			p67.SetActive(true);
		}
			
		if (mTrackableBehaviour.TrackableName == "P8_9")
		{
			p89.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P10_11")
		{
			p1011.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P12-13")
		{
			p1213.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P14_15")
		{
			p1415.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P16_17")
		{
			p1617.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P18_19")
		{
			p1819.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P20_21")
		{
			p2021.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P23")
		{
			p2223.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P25")
		{
			p2425.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P27")
		{
			p2627.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P29")
		{
			p2829.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P31")
		{
			p3031.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P33")
		{
			p3233.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P35")
		{
			p3435.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P37")
		{
			p3637.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P39")
		{
			p3839.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P41")
		{
			p4041.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P43")
		{
			p4243.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P45")
		{
			p4445.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P47")
		{
			p4647.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P49")
		{
			p4849.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P51")
		{
			p5051.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P53")
		{
			p5253.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P55")
		{
			p5455.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P57")
		{
			p5657.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P59")
		{
			p5859.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P61")
		{
			p6061.SetActive(true);
		}
		if (mTrackableBehaviour.TrackableName == "P62")
		{
			p62.SetActive(true);
		}
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

        // Optionally play the video automatically when the target is found

        VideoPlaybackBehaviour video = GetComponentInChildren<VideoPlaybackBehaviour>();
        if (video != null && video.AutoPlay)
        {
            if (video.VideoPlayer.IsPlayableOnTexture())
            {
                VideoPlayerHelper.MediaState state = video.VideoPlayer.GetStatus();
                if (state == VideoPlayerHelper.MediaState.PAUSED ||
                    state == VideoPlayerHelper.MediaState.READY ||
                    state == VideoPlayerHelper.MediaState.STOPPED)
                {
                    // Pause other videos before playing this one
                    PauseOtherVideos(video);

                    // Play this video on texture where it left off
                    video.VideoPlayer.Play(false, video.VideoPlayer.GetCurrentPosition());
                }
                else if (state == VideoPlayerHelper.MediaState.REACHED_END)
                {
                    // Pause other videos before playing this one
                    PauseOtherVideos(video);

                    // Play this video from the beginning
                    video.VideoPlayer.Play(false, 0);
                }
            }
        }

        mHasBeenFound = true;
        mLostTracking = false;
    }

    private void OnTrackingLost()
    {
        animtrigger = 0;
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();
		Canvas [] canvasComponents = GetComponentsInChildren<Canvas>(true);

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

		if (mTrackableBehaviour.TrackableName == "P8_9")
		{
			GameObject.Find("TextFeed89").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P10_11")
		{
			GameObject.Find("TextFeed1011").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P12-13")
		{
			GameObject.Find("TextFeed1213").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P14_15")
		{
			GameObject.Find("TextFeed1415").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P16_17")
		{
			GameObject.Find("TextFeed1617").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P18_19")
		{
			GameObject.Find("TextFeed1819").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P20_21")
		{
			GameObject.Find("TextFeed2021").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P23")
		{
			GameObject.Find("TextFeed2223").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P25")
		{
			GameObject.Find("TextFeed2425").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P27")
		{
			GameObject.Find("TextFeed2627").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P29")
		{
			GameObject.Find("TextFeed2829").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P31")
		{
			GameObject.Find("TextFeed3031").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P33")
		{
			GameObject.Find("TextFeed3233").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P35")
		{
			GameObject.Find("TextFeed3435").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "37")
		{
			GameObject.Find("TextFeed3637").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P39")
		{
			GameObject.Find("TextFeed3839").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P41")
		{
			GameObject.Find("TextFeed4041").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P43")
		{
			GameObject.Find("TextFeed4243").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P45")
		{
			GameObject.Find("TextFeed4445").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P47")
		{
			GameObject.Find("TextFeed4647").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P49")
		{
			GameObject.Find("TextFeed4849").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P51")
		{
			GameObject.Find("TextFeed5051").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P53")
		{
			GameObject.Find("TextFeed5253").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P55")
		{
			GameObject.Find("TextFeed5455").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P57")
		{
			GameObject.Find("TextFeed5657").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P59")
		{
			GameObject.Find("TextFeed5859").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P61")
		{
			GameObject.Find("TextFeed61").SetActive(false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
		if (mTrackableBehaviour.TrackableName == "P62") {
			
			GameObject.Find ("TextFeed62").SetActive (false);
			Null = findNull.GetComponent<Text>().text;
			GameObject.Find("Placeholder").GetComponent<Text>().text = Null;
		}
        mLostTracking = true;
        mSecondsSinceLost = 0;
    }

    // Pause all videos except this one
    private void PauseOtherVideos(VideoPlaybackBehaviour currentVideo)
    {
        VideoPlaybackBehaviour[] videos = (VideoPlaybackBehaviour[])
                FindObjectsOfType(typeof(VideoPlaybackBehaviour));

        foreach (VideoPlaybackBehaviour video in videos)
        {
            if (video != currentVideo)
            {
                if (video.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    video.VideoPlayer.Pause();
                }
            }
        }
    }
    #endregion //PRIVATE_METHODS
}
