namespace MauiApp1;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

public partial class MainPage : ContentPage
{
    List<char> Operators;
    public MainPage()
	{
		InitializeComponent();
        Operators = new List<char>();
        Operators.Add('+');
        Operators.Add('-');
        Operators.Add('*');
        Operators.Add('/');
    }
    private void Show(object sender, EventArgs e)
    {

    }
	private void Write(object sender, EventArgs e)
    {
		var but = sender as Button;
		if(entry.Text == "0")
        {
            entry.Text = but.Text;
        }
		
        else
            entry.Text += but.Text;
        bntAC.Text = "C";
    }
	private void ButtonDel(object sender, EventArgs e)
    {
        
        if(entry.Text.Length == 1)
        {
            entry.Text = "0";
            bntAC.Text = "AC";
            bntParenthesis.Text = "(";
        }
        else
            entry.Text = entry.Text.Substring(0, entry.Text.Length - 1);
    }
	private void ButtonDot(object sender, EventArgs e)
    {
        bntAC.Text = "C";
        entry.Text += ".";

    }
    
    private void ButtonAC(object sender, EventArgs e)
    {
		entry.Text = "0";
        bntAC.Text = "AC";
        if(bntParenthesis.Text == ")")
            bntParenthesis.Text = "(";
    }
    private void btnequal_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            var v = dt.Compute(entry.Text, "");
            if(v.ToString().Contains(','))
            {
                entry.Text = v.ToString().Replace(',', '.');
            }
            else
                entry.Text = v.ToString();
        }
        catch(Exception ex)
        {
            entry.Text = ex.Message;
        }
    }
    
    private void ButtonPercentage(object sender, EventArgs e)
    {
        object[] percentage = Utility.IsParsable(entry.Text);
        var value = (string)percentage[0];
        var s = (int)percentage[1];
        bool b = Operators.All(x => !entry.Text.Contains(x));
        if (b)
            try
            {
                entry.Text = (float.Parse(entry.Text) / 100).ToString().Replace(',', '.');
            }
            catch
            {

            }
        else
            entry.Text = String.Concat(entry.Text.Remove(s + 1), (float.Parse(value) / 100).ToString().Replace(',', '.'));
    }
    private void ParenthesisButton(object sender, EventArgs e)
    {
        bntAC.Text = "C";
        if (bntParenthesis.Text == "(")
        {
            bntParenthesis.Text = ")";
            if (entry.Text != "0")
            {
                entry.Text += "(";
            }
            else
            {
                entry.Text = "(";
            }
        }
        else
        {
            bntParenthesis.Text = "(";
            entry.Text += ")";
        }

    }

	
}

