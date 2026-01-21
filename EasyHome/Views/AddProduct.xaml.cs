namespace EasyHome.Views;

public partial class AddProduct : ContentPage
{
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

    private void OnPickPhotoClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}