using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaPickerPro.Models;

namespace IdeaPickerPro.Views;

public partial class AddPage : ContentPage
{
    public AddPage()
    {
        InitializeComponent();
    }

    // private double _rotationAngle = 0;
    //
    // public void ResetWheel()
    // {
    //     _rotationAngle = 0;
    // }

    // private void Spin()
    // {
    //     // var random = new Random();
    //             // var randomRotation = random.Next(720, 1000);
    //             // var animation = new Animation(v => _rotationAngle = v, _rotationAngle, _rotationAngle + randomRotation);
    //             // animation.Commit(this, "SpinWheel", length: 3000, easing: Easing.CubicOut);
    // }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var IdeaTemplate = new DataTemplate(typeof(TextCell));
        IdeaTemplate.SetBinding(TextCell.TextProperty, "Description");

        lstIdeas.ItemTemplate = IdeaTemplate;
        lstIdeas.ItemsSource = App.IdeaList.GetIdeas();
    }
    
    private void AddIdea(object sender, EventArgs e)
    {
        var idea = new Idea();
        idea.Description = txtInput.Text;

        App.IdeaList.SaveIdea(idea);

        txtInput.Text = "";
        
        OnAppearing();
    }

    private void SelectedItem(object sender, SelectedItemChangedEventArgs e)
    {
        btnDelete.IsEnabled = true;
    }

    private void DeleteIdea(object sender, EventArgs e)
    {
        Idea idea = (Idea)lstIdeas.SelectedItem;
        
        App.IdeaList.DeleteIdea(idea.Id);
        OnAppearing();
        
        btnDelete.IsEnabled = false;
    }
}