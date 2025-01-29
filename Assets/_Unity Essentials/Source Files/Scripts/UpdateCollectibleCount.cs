using UnityEngine;
using TMPro;
using System; // Required for Type handling

// if the player collects all the collectibles, vfx and win sound will play
public class UpdateCollectibleCount : MonoBehaviour
{
    private TextMeshProUGUI collectibleText; // Reference to the TextMeshProUGUI component
    public GameObject winVFX;
    public AudioSource winSound;
    public GameObject player; // Player referansı eklendi
    private bool hasWon = false; // Kazanma durumunu kontrol etmek için
    private int vfxCount = 0; // VFX sayacı
    private const int MAX_VFX_COUNT = 10; // Maksimum VFX sayısı

    void Start()
    {
        collectibleText = GetComponent<TextMeshProUGUI>();
        if (collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }
        UpdateCollectibleDisplay(); // Initial update on start
    }

    void Update()
    {
        UpdateCollectibleDisplay();
    }

    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        // Optionally, check and count objects of type Collectible2D as well if needed
        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        // Update the collectible count display
        collectibleText.text = $"Collectibles remaining: {totalCollectibles}";
        
        // Tüm collectible'lar toplandığında ve VFX sayısı 10'dan azsa
        if (totalCollectibles == 0 && vfxCount < MAX_VFX_COUNT)
        {
            // VFX'i player'ın üzerinde oluştur
            if (player != null)
            {
                GameObject vfxInstance = Instantiate(winVFX, player.transform.position, Quaternion.identity);
                vfxInstance.transform.parent = player.transform;
                vfxCount++; // VFX sayacını artır
                
                // İlk VFX'te ses çal
                if (vfxCount == 1)
                {
                    winSound.Play();
                }
            }
            else
            {
                Debug.LogWarning("Player referansı ayarlanmamış!");
            }
        }
    }
}
