namespace EasyHome.Views;

public partial class AddProduct : ContentPage
{
	public AddProduct()
	{
		InitializeComponent();
	}

	private void SubmitNewProduct(object sender, EventArgs e)
	{
		string name = InputName.Text;
		string description = InputDescription.Text;
		decimal price = decimal.Parse(InputPrice.Text);
		bool inStock = InputInStock.IsToggled;

		Result.Text = $"Product Added:\nName: {name}\nDescription: {description}\nPrice: {price:C}\nIn Stock: {inStock}";
    }
}