﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 背景声音
/// @author hannibal
/// @time 2017-2-20
/// </summary>
public class BackgroundSound : SoundBase
{
    private GameObject m_AudioSourceParent;

    static public IPoolsObject CreateObject()
    {
        return new BackgroundSound();
    }
    public override string GetPoolsType()
    {
        return SoundBase.POOLS_SOUND_BG;
    }
    public override void Init()
    {
        base.Init();
    }
    public override void Release()
    {
        base.Release();
        if (m_AudioSourceParent != null)
        {
            GameObject.Destroy(m_AudioSourceParent);
            m_AudioSourceParent = null;
        }
    }
    public override void Setup(string fileName, Vector3 pos, Transform parent, float min_distance, float max_distance, bool loop = false)
    {
        base.Setup(fileName, pos, parent, min_distance, max_distance, loop);

        AudioClip clip = ResourceLoaderManager.Instance.Load(fileName) as AudioClip;
        if (clip == null)
        {
            Log.Error("SoundManager::PlayBGSound - not load sound, file:" + fileName);
            return;
        }
        AudioListener listener = SoundManager.Instance.GetDefaultListener();
        if (listener != null)
        {
            m_AudioSourceParent = new GameObject("AudioSourceParent", typeof(AudioSource));
            m_AudioSourceParent.transform.SetParent(listener.transform, false);
            m_SoundSource = m_AudioSourceParent.GetComponent<AudioSource>();
            m_SoundSource.clip = clip;
            m_SoundSource.loop = loop;
            m_SoundSource.volume = SoundManager.Instance.BGSoundVolume;
            m_SoundSource.Play();
        }
    }
    public override void Play()
    {
        base.Play();
        if (m_SoundSource != null && !SoundManager.Instance.IsCloseBGSound)
        {
            m_SoundSource.volume = SoundManager.Instance.BGSoundVolume;
            m_SoundSource.Play();
        }
    }
    public override void Stop()
    {
        base.Stop();
    }
    public override void PauseSound()
    {
        base.PauseSound();
    }
    public override void ResumeSound()
    {
        base.ResumeSound();
        if (m_SoundSource != null)
        {
            m_SoundSource.volume = SoundManager.Instance.BGSoundVolume;
        }
    }
}
