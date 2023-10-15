namespace BillSplitter;

public partial class MainPage : ContentPage
{
	private decimal bill;
	private int tip;
	private int noPeople = 1;
	public MainPage()
	{
		InitializeComponent();
	}

    private void txtBill_Completed(object sender, EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();
    }

    private void CalculateTotal()
    {
        var totalTip = (bill * tip) / 100;
        var tipByPerson = totalTip / noPeople;
        
        lbTipByPerson.Text = $"{tipByPerson:C}";

        var subtotal = bill / noPeople;

        lbSubtotal.Text = $"{subtotal:C}";

        var totalByPerson = (bill + totalTip) / noPeople;
        lbTotal.Text = $"{totalByPerson:C}";
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;
        }
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if(noPeople == 1){
            return;
        }

        noPeople--;
        lblNoPersons.Text = noPeople.ToString();
        CalculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        noPeople++;
        lblNoPersons.Text = noPeople.ToString();
        CalculateTotal();
    }
}

