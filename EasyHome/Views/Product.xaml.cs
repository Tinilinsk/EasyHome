namespace EasyHome.Views;

public partial class Product : ContentPage
{
    private List<string> productImages = new List<string>
    {
        "chair_grey.png",
        "sofa_detail1.png",
        "sofa_detail2.png"
    };

    private int currentImageIndex = 0;

    public Product()
    {
        InitializeComponent();
        MainProductImage.Source = productImages[currentImageIndex];
    }

    private void OnNextImageClicked(object sender, EventArgs e)
    {
        currentImageIndex++;

        if (currentImageIndex >= productImages.Count)
        {
            currentImageIndex = 0;
        }

        UpdateImage();
    }

    private void OnPreviousImageClicked(object sender, EventArgs e)
    {
        currentImageIndex--;

        if (currentImageIndex < 0)
        {
            currentImageIndex = productImages.Count - 1;
        }

        UpdateImage();
    }

    private void UpdateImage()
    {
        MainProductImage.Source = productImages[currentImageIndex];
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}