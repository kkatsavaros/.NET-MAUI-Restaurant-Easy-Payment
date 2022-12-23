namespace RestaurantEasyPayment;

public partial class MainPage : ContentPage
{
    decimal bill;         // Ο λογαριασμός
    int tip;              // Το φιλοδώρημα
    int noPersons = 1;    // Πόσα άτομα θα μοιραστούον τον λογαριασμό.

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
        //Total tip
        var totalTip = (bill * tip) / 100;

        //Tip by person
        var tipByPerson = (totalTip / noPersons);
        lblTipByPerson.Text = $"{tipByPerson:C}";

        //Subtotal
        var subtotal = (bill / noPersons);
        lblSubtotal.Text = $"{subtotal:C}";

        //Total
        var totalByPerson = (bill + totalTip) / noPersons;
        lblTotal.Text = $"{totalByPerson:C}";
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
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

            var percentage = int.Parse(btn.Text.Replace("%", ""));  // Πάρε το Text του Button βγάλε το % και 

            sldTip.Value = percentage;                              // βάλε την τιμή στον Slider.
        }
    }


    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        if (noPersons > 1)        // Make sure that the number of persons are not less than 1.
        {
            noPersons--;
        }
        lblNoPerons.Text = noPersons.ToString();
        CalculateTotal();
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        noPersons++;
        lblNoPerons.Text = noPersons.ToString();
        CalculateTotal();
    }

}


