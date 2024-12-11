using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaPickerPro.Models;

namespace IdeaPickerPro.Views;

public partial class RandomPage : ContentPage
{
    public RandomPage()
    {
        InitializeComponent();
    }

    private void GetRandomIdea(object sender, EventArgs e)
    {
        var items = App.IdeaList.GetIdeas().ToArray();
        
        var random = new Random();
        var randomIndex = random.Next(0, items.Length);

        Idea randomItem = (Idea)items.GetValue(randomIndex);
        
        lblResult.Text = App.IdeaList.GetIdeaById(randomItem.Id).Description;
    }
}