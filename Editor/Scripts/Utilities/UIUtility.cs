using System;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public static class UIUtility
{
    [MenuItem("Assets/Create/Wasd/Panel", priority = 0)]
    static void MenuItemPanel()
    {
        string path = GetPath();
        if(string.IsNullOrEmpty(path))
        {
            Debug.LogError("TemplatePanel.txt not found");
            return;
        }
        CreateScriptAssetFromTemplateFile(path, "Panel");
    }

    static string GetPath()
    {
        var dict = Directory.GetParent(Application.dataPath);
        var files = dict.GetFiles("TemplatePanel.txt", SearchOption.AllDirectories);
        foreach(var item in files)
        {
            return item.FullName;
        }
        return "";
    }
    static void CreateScriptAssetFromTemplateFile(string templatePath, string templateAssetName)
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, $"New{templateAssetName}.cs");
    }
    [MenuItem("GameObject/UI/WASD/Safe Area", false, 0)]
    static void AddSafeArea()
    {
        var canvas = GameObject.FindAnyObjectByType<Canvas>();
        if(canvas == null)
        {
            canvas = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster)).GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
        var panel = CreateUI(canvas.transform, typeof(RectTransform), typeof(SafeArea));
        panel.transform.localScale = Vector3.one;
        panel.name = "Safe Area";
        Selection.activeGameObject = panel;
    }
    [MenuItem("GameObject/UI/WASD/Panel", false, 0)]
    static void AddPanel()
    {
        var canvas = GameObject.FindAnyObjectByType<Canvas>();
        if(canvas == null)
        {
            canvas = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster)).GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
        Debug.Log(canvas);
        var panel = CreateUI(canvas.transform, typeof(RectTransform), typeof(CanvasGroup));
        var bg = CreateUI(panel.transform, typeof(RectTransform), typeof(Image));
        bg.name = "Background";
        bg.GetComponent<Image>().color = new Color(0, 0, 0, 0.75f);
        Selection.activeGameObject = panel;
    }

    [MenuItem("GameObject/UI/WASD/Progress", false, 1)]
    static void AddProgress()
    {
        var goProgress = CreateProgress<UIProgress>();
        var canvas = GameObject.FindAnyObjectByType<Canvas>();
        if(canvas == null)
        {
            canvas = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster)).GetComponent<Canvas>();
        }
        var eventSystem = GameObject.FindObjectOfType<EventSystem>();
        if(eventSystem == null)
        {
            new GameObject("EventSystem", typeof(EventSystem));
        }
        if(Selection.activeGameObject != null)
        {
            Selection.activeGameObject.transform.IsChildOf(canvas.transform);
            goProgress.transform.SetParent(Selection.activeTransform);
        }
        else
        {
            goProgress.transform.SetParent(canvas.transform);
        }

        goProgress.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
    [MenuItem("GameObject/WASD/InGame/Healthbar", false, 2)]
    static void AddHealthbar()
    {
        GameObject gameObject = new GameObject("Healthbar", typeof(Healthbar));
        gameObject.TryGetComponent(out Healthbar healthbar);
        gameObject.transform.SetParent(Selection.activeTransform);
        gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        var canvas = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler)).GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 0.2f);
        canvas.transform.SetParent(gameObject.transform);
        canvas.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        canvas.transform.localScale = Vector3.one * 0.01f;

        var goProgress = CreateProgress<HealthProgress>();
        goProgress.transform.SetParent(canvas.transform);
        goProgress.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        goProgress.TryGetComponent(out HealthProgress progress);
        goProgress.transform.localScale = Vector3.one * 0.25f;

        Transform trnFillArea = goProgress.transform.GetChild(0).GetChild(0);
        var goSliderDamage = CreateSliderDamage(trnFillArea);
        goSliderDamage.transform.SetAsFirstSibling();

        SerializedObject serializedObject = new SerializedObject(healthbar);
        SerializedObject serializedProgress = new SerializedObject(progress);

        SerializedProperty propertyCanvas = serializedObject.FindProperty("canvas");
        SerializedProperty propertyHealth = serializedObject.FindProperty("Health");
        SerializedProperty propertyProgress = serializedObject.FindProperty("progress");
        SerializedProperty propertyAlignWithCamera = serializedObject.FindProperty("alignWithCamera");
        SerializedProperty propertySliderDamage = serializedProgress.FindProperty("sliderDamage");
        SerializedProperty propertyImgFillDamage = serializedProgress.FindProperty("imgFillDamage");

        propertyCanvas.objectReferenceValue = canvas;
        propertyProgress.objectReferenceValue = progress;
        propertyAlignWithCamera.boolValue = true;
        propertySliderDamage.objectReferenceValue = goSliderDamage.GetComponent<Slider>();
        propertyImgFillDamage.objectReferenceValue = goSliderDamage.transform.GetChild(0).GetComponent<Image>();
        var health = gameObject.GetComponentInParent<HealthComponent>();
        if(health != null)
        {
            propertyHealth.objectReferenceValue = health;
        }
        serializedProgress.ApplyModifiedProperties();
        serializedObject.ApplyModifiedProperties();
    }
    static GameObject CreateSliderDamage(Transform parent)
    {
        var goSlider = CreateUI(parent.transform, typeof(RectTransform), typeof(Slider));
        goSlider.name = "SliderDamage";
        goSlider.TryGetComponent(out Slider slider);
        goSlider.TryGetComponent(out RectTransform rectTrnSlider);

        var goFill = CreateUI(goSlider.transform, typeof(RectTransform), typeof(Image));
        goFill.name = "Image";
        goFill.TryGetComponent(out Image imgFill);
        goFill.TryGetComponent(out RectTransform rectTrnFill);

        return goSlider;
    }

    static GameObject CreateUI(Transform parent, params Type[] components)
    {
        var panel = new GameObject("Panel", components);
        panel.transform.SetParent(parent.transform);
        panel.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        var rect = panel.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);

        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
        return panel;
    }

    static GameObject CreateProgress<T>() where T : UIProgress
    {
        var sprites = EditorExtensions.FindAssets<Sprite>(EditorExtensions.labelSlider, "Slider_White_Fill", "Slider_White_Frame");
        GameObject goProgress = new GameObject("Progress", typeof(RectTransform), typeof(T));
        goProgress.TryGetComponent(out T progress);
        goProgress.TryGetComponent(out RectTransform rectTrnProgress);

        var goSlider = CreateUI(goProgress.transform, typeof(RectTransform), typeof(Slider));
        goSlider.name = "Slider";
        goSlider.TryGetComponent(out Slider slider);
        goSlider.TryGetComponent(out RectTransform rectTrnSlider);

        var goFillArea = CreateUI(goSlider.transform, typeof(RectTransform), typeof(Image), typeof(Mask));
        goFillArea.name = "Fill Area";
        goFillArea.TryGetComponent(out Image imgFillArea);
        goFillArea.TryGetComponent(out RectTransform rectTrnFillArea);

        var goFill = CreateUI(goFillArea.transform, typeof(RectTransform), typeof(Image));
        goFill.name = "Fill";
        goFill.TryGetComponent(out Image imgFill);
        goFill.TryGetComponent(out RectTransform rectTrnFill);

        var goText = CreateUI(goFillArea.transform, typeof(RectTransform), typeof(TextMeshProUGUI));
        goText.TryGetComponent(out RectTransform rectTrnText);
        goText.TryGetComponent(out TextMeshProUGUI text);
        goText.name = "Text";

        var goPoint = new GameObject("Point", typeof(RectTransform));
        goPoint.transform.SetParent(goFill.transform);
        goPoint.TryGetComponent(out RectTransform rectTrnPoint);

        //Set Progress
        rectTrnProgress.anchorMin = new Vector2(0.5f, 0.5f);
        rectTrnProgress.anchorMax = new Vector2(0.5f, 0.5f);
        rectTrnProgress.sizeDelta = new Vector2(550, 55);
        SerializedObject serializedProgress = new SerializedObject(progress);
        SerializedProperty propertySlider = serializedProgress.FindProperty("slider");
        SerializedProperty propertyText = serializedProgress.FindProperty("text");
        SerializedProperty propertyFill = serializedProgress.FindProperty("imgFill");
        SerializedProperty propertyFillArea = serializedProgress.FindProperty("imgFillArea");
        propertySlider.objectReferenceValue = slider;
        propertyText.objectReferenceValue = text;
        propertyFill.objectReferenceValue = imgFill;
        propertyFillArea.objectReferenceValue = imgFillArea;
        serializedProgress.ApplyModifiedProperties();

        //Set Text 
        rectTrnText.anchorMin = new Vector2(0.5f, 0);
        rectTrnText.anchorMax = new Vector2(0.5f, 1);
        text.text = "100/100";
        text.fontSize = 36;
        text.alignment = TextAlignmentOptions.Midline;
        text.color = Color.white;
        text.enableWordWrapping = false;

        //Set Slider
        rectTrnSlider.anchorMin = new Vector2(0, 0);
        rectTrnSlider.anchorMax = new Vector2(1, 1);
        rectTrnSlider.sizeDelta = new Vector2(550, 55);
        slider.interactable = false;
        slider.transition = Selectable.Transition.None;
        slider.direction = Slider.Direction.LeftToRight;
        slider.minValue = 0;
        slider.maxValue = 1;
        slider.value = 1f;
        slider.fillRect = rectTrnFill;

        //Set Fill Area
        imgFillArea.sprite = sprites[1];
        imgFillArea.type = Image.Type.Sliced;
        imgFillArea.color = new Color(40 / 255f, 50 / 255f, 75 / 255f, 1f);

        //Set Fill
        rectTrnFill.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        rectTrnFill.anchorMin = new Vector2(0, 0);
        rectTrnFill.anchorMax = new Vector2(0, 1);

        imgFill.sprite = sprites[0];
        imgFill.type = Image.Type.Sliced;
        imgFill.color = Color.green;

        //Set Point
        rectTrnPoint.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        rectTrnPoint.anchorMin = new Vector2(1f, 0.5f);
        rectTrnPoint.anchorMax = new Vector2(1f, 0.5f);

        return goProgress;
    }
}
