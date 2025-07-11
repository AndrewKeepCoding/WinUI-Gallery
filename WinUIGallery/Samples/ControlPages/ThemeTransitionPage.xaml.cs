// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;

namespace WinUIGallery.ControlPages;

public sealed partial class ThemeTransitionPage : Page
{

    private int _itemCount = 10;
    public ThemeTransitionPage()
    {
        this.InitializeComponent();

        for (int i = 0; i < _itemCount; i++)
        {
            AddRemoveListView.Items.Add(new ListViewItem() { Content = "Item " + i });
        }

        AddItemsToContentListView();
    }

    private void ShowPopupButton_Click(object sender, RoutedEventArgs e)
    {
        ExamplePopup.IsOpen = true;
        ClosePopupButton.Focus(FocusState.Programmatic);
    }

    private void ClosePopupButton_Click(object sender, RoutedEventArgs e)
    {
        ExamplePopup.IsOpen = false;
        ShowPopupButton.Focus(FocusState.Programmatic);
    }

    private void ContentRefreshButton_Click(object sender, RoutedEventArgs e)
    {
        AddItemsToContentListView(true);
    }

    private void AddItemsToContentListView(bool ShowDifferentContent = false)
    {
        var items = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            items.Add(ShowDifferentContent ? "Updated content " + i : "Item " + i);
        }

        ContentList.ItemsSource = items;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        AddRemoveListView.Items.Add(new ListViewItem() { Content = "New Item " + _itemCount.ToString() });
        _itemCount++;
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (AddRemoveListView.Items.Count > 0)
            AddRemoveListView.Items.RemoveAt(0);
    }

    private void RepositionButton_Click(object sender, RoutedEventArgs e)
    {
        MiddleElement.Visibility = MiddleElement.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
    }

    private void EntranceAddButton_Click(object sender, RoutedEventArgs e)
    {
        var value = Convert.ToInt32((sender as Button).Tag);

        for (int i = 0; i < value; i++)
        {
            Thickness thickness = new Thickness(5.0);
            EntranceStackPanel.Children.Add(new Rectangle() { Width = 50, Height = 50, Margin = thickness, Fill = new SolidColorBrush(Microsoft.UI.Colors.LightBlue) });
        }
    }

    private void EntranceClearButton_Click(object sender, RoutedEventArgs e)
    {
        EntranceStackPanel.Children.Clear();
    }

    private void AddDeleteButton_Click(object sender, RoutedEventArgs e)
    {
        AddButton_Click(sender, e);
        DeleteButton_Click(sender, e);
    }
}
