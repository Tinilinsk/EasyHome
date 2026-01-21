namespace EasyHome.Views;

public partial class AddProduct : ContentPage
{
    private string _imagePath;


    public AddProduct()
	{
		InitializeComponent();
	}

	private async void SubmitNewProduct(object sender, EventArgs e)
	{
        if (string.IsNullOrWhiteSpace(InputName.Text))
        {
            await DisplayAlert("Error", "Please enter product name", "OK");
            InputName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(InputDescription.Text))
        {
            await DisplayAlert("Error", "Please enter category name", "OK");
            InputDescription.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(InputPrice.Text))
        {
            await DisplayAlert("Error", "Please enter product price", "OK");
            InputPrice.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(InputCategory.Text))
        {
            await DisplayAlert("Error", "Please enter product category", "OK");
            InputPrice.Focus();
            return;
        }

        if (!decimal.TryParse(InputPrice.Text.Replace('.', ','), out decimal price) || price < 0)
        {
            await DisplayAlert("Error", "Please enter a valid positive number for price", "OK");
            InputPrice.Text = "";
            InputPrice.Focus();
            return;
        }
        string name = InputName.Text;
		string description = InputDescription.Text;
        string category = InputCategory.Text;
		bool inStock = InputInStock.IsToggled;

		Result.Text = $"Product Added:\nName: {name}\nDescription: {description}\nCategory: {category}\nPrice: {price:C}\nIn Stock: {inStock}";
    }

    private async void OnPickPhotoClicked(object sender, EventArgs e)
    {
        var files = await MediaPicker.PickPhotosAsync();
        if (files == null || files.Count == 0)
            return;

        var file = files[0];

        var imagesPath = Path.Combine(FileSystem.AppDataDirectory, "images");

        if (!Directory.Exists(imagesPath))
            Directory.CreateDirectory(imagesPath);

        var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var newFilePath = Path.Combine(imagesPath, newFileName);

        using var sourceStream = await file.OpenReadAsync();
        using var localFileStream = File.OpenWrite(newFilePath);

        await sourceStream.CopyToAsync(localFileStream);

        _imagePath = newFilePath;

        Result.Text = $"Photo selected: {_imagePath}";
    }
}